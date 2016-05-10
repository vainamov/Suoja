using System.Diagnostics;
using System.Windows.Forms;

namespace Suoja
{
    public partial class AboutDialog : Form
    {
        public AboutDialog()
        {
            InitializeComponent();
        }

        private void llblTwitter_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://twitter.com/vainamov");
        }

        private void llblFestival_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://festival.ml/");
        }

        private void llblJson_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://www.newtonsoft.com/json");
        }

        private void llblIcon_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.iconfinder.com/icons/532631/insurance_protection_safe_safety_secure_security_shield_icon");
        }

        private void llblZip_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://dotnetzip.codeplex.com/");
        }
    }
}
