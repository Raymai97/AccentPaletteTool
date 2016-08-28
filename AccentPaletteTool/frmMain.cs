using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using Microsoft.Win32;

namespace AccentPaletteTool
{
    public partial class frmMain : Form
    {
        const long MAX_LEN_OF_APDAT = 44;
        const long MIN_LEN_OF_BIN = 0x20;

        byte[] bin;

        string binToString()
        {
            string s = "";
            for (int i = 0; i < bin.Length; i++)
            {
                s += Convert.ToString(bin[i], 16).PadLeft(2, '0').ToUpper();
                if (i < bin.Length - 1)
                {
                    s += ((i + 1) % 8 == 0) ? Environment.NewLine : " ";
                }
            }
            return s;
        }

        void binToColorPanel()
        {
            p00_02.BackColor = Color.FromArgb(bin[0x00], bin[0x01], bin[0x02]);
            p04_06.BackColor = Color.FromArgb(bin[0x04], bin[0x05], bin[0x06]);
            p08_0A.BackColor = Color.FromArgb(bin[0x08], bin[0x09], bin[0x0A]);
            p0C_0E.BackColor = Color.FromArgb(bin[0x0C], bin[0x0D], bin[0x0E]);
            p10_12.BackColor = Color.FromArgb(bin[0x10], bin[0x11], bin[0x12]);
            p14_16.BackColor = Color.FromArgb(bin[0x14], bin[0x15], bin[0x16]);
            p18_1A.BackColor = Color.FromArgb(bin[0x18], bin[0x19], bin[0x1A]);
            p1C_1E.BackColor = Color.FromArgb(bin[0x1C], bin[0x1D], bin[0x1E]);
        }

        void colorPanelToBin()
        {
            Color c;
            for (int i = 0; i < 0x1F; i += 4)
            {
                switch (i)
                {
                    case 0x00:
                        c = p00_02.BackColor;
                        break;
                    case 0x04:
                        c = p04_06.BackColor;
                        break;
                    case 0x08:
                        c = p08_0A.BackColor;
                        break;
                    case 0x0C:
                        c = p0C_0E.BackColor;
                        break;
                    case 0x10:
                        c = p10_12.BackColor;
                        break;
                    case 0x14:
                        c = p14_16.BackColor;
                        break;
                    case 0x18:
                        c = p18_1A.BackColor;
                        break;
                    case 0x1C:
                        c = p1C_1E.BackColor;
                        break;
                    default:
                        return;
                }
                bin[i + 0] = c.R;
                bin[i + 1] = c.G;
                bin[i + 2] = c.B;
            }
        }

        void LoadFromFile()
        {
            var ofd = new OpenFileDialog();
            ofd.FileName = "";
            ofd.Multiselect = false;
            ofd.Filter = "AccentPalette data|*.apdat";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                var info = new FileInfo(ofd.FileName);
                if (info.Length > MAX_LEN_OF_APDAT)
                {
                    MessageBox.Show(
                        "This is not a vaild APDAT file!",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                bin = Convert.FromBase64String(
                    File.ReadAllText(
                        ofd.FileName,
                        System.Text.Encoding.ASCII));

                binToColorPanel();
                txtAPVal.Text = binToString();

                MessageBox.Show(
                    "Loaded from file successfully!",
                    "OK!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        void SaveToFile()
        {
            var sfd = new SaveFileDialog();
            sfd.FileName = "";
            sfd.Filter = "AccentPalette data|*.apdat";
            if (sfd.ShowDialog()== DialogResult.OK)
            {
                File.WriteAllText(
                    sfd.FileName,
                    Convert.ToBase64String(bin),
                    System.Text.Encoding.ASCII);

                MessageBox.Show(
                    "Saved to file successfully!",
                    "OK!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        public frmMain()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            btnLoad.PerformClick();
            if (bin == null) Environment.Exit(1);
        }

        private void colorPanel_MouseClick(object sender, MouseEventArgs e)
        {
            Panel p = (Panel)sender;
            Program.colorDlg.Color = p.BackColor;
            Program.colorDlg.FullOpen = true;
            if (Program.colorDlg.ShowDialog() == DialogResult.OK)
            {
                p.BackColor = Program.colorDlg.Color;
                colorPanelToBin();
                txtAPVal.Text = binToString();
            }
        }

        private void tt_FIX_MouseEnter(object sender, EventArgs e)
        {
            tt.Active = false;
            tt.Active = true;
        }

        private void btnRestartExplorer_Click(object sender, EventArgs e)
        {
            var procs = System.Diagnostics.Process.GetProcessesByName("explorer");
            foreach (var p in procs)
            {
                if (Path.GetDirectoryName(p.MainModule.FileName) ==
                    Environment.GetFolderPath(Environment.SpecialFolder.Windows))
                {
                    p.Kill();
                }
            }
        }


        private void btnLoad_Click(object sender, EventArgs e)
        {
            var Key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Accent");
            var Val = Key.GetValue("AccentPalette");
            if (Val != null)
            {
                bin = (byte[])Val;
                if (bin.Length >= MIN_LEN_OF_BIN)
                {
                    txtAPVal.Text = binToString();
                    binToColorPanel();
                }
                else
                {
                    MessageBox.Show(
                        "Bad AccentPalette length!\nDid you manually modify the value before?",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    bin = null;
                }
            }
            else
            {
                MessageBox.Show(
                    "Cannot load the value of AccentPalette!\nAre you sure you're using Windows 10 build 14393?",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (bin != null)
            {
                var Key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Accent", true);
                Key.SetValue("AccentPalette", bin, RegistryValueKind.Binary);
                MessageBox.Show(
                    "Saved to registry successfully!",
                    "OK!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }
        private void btnLoad_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) LoadFromFile();
        }
        private void btnSave_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) SaveToFile();
        }
        private void btnLoad_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Apps) LoadFromFile();
        }
        private void btnSave_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Apps) SaveToFile();
        }

        private void lnkAccentColorMenu_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // By observing Win10 built-in color scheme, I found that the color of active title bar
            // is always the same as the 4th value of AccentPalette, though they can be different
            // by editing registry manually.
            Program.acmDlg.ColorForActiveToFollow = p0C_0E.BackColor;
            Program.acmDlg.ShowDialog();
        }
    }
}
