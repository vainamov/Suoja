using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;
using System.Threading;

namespace Suoja
{
    public partial class MainWindow : Form
    {
        private List<SuojaJob> Jobs = new List<SuojaJob>(); //List containing all jobs

        private readonly string[] ErrorMessages = {
            "Der Auftrag schlug fehl, da die zu entschlüsselnden Daten nicht mehr im Originalzustand sind.\n\nFehlercode: sja-2.0.12-0x000",
            "Der Auftrag schlug fehl, da der zu verwendene Schlüssel nicht dem zur Verschlüsselung benutzten Schlüssel entspricht.\n\nFehlercode: sja-2.0.12-0x001",
            "Der Auftrag scheiterte aus unbekannten Gründen.\n\nFehlercode: sja-2.0.12-unknwn"
        };

        public MainWindow()
        {
            InitializeComponent(); //Import for the Designer
        }

        public MainWindow(string path)
        {
            InitializeComponent();
            AddJobDialog ajd = new AddJobDialog(); //Show a new AddJobDialog
            ajd.Filepath = path; //But already set the path
            ajd.AllowBrowsing = false; //Disallow browsing for files
            if (ajd.ShowDialog() == DialogResult.OK)
            {
                addJob(ajd.Filepath, ajd.Keypath, ajd.Action, ajd.Source, ajd.Option); //Add the corresponding job
            }
            ajd.Dispose(); //Cleanup
        }

        private SuojaProvider Provider = new SuojaProvider(); //SuojaProvider for all en-/decryption jobs
        private SuojaCryptographicData CryptographicData; //Data storage for used Key and IV

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddJobDialog ajd = new AddJobDialog(); //Initialize a new AddJobDialog
            if (ajd.ShowDialog() == DialogResult.OK) //If the user hit ok
            {
                addJob(ajd.Filepath, ajd.Keypath, ajd.Action, ajd.Source, ajd.Option); //Add the corresponding job
            }
            ajd.Dispose(); //Cleanup
        }

        private void addJob(string filepath, string keypath, EnumerationTypes.JobAction action, EnumerationTypes.KeySource source, EnumerationTypes.FileNameOption option)
        {
            SuojaJob job = new SuojaJob(filepath, keypath, action, source, option); //Initialize a new job
            job.Status = EnumerationTypes.JobStatus.Queued; //Set it's status to queued
            Jobs.Add(job); //Add the job
            ListViewItem lvi = new ListViewItem(); //Create a new ListViewItem
            lvi.Group = lvwJobs.Groups[0]; //Group set to "waiting"
            lvi.Text = filepath; //Display the filepath
            if (action == EnumerationTypes.JobAction.Decrypt) { lvi.SubItems.Add("Entschlüsseln"); } else { lvi.SubItems.Add("Verschlüsseln"); } //Display either "Encrypt" or "Decrypt"
            if (source == EnumerationTypes.KeySource.File) { lvi.SubItems.Add(keypath); } else { lvi.SubItems.Add("Neu"); } //Display either the Keyfilepath or "New"
            if (option == EnumerationTypes.FileNameOption.Keep) { lvi.SubItems.Add("Unverändert"); } else { lvi.SubItems.Add("Versteckt"); } //Display either "Keep" or "Encode"
            lvwJobs.Items.Add(lvi); //Add the ListViewItem
            btnStartAll.Enabled = true; //Enable the "Start All"-button
        }

