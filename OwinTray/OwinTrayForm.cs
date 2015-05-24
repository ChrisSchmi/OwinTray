using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// by CSC
using System.Web.Http;
using Microsoft.Owin.Hosting;
using System.Net.Http;
using ApiHostLibrary;

namespace OwinTray
{
    public partial class OwinTrayForm : Form
    {
        private ApiHost _myApi;

        public OwinTrayForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_myApi != null)
            {
                textBox1.Text = _myApi.Testquery();
            }
        }

        private void OwinTrayForm_Load(object sender, EventArgs e)
        {
            CreateIcon();
            _myApi = new ApiHost(9000);
        }

        private void OwinTrayForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Really wanna quit?","OWIN Tray Application", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                notifyIcon.Visible = false;
            }
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
        }

        private void CreateIcon()
        {
            using (var b = new Bitmap(64, 64))
            {
                using (var g = Graphics.FromImage(b))
                {
                    g.FillRectangle(new SolidBrush(Color.Red), 0, 0, 64, 64);
                    IntPtr Hicon = b.GetHicon();
                    Icon newIcon = Icon.FromHandle(Hicon);
                    notifyIcon.Icon = newIcon;
                }
            }
        }
    }
}
