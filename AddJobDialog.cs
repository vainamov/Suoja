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

        public enum JobAction
        {
            Encrypt,
            Decrypt
        }

        public enum KeySource
        {
            New,
            File
        }

        public string Filepath { get; set; }
        public string Keypath { get; set; }
        public JobAction Action { get; set; }
        public KeySource Source { get; set; }
        public FilenameOptionDialog.Filenameoption Option { get; set; }

        public bool AllowBrowsing { get; set; }
        public bool KeyFileOnly { get; set; }

        public AddJobDialog()
        {
            InitializeComponent();
            Option = FilenameOptionDialog.Filenameoption.Keep;
            AllowBrowsing = true;
            KeyFileOnly = false;
        }

        private void btnChooseFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (Action == JobAction.Decrypt)
            {
                ofd.Filter = "Verschlüsselte Dateien (*.suoja)|*.suoja";
            }
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                tbxFilepath.Text = ofd.FileName;
                Filepath = ofd.FileName;
                if (Action == JobAction.Decrypt && Filepath.Substring(Filepath.Length - 5, 5) != "suoja")
                {
                    MessageBox.Show("Die ausgewählte Datei endet nicht auf .suoja und wird daher als unverschlüsselt angesehen.", "Suoja", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    rbtActionEncrypt.Checked = true;
                }
                if (Action == JobAction.Decrypt)
                {
                    if (Filepath.Split('\\').Last().Split('.').Length == 2)
                    {
                        lblOriginal.Text = Encoding.Default.GetString(Convert.FromBase64String(Filepath.Split('\\').Last().Remove(Filepath.Split('\\').Last().Length - 6, 6)));
                    }
                    else
                    {
                        lblOriginal.Text = Filepath.Split('\\').Last().Remove(Filepath.Split('\\').Last().Length - 6, 6);
                    }
                }
                else
                {
                    if (Option == FilenameOptionDialog.Filenameoption.Keep)
                    {
                        lblOriginal.Text = Filepath.Split('\\').Last() + ".suoja";
                    }
                    else
                    {
                        lblOriginal.Text = Convert.ToBase64String(Encoding.Default.GetBytes(Filepath.Split('\\').Last())) + ".suoja";
                    }
                }
            }
            ofd.Dispose();
            enableAddButton();
        }

        private void rbtActionEncrypt_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtActionEncrypt.Checked)
            {
                Action = JobAction.Encrypt;
                rbtKeyNew.Enabled = lblKeyNewDesc.Enabled = btnChooseFilenameoption.Enabled = !KeyFileOnly;
                rbtKeyNew.Checked = true;
                rbtKeyFromFile.Checked = KeyFileOnly;
            }
            else
            {
                Action = JobAction.Decrypt;
                rbtKeyNew.Enabled = lblKeyNewDesc.Enabled = btnChooseFilenameoption.Enabled = false;
                rbtKeyFromFile.Checked = true;
                if (Filepath != null && Filepath.Length > 7)
                {
                    if (Filepath.Substring(Filepath.Length - 5, 5) != "suoja" && !KeyFileOnly)
                    {
                        MessageBox.Show("Die ausgewählte Datei endet nicht auf .suoja und wird daher als unverschlüsselt angesehen.", "Suoja", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        rbtActionEncrypt.Checked = true;
                    }
                }
            }
            if (Filepath != null && !KeyFileOnly)
            {
                if (Action == JobAction.Decrypt)
                {
                    if (Filepath.Split('\\').Last().Split('.').Length == 2)
                    {
                        lblOriginal.Text = Encoding.Default.GetString(Convert.FromBase64String(Filepath.Split('\\').Last().Remove(Filepath.Split('\\').Last().Length - 6, 6)));
                    }
                    else
                    {
                        lblOriginal.Text = Filepath.Split('\\').Last().Remove(Filepath.Split('\\').Last().Length - 6, 6);
                    }
                }
                else
                {
                    if (Option == FilenameOptionDialog.Filenameoption.Keep)
                    {
                        lblOriginal.Text = Filepath.Split('\\').Last() + ".suoja";
                    }
                    else
                    {
                        lblOriginal.Text = Convert.ToBase64String(Encoding.Default.GetBytes(Filepath.Split('\\').Last())) + ".suoja";
                    }
                }
            }
            enableAddButton();
        }

        private void rbtKeyFromFile_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtKeyFromFile.Checked)
            {
                Source = KeySource.File;
            }
            else
            {
                Source = KeySource.New;
            }
            Keypath = null;
            btnChooseKey.Enabled = rbtKeyFromFile.Checked;
            btnChooseKeySave.Enabled = rbtKeyNew.Checked;
            enableAddButton();
        }

        private void btnChooseKey_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Schlüssel (*.suojadata)|*.suojadata";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (isValidKeyFile(ofd.FileName))
                {
                    Keypath = ofd.FileName;
                }
                else
                {
                    MessageBox.Show("Die ausgewählte Datei ist kein gültiger Schlüssel.", "Suoja", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            ofd.Dispose();
            enableAddButton();
        }

        private void btnChooseKeySave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Schlüssel (*.suojadata)|*.suojadata";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Keypath = sfd.FileName;
            }
            sfd.Dispose();
            enableAddButton();
        }

        private bool isValidKeyFile(string filepath)
        {
            try
            {
                SuojaCryptographicData isValid = JsonConvert.DeserializeObject<SuojaCryptographicData>(File.ReadAllText(filepath));
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void enableAddButton()
        {

            btnAdd.Enabled = (Filepath != null && Keypath != null);
        }

        private void btnChooseFilenameoption_Click(object sender, EventArgs e)
        {
            FilenameOptionDialog fod = new FilenameOptionDialog();
            fod.Option = Option;
            if (fod.ShowDialog() == DialogResult.OK)
            {
                Option = fod.Option;
                if (Filepath != null)
                {
                    if (Option == FilenameOptionDialog.Filenameoption.Keep)
                    {
                        lblOriginal.Text = Filepath.Split('\\').Last() + ".suoja";
                    }
                    else
                    {
                        lblOriginal.Text = Convert.ToBase64String(Encoding.Default.GetBytes(Filepath.Split('\\').Last())) + ".suoja";
                    }
                }
            }
            fod.Dispose();
        }

        private void AddJobDialog_Shown(object sender, EventArgs e)
        {
            if (Filepath != null)
            {
                tbxFilepath.Text = Filepath;
                if (Action == JobAction.Decrypt)
                {
                    if (Filepath.Split('\\').Last().Split('.').Length == 2)
                    {
                        lblOriginal.Text = Encoding.Default.GetString(Convert.FromBase64String(Filepath.Split('\\').Last().Remove(Filepath.Split('\\').Last().Length - 6, 6)));
                    }
                    else
                    {
                        lblOriginal.Text = Filepath.Split('\\').Last().Remove(Filepath.Split('\\').Last().Length - 6, 6);
                    }
                }
                else
                {
                    if (Option == FilenameOptionDialog.Filenameoption.Keep)
                    {
                        lblOriginal.Text = Filepath.Split('\\').Last() + ".suoja";
                    }
                    else
                    {
                        lblOriginal.Text = Convert.ToBase64String(Encoding.Default.GetBytes(Filepath.Split('\\').Last())) + ".suoja";
                    }
                }
            }
            btnChooseFile.Enabled = AllowBrowsing;
            rbtKeyNew.Enabled = lblKeyNewDesc.Enabled = btnChooseKeySave.Enabled = lblOriginal.Visible = !KeyFileOnly;
            rbtKeyFromFile.Checked = KeyFileOnly;
        }
    }
}
