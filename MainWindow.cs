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

        public MainWindow()
        {
            InitializeComponent();
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

        private void addJob(string filepath, string keypath, AddJobDialog.JobAction action, AddJobDialog.KeySource source, FilenameOptionDialog.Filenameoption option)
        {
            SuojaJob job = new SuojaJob(filepath, keypath, action, source, option); //Initialize a new job
            job.Status = SuojaJob.JobStatus.Queued;
            Jobs.Add(job); //Add the job
            ListViewItem lvi = new ListViewItem(); //Create a new ListViewItem
            lvi.Group = lvwJobs.Groups[0]; //Group set to "waiting"
            lvi.Text = filepath; //Display the filepath
            if (action == AddJobDialog.JobAction.Decrypt) { lvi.SubItems.Add("Entschlüsseln"); } else { lvi.SubItems.Add("Verschlüsseln"); } //Display either "Encrypt" or "Decrypt"
            if (source == AddJobDialog.KeySource.File) { lvi.SubItems.Add(keypath); } else { lvi.SubItems.Add("Neu"); } //Display either the Keyfilepath or "New"
            if (option == FilenameOptionDialog.Filenameoption.Keep) { lvi.SubItems.Add("Unverändert"); } else { lvi.SubItems.Add("Versteckt"); } //Display either "Keep" or "Encode"
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

            btnStartAll.Enabled = lvwJobs.Groups[0].Items.Count > 0;

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
                            job.Status = SuojaJob.JobStatus.Finished;
                        }
                        else
                        {
                            lvi.Group = lvwJobs.Groups[2]; //Otherwise to "Error"
                            job.Status = SuojaJob.JobStatus.Failed;
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

            if (job.Action == AddJobDialog.JobAction.Encrypt) //If the job is an Encryption
            {
                string outputPath;
                if (job.Source == AddJobDialog.KeySource.File) //If the job uses an existing Key and IV
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
                if (job.Option == FilenameOptionDialog.Filenameoption.Keep) //If the Filenameoption is set to "Keep"
                {
                    outputPath = job.Filepath + ".suoja"; //Just add ".suoja"
                }
                else
                {
                    string path = job.Filepath.Substring(0, job.Filepath.Length - job.Filepath.Split('\\').Last().Length); //Otherwise split the Filepath into path and filename
                    outputPath = Path.Combine(path, Convert.ToBase64String(Encoding.Default.GetBytes(job.Filepath.Split('\\').Last())) + ".suoja"); //Encode the filename in Base64, add ".suoja" and combine the new filename with the existing path
                }
                job.OutputPath = outputPath; //Set the Output path

                JobRunningPopup jrp = new JobRunningPopup();
                new Thread(delegate ()
                {
                    jrp.ShowDialog();
                }).Start();

                bool result = Provider.Encrypt(job.Filepath, outputPath);
                File.Delete(outputPath + ".data");
                File.Delete(outputPath + ".hmac");

                if (result)
                {
                    job.Status = SuojaJob.JobStatus.Finished;
                }
                else
                {
                    job.Status = SuojaJob.JobStatus.Failed;
                }
                jrp.Invoke(new EventHandler(delegate { jrp.Close(); }));
                job.Done = result; //Set the result
                return result; //Return it
            }
            else //The job is a Decryption
            {
                string outputPath;
                string path = job.Filepath.Substring(0, job.Filepath.Length - job.Filepath.Split('\\').Last().Length); //Split the Filepath intp path and filename
                CryptographicData = JsonConvert.DeserializeObject<SuojaCryptographicData>(File.ReadAllText(job.Keypath)); //Load the Key and IV
                Provider = new SuojaProvider(CryptographicData); //Initialize the Provider with the Key and IV
                if (job.Filepath.Split('\\').Last().Split('.').Length == 2) //If the filename contains only 1 dot (.) it is a Base64-encoded string
                {
                    outputPath = Path.Combine(path, Encoding.Default.GetString(Convert.FromBase64String(job.Filepath.Split('\\').Last().Remove(job.Filepath.Split('\\').Last().Length - 6, 6)))); //Therefore remove the ".suoja", decode the filename from Base64 and combine the result with the existing path
                }
                else
                {
                    outputPath = job.Filepath.Remove(job.Filepath.Length - 6, 6); //Otherwise just remove the ".suoja"
                }

                JobRunningPopup jrp = new JobRunningPopup();
                new Thread(delegate ()
                {
                    jrp.ShowDialog();
                }).Start();
                
                bool result = Provider.Decrypt(job.Filepath, outputPath); //Store the jobs result
                File.Delete(job.Filepath + ".data");
                File.Delete(job.Filepath + ".hmac");
                if (result)
                {
                    job.Status = SuojaJob.JobStatus.Finished;
                }
                else
                {
                    job.Status = SuojaJob.JobStatus.Failed;
                }

                jrp.Invoke(new EventHandler(delegate { jrp.Close(); }));
                job.Done = result; //Set the result
                return result; //Return it
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
            DragDropDialog.HandleMethod Method = DragDropDialog.HandleMethod.Individual; //Define Individual as standard
            if (data.GetFileDropList().Count > 1) //If multiple files are dropped
            {
                DragDropDialog ddd = new DragDropDialog(); //Show a new DragDropDialog
                if (ddd.ShowDialog() == DialogResult.OK) //If the user hit "OK"
                {
                    Method = ddd.Method; //Set the Method to the method the user chose
                }
                ddd.Dispose(); //Cleanup

                if (Method == DragDropDialog.HandleMethod.Compress) //If the user chose to compress the files
                {
                    string[] files = new string[data.GetFileDropList().Count]; //Copy the filepaths to a string array
                    data.GetFileDropList().CopyTo(files, 0);
                    SaveFileDialog sfd = new SaveFileDialog(); //Show a new SafeFileDialog
                    sfd.Filter = "Archiv (*.zip)|*.zip"; //Only allow ".zip" as extension
                    sfd.Title = "Archiv speichern unter...";
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
                else if (Method == DragDropDialog.HandleMethod.Individual) //If the user chose to handle each file individually
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
                            if (filepath.Substring(filepath.Length - 5, 5) != "suoja" && ajd2.Action == AddJobDialog.JobAction.Decrypt) //If the user want's to decrypt files but the actual file isn't considered encrypted
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
                        JobDetails jd = new JobDetails();
                        jd.OriginalFilepath = job.Filepath;
                        jd.KeyFilepath = job.Keypath;
                        jd.Status = job.Status;
                        jd.Action = job.Action;
                        string path = job.Filepath.Substring(0, job.Filepath.Length - job.Filepath.Split('\\').Last().Length); //Otherwise split the Filepath into path and filename
                        if (job.Action == AddJobDialog.JobAction.Decrypt)
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
                            if (job.Option == FilenameOptionDialog.Filenameoption.Keep) //If the Filenameoption is set to "Keep"
                            {
                                jd.OutputFilepath = job.Filepath + ".suoja"; //Just add ".suoja"
                            }
                            else
                            {
                                jd.OutputFilepath = Path.Combine(path, Convert.ToBase64String(Encoding.Default.GetBytes(job.Filepath.Split('\\').Last())) + ".suoja"); //Encode the filename in Base64, add ".suoja" and combine the new filename with the existing path
                            }
                        }
                        jd.Option = job.Option;
                        jd.Message = job.Message;
                        if (jd.ShowDialog() == DialogResult.OK)
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
                        jd.Dispose();
                    }
                }
            }
        }
    }
}
