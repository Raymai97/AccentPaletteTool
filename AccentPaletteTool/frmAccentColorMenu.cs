using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Win32;

namespace AccentPaletteTool
{
    public partial class frmAccentColorMenu : Form
    {
        // In build 14393, every time Explorer is restarted, it will copy the value of AccentColorMenu
        // to DWM\AccentColor, and use it as the color for title bar and window border.
        // Changing this value to change color is perfect but... you need to restart Explorer.
        //
        // If you change the value of DWM\AccentColor as well, the change can take effect immediately
        // BUT the window border color will NOT update.
        //
        // As such, this tool will write to two places at once and prompt about the border color issue.
        // At least, the change of title bar color will take effect immediately.

        readonly Color DEFAULT_ACTIVE_COLOR = Color.FromArgb(0, 120, 215);
        readonly Color DEFAULT_INACTIVE_COLOR = Color.FromArgb(0, 99, 177);
        readonly string ACCENTCOLORMENU = "AccentColorMenu";
        readonly string ACCENTCOLOR = "AccentColor";
        readonly string ACCENTCOLORINACTIVE = "AccentColorInactive";
        readonly string ACCENT_REGPATH = @"Software\Microsoft\Windows\CurrentVersion\Explorer\Accent";
        readonly string DWM_REGPATH = @"Software\Microsoft\Windows\DWM";

        public Color ColorForActiveToFollow { get; set; }

        // 0xFFAABBCC where FF is dummy, RGB is 0xCC, 0xBB, 0xAA
        Color color_from_dword(int dword)
        {
            byte r = (byte)(dword & 0xFF);
            byte g = (byte)(dword >> 8 & 0xFF);
            byte b = (byte)(dword >> 16 & 0xFF);
            return Color.FromArgb(r, g, b);
        }

        int dword_from_color(Color color)
        {
            return (color.R | color.G << 8 | color.B << 16 | 0xFF << 24);
        }

        public frmAccentColorMenu()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void frmAccentColorMenu_Load(object sender, EventArgs e)
        {
            // default...
            pActive.BackColor = DEFAULT_ACTIVE_COLOR;
            pInactive.BackColor = DEFAULT_INACTIVE_COLOR;
            chkInactiveEnabled.Checked = false;
            btnInactiveDefault.Hide();
            pInactive.Hide();
            // try load...
            try
            {
                var accent_key = Registry.CurrentUser.OpenSubKey(ACCENT_REGPATH);
                if (accent_key.GetValueKind(ACCENTCOLORMENU) == RegistryValueKind.DWord)
                {
                    var val = (int)accent_key.GetValue(ACCENTCOLORMENU);
                    if (val != 0) { pActive.BackColor = color_from_dword(val); }
                }
                var dwm_key = Registry.CurrentUser.OpenSubKey(DWM_REGPATH);
                if (dwm_key.GetValueKind(ACCENTCOLORINACTIVE) == RegistryValueKind.DWord)
                {
                    var val = (int)dwm_key.GetValue(ACCENTCOLORINACTIVE);
                    if (val != 0) { pInactive.BackColor = color_from_dword(val); }
                    chkInactiveEnabled.Checked = true;
                }
            }
            catch (Exception){}
        }

        private void colorPanel_MouseClick(object sender, MouseEventArgs e)
        {
            Panel p = (Panel)sender;
            Program.colorDlg.Color = p.BackColor;
            Program.colorDlg.FullOpen = true;
            if (Program.colorDlg.ShowDialog() == DialogResult.OK)
            {
                p.BackColor = Program.colorDlg.Color;
            }
        }

        private void btnActiveDefault_Click(object sender, EventArgs e)
        {
            pActive.BackColor = DEFAULT_ACTIVE_COLOR;
        }

        private void btnActiveFollow_Click(object sender, EventArgs e)
        {
            pActive.BackColor = ColorForActiveToFollow;
        }

        private void btnInactiveDefault_Click(object sender, EventArgs e)
        {
            pInactive.BackColor = DEFAULT_INACTIVE_COLOR;
        }

        private void chkInactiveEnabled_CheckedChanged(object sender, EventArgs e)
        {
            btnInactiveDefault.Visible = pInactive.Visible = chkInactiveEnabled.Checked;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var accent_key = Registry.CurrentUser.OpenSubKey(ACCENT_REGPATH, true);
            accent_key.SetValue(ACCENTCOLORMENU,
                dword_from_color(pActive.BackColor),
                RegistryValueKind.DWord);
            var dwm_key = Registry.CurrentUser.OpenSubKey(DWM_REGPATH, true);
            dwm_key.SetValue(ACCENTCOLOR,
                dword_from_color(pActive.BackColor),
                RegistryValueKind.DWord);
            if (chkInactiveEnabled.Checked)
            {
                dwm_key.SetValue(ACCENTCOLORINACTIVE,
                    dword_from_color(pInactive.BackColor),
                    RegistryValueKind.DWord);
            }
            else { dwm_key.DeleteValue(ACCENTCOLORINACTIVE, false); }
            DWM.Refresh();
            MessageBox.Show(
                    "To fully take effect, please restart Explorer.",
                    "OK!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            Close();
        }



    }
}