        private void lvwJobs_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnStart.Enabled = btnDelete.Enabled = lvwJobs.SelectedItems.Count > 0; //Enable the "Start"- and "Delete"-button, when at least 1 item is selected
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in lvwJobs.SelectedItems)
            {
                foreach (SuojaJob job in Jobs)
                {
                    if (job.Filepath == lvi.Text) //If the selected ListViewItem matches the corresponding job
                    {
                        Jobs.Remove(job); //Remove the job
                        break;
                    }
                }
            }

            while (lvwJobs.SelectedItems.Count > 0) //For all selected and deleted Items
            {
                lvwJobs.Items.Remove(lvwJobs.SelectedItems[0]); //Remove the ListViewItem
            }

            btnStartAll.Enabled = lvwJobs.Groups[0].Items.Count > 0; //Enable the "Start All"-button if there is at least 1 job left in the queue

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in lvwJobs.SelectedItems)
            {
                foreach (SuojaJob job in Jobs)
                {
                    if (job.Filepath == lvi.Text) //If the selected ListViewItem matches the corresponding job
                    {
                        if (startJob(job)) //If the job went flawlessly
                        {
                            lvi.Group = lvwJobs.Groups[1]; //Set the group to "Finished"
                        }
                        else
                        {
                            lvi.Group = lvwJobs.Groups[2]; //Otherwise to "Error"
                        }
                    }
                }
            }

            lvwJobs.SelectedItems.Clear(); //Deselect all items
            btnStartAll.Enabled = lvwJobs.Groups[0].Items.Count > 0; //Disable the "Start All"-button if there aren't any jobs left 

        }

        private bool startJob(SuojaJob job)
        {
            if (job.Done) //Ignore the job if it's already finished
            {
                return true;
            }

            if (job.Action == EnumerationTypes.JobAction.Encrypt) //If the job is an Encryption
            {
                string outputPath;
                if (job.Source == EnumerationTypes.KeySource.File) //If the job uses an existing Key and IV
                {
                    CryptographicData = JsonConvert.DeserializeObject<SuojaCryptographicData>(File.ReadAllText(job.Keypath)); //Load the corresponding Key and IV
                    Provider = new SuojaProvider(CryptographicData); //Initialize the Provider with the Key and IV
                }
                else
                {
                    Provider = new SuojaProvider(); //Otherwise initialize a new Provider so it creates a random Key and IV
                    CryptographicData = Provider.GetCryptographicData(); //Export the Key and IV
                    File.WriteAllText(job.Keypath, JsonConvert.SerializeObject(CryptographicData, Formatting.Indented)); //Save
                }
                if (job.Option == EnumerationTypes.FileNameOption.Keep) //If the Filenameoption is set to "Keep"
                {
                    outputPath = job.Filepath + ".suoja"; //Just add ".suoja"
                }
                else
                {
                    outputPath = Path.Combine(job.BaseDirectory, Convert.ToBase64String(Encoding.Default.GetBytes(job.Filepath.Split('\\').Last())) + ".suoja"); //Encode the filename in Base64, add ".suoja" and combine the new filename with the existing path
                }
                job.OutputPath = outputPath; //Set the Output path

                JobRunningPopup jrp = new JobRunningPopup(); //Initialize a new Popup
                new Thread(delegate () //Open in a seperate thread to prevent the window from freezing
                {
                    jrp.ShowDialog(); //Show the Popup
                }).Start(); //Start the thread

                EnumerationTypes.JobResult result = Provider.Encrypt(job.Filepath, outputPath, job.Keypath); //Store the result
                File.Delete(job.BaseDirectory + ".data"); //Delete the remaining temporary files
                File.Delete(job.BaseDirectory + ".hmac"); //Delete the remaining temporary files
                File.Delete(job.BaseDirectory + ".sha256"); //Delete the remaining temporary files

                job.Result = result; //Store the result
                if (result == EnumerationTypes.JobResult.Fine)
                {
                    job.Status = EnumerationTypes.JobStatus.Finished; //Set the status to "Finished"
                    job.Done = true; //Set the result
                }
                else
                {
                    job.Status = EnumerationTypes.JobStatus.Failed; //Set the status to "Failed"
                    job.Done = false; //Set the result
                }

                /* Set Messages for the detailed view */
                if (result == EnumerationTypes.JobResult.BadData)
                {
                    job.Message = ErrorMessages[0];
                }
                else if (result == EnumerationTypes.JobResult.BadKey)
                {
                    job.Message = ErrorMessages[1];
                }
                else if (result == EnumerationTypes.JobResult.Unknown)
                {
                    job.Message = ErrorMessages[2];
                }

                jrp.Invoke(new EventHandler(delegate { jrp.Close(); })); //Invoke (because of illegal cross-threading) the Popup to close

                return job.Done; //Return it
            }
            else //The job is a Decryption
            {
                string outputPath;
                CryptographicData = JsonConvert.DeserializeObject<SuojaCryptographicData>(File.ReadAllText(job.Keypath)); //Load the Key and IV
                Provider = new SuojaProvider(CryptographicData); //Initialize the Provider with the Key and IV
                if (PathHelper.GetFilename(job.Filepath).Split('.').Length == 2) //If the filename contains only 1 dot (.) it's a Base64-encoded string
                {
                    outputPath = Path.Combine(job.BaseDirectory, Encoding.Default.GetString(Convert.FromBase64String(job.Filepath.Split('\\').Last().Remove(job.Filepath.Split('\\').Last().Length - 6, 6)))); //Therefore remove the ".suoja", decode the filename from Base64 and combine the result with the existing path
                }
                else
                {
                    outputPath = job.Filepath.Remove(job.Filepath.Length - 6, 6); //Otherwise just remove the ".suoja"
                }

                JobRunningPopup jrp = new JobRunningPopup(); //Initialize a new Popup
                new Thread(delegate () //Open in a seperate thread to prevent the window from freezing
                {
                    jrp.ShowDialog(); //Show the Popup
                }).Start(); //Start the thread

                EnumerationTypes.JobResult result = Provider.Decrypt(job.Filepath, outputPath, job.Keypath); //Store the result
                File.Delete(job.BaseDirectory + ".data"); //Delete the remaining temporary files
                File.Delete(job.BaseDirectory + ".hmac"); //Delete the remaining temporary files
                File.Delete(job.BaseDirectory + ".sha256"); //Delete the remaining temporary files

                job.Result = result; //Store the result
                if (result == EnumerationTypes.JobResult.Fine)
                {
                    job.Status = EnumerationTypes.JobStatus.Finished; //Set the status to "Finished"
                    job.Done = true; //Set the result
                }
                else
                {
                    job.Status = EnumerationTypes.JobStatus.Failed; //Set the status to "Failed"
                    job.Done = false; //Set the result
                }

                /* Set Messages for the detailed view */
                if (result == EnumerationTypes.JobResult.BadData)
                {
                    job.Message = ErrorMessages[0];
                }
                else if (result == EnumerationTypes.JobResult.BadKey)
                {
                    job.Message = ErrorMessages[1];
                }
                else if (result == EnumerationTypes.JobResult.Unknown)
                {
                    job.Message = ErrorMessages[2];
                }

                jrp.Invoke(new EventHandler(delegate { jrp.Close(); })); //Invoke (because of illegal cross-threading) the Popup to close

                if (result == EnumerationTypes.JobResult.Fine && outputPath.Length > 4 && !File.Exists(Application.StartupPath + "\\.noDocumentAdvice")) //If the user didn't chose to not see office document information popups
                {
                    if (outputPath.Substring(outputPath.Length - 5, 5) == ".docx" || outputPath.Substring(outputPath.Length - 5, 5) == ".pptx" || outputPath.Substring(outputPath.Length - 5, 5) == ".xlsx") //If the decrypted file is an office document
                    {
                        OfficeDocRepairInformationPopup odrip = new OfficeDocRepairInformationPopup(); //Inform the user about possible error messages by office
                        odrip.ShowDialog();
                    }
                }

                return job.Done; //Return the result
            }
        }

        private void btnStartAll_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in lvwJobs.Items) //For all ListViewItems
            {
                if (lvi.Group == lvwJobs.Groups[0]) //If the items group is set to "Waiting"
                {
                    foreach (SuojaJob job in Jobs)
                    {
                        if (job.Filepath == lvi.Text) //If the ListViewItem matches the corresponding job
                        {
                            if (startJob(job)) //If the job went flawlessly
                            {
                                lvi.Group = lvwJobs.Groups[1]; //Set the group to "Finished"
                            }
                            else
                            {
                                lvi.Group = lvwJobs.Groups[2]; //Otherwise to "Error"
                            }
                        }
                    }
                }
            }

            btnStartAll.Enabled = false; //Disable the "Start All"-button as all jobs are done

        }

        private void lvwJobs_DragEnter(object sender, DragEventArgs e)
        {
            DataObject data = (DataObject)e.Data;
            if (data.ContainsFileDropList()) //If the draged item is a file (or multiple)
            {
                e.Effect = DragDropEffects.All; //Enable drop
            }
        }

        private void lvwJobs_DragDrop(object sender, DragEventArgs e)
        {
            DataObject data = (DataObject)e.Data; //Get the submitted data
            EnumerationTypes.HandleMethod Method = EnumerationTypes.HandleMethod.Individual; //Define Individual as standard
            if (data.GetFileDropList().Count > 1) //If multiple files are dropped
            {
                DragDropDialog ddd = new DragDropDialog(); //Show a new DragDropDialog
                if (ddd.ShowDialog() == DialogResult.OK) //If the user hit "OK"
                {
                    Method = ddd.Method; //Set the Method to the method the user chose
                }
                ddd.Dispose(); //Cleanup

                if (Method == EnumerationTypes.HandleMethod.Compress) //If the user chose to compress the files
                {
                    string[] files = new string[data.GetFileDropList().Count]; //Prepare a string array for the filepaths
                    data.GetFileDropList().CopyTo(files, 0); //Copy the filepaths
                    SaveFileDialog sfd = new SaveFileDialog(); //Show a new SafeFileDialog
                    sfd.Filter = "Archiv (*.zip)|*.zip"; //Only allow ".zip" as extension
                    sfd.Title = "Archiv speichern unter..."; //Set the title
                    if (sfd.ShowDialog() == DialogResult.OK) //If the user hit "OK"
                    {
                        AddJobDialog ajd = new AddJobDialog(); //Show a new AddJobDialog
                        ajd.Filepath = sfd.FileName; //Set the Filename to the chosen one from the SaveFileDialog
                        ajd.AllowBrowsing = false; //Disallow browsing for files
                        if (ajd.ShowDialog() == DialogResult.OK) //If the user hit "OK"
                        {
                            SuojaCompression.Compress(files, sfd.FileName); //Compress the files and create the archive
                            addJob(sfd.FileName, ajd.Keypath, ajd.Action, ajd.Source, ajd.Option); //Add a new Job with the corresponding data
                            startJob(Jobs.Last()); //Immediately start the job
                            foreach (ListViewItem lvi in lvwJobs.Items)
                            {
                                if (lvi.Text == sfd.FileName)
                                {
                                    lvi.Group = lvwJobs.Groups[1]; //Set the group to "Finished"
                                }
                            }
                            File.Delete(sfd.FileName); //Delete the temporary archive
                        }
                        ajd.Dispose(); //Cleanup
                    }
                    sfd.Dispose(); //Cleanup
                }
                else if (Method == EnumerationTypes.HandleMethod.Individual) //If the user chose to handle each file individually
                {
                    foreach (string filepath in data.GetFileDropList()) //For every dropped file
                    {
                        AddJobDialog ajd = new AddJobDialog(); //Show a new AddJobDialog
                        ajd.Filepath = filepath; //But already set the path
                        if (ajd.ShowDialog() == DialogResult.OK) //If the user hit "OK"
                        {
                            addJob(ajd.Filepath, ajd.Keypath, ajd.Action, ajd.Source, ajd.Option); //Add the job
                        }
                        ajd.Dispose(); //Cleanup
                    }
                }
                else //If the user chose to handle all files the same
                {
                    AddJobDialog ajd2 = new AddJobDialog(); //Show a new AddJobDialog
                    ajd2.Filepath = "Individuell.datei"; //But already set the path
                    ajd2.AllowBrowsing = false; //Disallow browsing for files
                    ajd2.KeyFileOnly = true; //Disallow using generated Keys
                    if (ajd2.ShowDialog() == DialogResult.OK) //If the user hit "OK"
                    {
                        SuojaJob job = new SuojaJob(ajd2.Filepath, ajd2.Keypath, ajd2.Action, ajd2.Source, ajd2.Option); //Create the template job
                        foreach (string filepath in data.GetFileDropList()) //For every dropped file
                        {
                            if (filepath.Substring(filepath.Length - 5, 5) != "suoja" && ajd2.Action == EnumerationTypes.JobAction.Decrypt) //If the user want's to decrypt files but the actual file isn't considered encrypted
                            {
                                MessageBox.Show("Die Datei \"" + filepath.Split('\\').Last() + "\" endet nicht auf .suoja und wird ignoriert.", "Suoja", MessageBoxButtons.OK, MessageBoxIcon.Warning); //Ignore the file and inform the user
                            }
                            else
                            {
                                addJob(filepath, ajd2.Keypath, ajd2.Action, ajd2.Source, ajd2.Option); //Add Job for each file
                            }
                        }
                    }
                    ajd2.Dispose(); //Cleanup
                }
            }
            else
            {
                AddJobDialog ajd = new AddJobDialog(); //Show a new AddJobDialog
                ajd.Filepath = data.GetFileDropList()[0]; //But already set the path
                if (ajd.ShowDialog() == DialogResult.OK) //If the user hit "OK"
                {
                    addJob(ajd.Filepath, ajd.Keypath, ajd.Action, ajd.Source, ajd.Option); //Add the job
                }
                ajd.Dispose(); //Cleanup
            }
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            AboutDialog ad = new AboutDialog();
            ad.ShowDialog();
            ad.Dispose();
        }

        private void lvwJobs_DoubleClick(object sender, EventArgs e)
        {
            if (lvwJobs.SelectedItems.Count > 0)
            {
                foreach (SuojaJob job in Jobs)
                {
                    if (job.Filepath == lvwJobs.SelectedItems[0].Text)
                    {
                        JobDetails jd = new JobDetails(); //Initialize a new JobDetailDialog
                        jd.OriginalFilepath = job.Filepath; //Set the jobs params
                        jd.KeyFilepath = job.Keypath; //Set the jobs params
                        jd.Status = job.Status; //Set the jobs params
                        jd.Action = job.Action; //Set the jobs params
                        string path = job.Filepath.Substring(0, job.Filepath.Length - job.Filepath.Split('\\').Last().Length); //Otherwise split the Filepath into path and filename
                        if (job.Action == EnumerationTypes.JobAction.Decrypt)
                        {
                            if (job.Filepath.Split('\\').Last().Split('.').Length == 2) //If the filename contains only 1 dot (.) it is a Base64-encoded string
                            {
                                jd.OutputFilepath = Path.Combine(path, Encoding.Default.GetString(Convert.FromBase64String(job.Filepath.Split('\\').Last().Remove(job.Filepath.Split('\\').Last().Length - 6, 6)))); //Therefore remove the ".suoja", decode the filename from Base64 and combine the result with the existing path
                            }
                            else
                            {
                                jd.OutputFilepath = job.Filepath.Remove(job.Filepath.Length - 6, 6); //Otherwise just remove the ".suoja"
                            }
                        }
                        else
                        {
                            if (job.Option == EnumerationTypes.FileNameOption.Keep) //If the Filenameoption is set to "Keep"
                            {
                                jd.OutputFilepath = job.Filepath + ".suoja"; //Just add ".suoja"
                            }
                            else
                            {
                                jd.OutputFilepath = Path.Combine(path, Convert.ToBase64String(Encoding.Default.GetBytes(job.Filepath.Split('\\').Last())) + ".suoja"); //Encode the filename in Base64, add ".suoja" and combine the new filename with the existing path
                            }
                        }
                        jd.Option = job.Option; //Set the jobs params
                        jd.Message = job.Message; //Set the jobs params
                        if (jd.ShowDialog() == DialogResult.OK) //If the user hit the "Start"-button
                        {
                            if (startJob(job)) //If the job went flawlessly
                            {
                                lvwJobs.SelectedItems[0].Group = lvwJobs.Groups[1]; //Set the group to "Finished"
                            }
                            else
                            {
                                lvwJobs.SelectedItems[0].Group = lvwJobs.Groups[2]; //Otherwise to "Error"
                            }
                        }
                        jd.Dispose(); //Cleanup
                    }
                }
            }
        }
    }
}
