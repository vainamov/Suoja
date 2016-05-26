using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Suoja
{
    public partial class AddJobDialog : Form
    {
        public string Filepath { get; set; }
        public string Keypath { get; set; }
        public EnumerationTypes.JobAction Action { get; set; }
        public EnumerationTypes.KeySource Source { get; set; }
        public EnumerationTypes.FileNameOption Option { get; set; }

        public bool AllowBrowsing { get; set; }
        public bool KeyFileOnly { get; set; }

        public AddJobDialog()
        {
            InitializeComponent();
            /* Set all default settings */
            Option = EnumerationTypes.FileNameOption.Keep; 
            AllowBrowsing = true;
            KeyFileOnly = false;
        }

        private void btnChooseFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog(); //Initialize a new open file dialog
            if (Action == EnumerationTypes.JobAction.Decrypt)
            {
                ofd.Filter = "Verschlüsselte Dateien (*.suoja)|*.suoja"; //As the file should be decrypted, only allow files ending in ".suoja"
            }
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                tbxFilepath.Text = ofd.FileName; //Show the Filename
                Filepath = ofd.FileName; //And store it
                if (Action == EnumerationTypes.JobAction.Decrypt && Filepath.Substring(Filepath.Length - 5, 5) != "suoja") //If the user however still managed to combine a not-encrypted file with Decryption
                {
                    MessageBox.Show("Die ausgewählte Datei endet nicht auf .suoja und wird daher als unverschlüsselt angesehen.", "Suoja", MessageBoxButtons.OK, MessageBoxIcon.Warning); //Inform the user
                    rbtActionEncrypt.Checked = true; //Automatically switch to Encryption
                }
                if (Action == EnumerationTypes.JobAction.Decrypt)
                {
                    if (Filepath.Split('\\').Last().Split('.').Length == 2) //If the Filename contains only 1 dot (.) it is an encoded filename
                    {
                        lblOriginal.Text = Encoding.Default.GetString(Convert.FromBase64String(Filepath.Split('\\').Last().Remove(Filepath.Split('\\').Last().Length - 6, 6))); //Therefore remove the ".suoja" at the end and decode the filename
                    }
                    else
                    {
                        lblOriginal.Text = Filepath.Split('\\').Last().Remove(Filepath.Split('\\').Last().Length - 6, 6); //Otherwise just remove the ".suoja"
                    }
                }
                else
                {
                    if (Option == EnumerationTypes.FileNameOption.Keep) //If the filename should stay readable after Encryption
                    {
                        lblOriginal.Text = Filepath.Split('\\').Last() + ".suoja"; //Just add ".suoja"
                    }
                    else
                    {
                        lblOriginal.Text = Convert.ToBase64String(Encoding.Default.GetBytes(Filepath.Split('\\').Last())) + ".suoja"; //Otherwise encode the filename and add ".suoja" afterwards
                    }
                }
            }
            ofd.Dispose(); //Cleanup
            enableAddButton(); //Enable the "Confirm"-button if possible
        }

        private void rbtActionEncrypt_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtActionEncrypt.Checked) //Encryption is selected
            {
                Action = EnumerationTypes.JobAction.Encrypt; //Set the Action to Encryption
                rbtKeyNew.Enabled = lblKeyNewDesc.Enabled = btnChooseFileNameOption.Enabled = !KeyFileOnly; //Determine if the option "New Key" and "Choose Filenameoption" are enabled
                rbtKeyNew.Checked = true; //Directly set "New Key" as standard to prevent problems
                rbtKeyFromFile.Checked = KeyFileOnly; //Select "Key from File" if only "Key from File" is possible
            }
            else
            {
                Action = EnumerationTypes.JobAction.Decrypt; //Set the Action to Decryption
                rbtKeyNew.Enabled = lblKeyNewDesc.Enabled = btnChooseFileNameOption.Enabled = false; //These options aren't available when decrypting
                rbtKeyFromFile.Checked = true; //Hence "Key from File" is the only option so directly select it
                if (Filepath != null && Filepath.Length > 7) //Exception Prevention
                {
                    if (Filepath.Substring(Filepath.Length - 5, 5) != "suoja" && !KeyFileOnly) //The user again managed to combine an not-encrypted file with Decryption
                    {
                        MessageBox.Show("Die ausgewählte Datei endet nicht auf .suoja und wird daher als unverschlüsselt angesehen.", "Suoja", MessageBoxButtons.OK, MessageBoxIcon.Warning); //Inform the user
                        rbtActionEncrypt.Checked = true; //Automatically switch to Encryption
                    }
                }
            }
            /* Preview for Filenames */
            if (Filepath != null && !KeyFileOnly) //Exception Prevention
            {
                if (Action == EnumerationTypes.JobAction.Decrypt)
                {
                    if (Filepath.Split('\\').Last().Split('.').Length == 2) //If the Filename contains only 1 dot (.) it is an encoded filename
                    {
                        lblOriginal.Text = Encoding.Default.GetString(Convert.FromBase64String(Filepath.Split('\\').Last().Remove(Filepath.Split('\\').Last().Length - 6, 6))); //Therefore remove the ".suoja" at the end and decode the filename
                    }
                    else
                    {
                        lblOriginal.Text = Filepath.Split('\\').Last().Remove(Filepath.Split('\\').Last().Length - 6, 6); //Otherwise just remove the ".suoja"
                    }
                }
                else
                {
                    if (Option == EnumerationTypes.FileNameOption.Keep) //If the filename should stay readable after Encryption
                    {
                        lblOriginal.Text = Filepath.Split('\\').Last() + ".suoja"; //Just add ".suoja"
                    }
                    else
                    {
                        lblOriginal.Text = Convert.ToBase64String(Encoding.Default.GetBytes(Filepath.Split('\\').Last())) + ".suoja"; //Otherwise encode the filename and add ".suoja" afterwards
                    }
                }
            }
            enableAddButton(); //Enable the "Confirm"-button if possible
        }

        private void rbtKeyFromFile_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtKeyFromFile.Checked)
            {
                Source = EnumerationTypes.KeySource.File; //Set Source to "From File"
            }
            else
            {
                Source = EnumerationTypes.KeySource.New; //Set Source to "New Key"
            }
            Keypath = null; //Forces the user to reselect the filepath after switching Source-modes
            btnChooseKey.Enabled = rbtKeyFromFile.Checked; //Obviously choosing the particular key is only neccessary when selecting "From File"...
            btnChooseKeySave.Enabled = rbtKeyNew.Checked; //...as saving a key is only neccessary when selecting "New Key"
            enableAddButton(); //Enable the "Confirm"-button if possible
        }

        private void btnChooseKey_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog(); //Initialize a new open file dialog
            ofd.Filter = "Schlüssel (*.suojadata)|*.suojadata"; //Set the filter for key files
            if (ofd.ShowDialog() == DialogResult.OK) //If the user hit "OK"
            {
                if (isValidKeyFile(ofd.FileName)) //Check if the file is a valid key file
                {
                    Keypath = ofd.FileName; //Store the path
                }
                else
                {
                    MessageBox.Show("Die ausgewählte Datei ist kein gültiger Schlüssel.", "Suoja", MessageBoxButtons.OK, MessageBoxIcon.Error); //Otherwise inform the user
                }
            }
            ofd.Dispose(); //Cleanup
            enableAddButton(); //Enable the "Confirm"-button if possible
        }

        private void btnChooseKeySave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog(); //Initialize a new save file dialog
            sfd.Filter = "Schlüssel (*.suojadata)|*.suojadata"; //Set the filter for key files
            if (sfd.ShowDialog() == DialogResult.OK) //If the user hit "OK"
            {
                Keypath = sfd.FileName; //Store the path
            }
            sfd.Dispose(); //Cleanup
            enableAddButton(); //Enable the "Confirm"-button if possible
        }

        private bool isValidKeyFile(string filepath)
        {
            try
            {
                SuojaCryptographicData isValid = JsonConvert.DeserializeObject<SuojaCryptographicData>(File.ReadAllText(filepath)); //Try to create a CryptographicData object by deserializing the given file
                return true; //If it worked, the file is a valid key file
            }
            catch
            {
                return false; //Otherwise not
            }
        }

        private void enableAddButton()
        {

            btnAdd.Enabled = (Filepath != null && Keypath != null); //Enable the "Confirm"-button, if a filepath and a keypath is chosen
        }

        private void btnChooseFileNameOption_Click(object sender, EventArgs e)
        {
            FilenameOptionDialog fod = new FilenameOptionDialog(); //Initialize a new FilenameOptionDialog
            fod.Option = Option; //Preset the present option
            if (fod.ShowDialog() == DialogResult.OK) //If the user hit "OK"
            {
                Option = fod.Option; //Set the new option
                if (Filepath != null) //If the user has already selected a file
                {
                    /* Preview the filename */
                    if (Option == EnumerationTypes.FileNameOption.Keep)
                    {
                        lblOriginal.Text = Filepath.Split('\\').Last() + ".suoja"; //The user wants the filename to stay readable so just add ".suoja"
                    }
                    else
                    {
                        lblOriginal.Text = Convert.ToBase64String(Encoding.Default.GetBytes(Filepath.Split('\\').Last())) + ".suoja"; //Otherwise encode the filename and add ".suoja" afterwards
                    }
                }
            }
            fod.Dispose(); //Cleanup
        }

        private void AddJobDialog_Shown(object sender, EventArgs e)
        {
            if (Filepath != null) //Exception Prevention
            {
                tbxFilepath.Text = Filepath; //Display the preselected filepath
                /* Preview the filename */
                if (Action == EnumerationTypes.JobAction.Decrypt)
                {
                    if (Filepath.Split('\\').Last().Split('.').Length == 2) //If the Filename contains only 1 dot (.) it is an encoded filename
                    {
                        lblOriginal.Text = Encoding.Default.GetString(Convert.FromBase64String(Filepath.Split('\\').Last().Remove(Filepath.Split('\\').Last().Length - 6, 6))); //Therefore remove the ".suoja" at the end and decode the filename
                    }
                    else
                    {
                        lblOriginal.Text = Filepath.Split('\\').Last().Remove(Filepath.Split('\\').Last().Length - 6, 6); //Otherwise just remove the ".suoja"
                    }
                }
                else
                {
                    if (Option == EnumerationTypes.FileNameOption.Keep) //If the filename should stay readable after Encryption
                    {
                        lblOriginal.Text = Filepath.Split('\\').Last() + ".suoja"; //Just add ".suoja"
                    }
                    else
                    {
                        lblOriginal.Text = Convert.ToBase64String(Encoding.Default.GetBytes(Filepath.Split('\\').Last())) + ".suoja"; //Otherwise encode the filename and add ".suoja" afterwards
                    }
                }
            }
            btnChooseFile.Enabled = AllowBrowsing; //Determine whether browsing for a file is allowed and en- or disable the "Choose File"-button accordingly
            rbtKeyNew.Enabled = lblKeyNewDesc.Enabled = btnChooseKeySave.Enabled = lblOriginal.Visible = !KeyFileOnly; //Disable or hide "New Key" options, if only "From File" is allowed
            rbtKeyFromFile.Checked = KeyFileOnly; //Automatically select "From File" if "From File" is the only possible option
        }
    }
}
