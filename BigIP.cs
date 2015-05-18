using System;
using System.Drawing;
using System.Net;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace BigIP
{
    public partial class BigIP : Form
    {
        private System.Timers.Timer timer = new System.Timers.Timer(60000);
        delegate void CloseForm();

        static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        static readonly IntPtr HWND_NOTOPMOST = new IntPtr(-2);
        static readonly IntPtr HWND_TOP = new IntPtr(0);
        static readonly IntPtr HWND_BOTTOM = new IntPtr(1);
        const uint SWP_NOSIZE = 0x0001;
        const uint SWP_NOMOVE = 0x0002;
        const uint TOPMOST_FLAGS = SWP_NOMOVE | SWP_NOSIZE;

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        public BigIP()
        {
            InitializeComponent();
            Address.Text = GetIPAddress();
            this.Size = new Size(Address.Width - 19, Address.Height - 4);
            this.Location = new Point(GetCornerScreen().X - this.Width, GetCornerScreen().Y);
            timer.Elapsed += TimerElapsed;
            timer.Start();
            SetWindowPos(this.Handle, HWND_TOPMOST, 0, 0, 0, 0, TOPMOST_FLAGS);
        }

        void TimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (this.InvokeRequired)
            {
                CloseForm c = new CloseForm(this.Close);
                this.Invoke(c, new object[] { });
            }
            else
            {
                this.Close();
            }
        }
        private Point GetCornerScreen()
        {
            return new Point(Screen.PrimaryScreen.Bounds.Right, Screen.PrimaryScreen.Bounds.Top);
        }
        private bool IsConnected()
        {
            return System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();
        }
        private string GetIPAddress()
        {
            if (!IsConnected())
            {
                return "Failed";
            }
            else
            {
                IPHostEntry host;
                string localIP = "Failed";
                try
                {
                    host = Dns.GetHostEntry(Dns.GetHostName());
                    foreach (IPAddress ip in host.AddressList)
                    {
                        if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        {
                            localIP = ip.ToString().Split('.')[2] + '.' + ip.ToString().Split('.')[3];
                            break;
                        }
                    }
                } catch (Exception)
                {
                    return "Failed";
                }
                return localIP;
            }
        }

        private void BigIP_DoubleClick(object sender, EventArgs e)
        {
            AboutBox about = new AboutBox();
            about.ShowDialog();
        }

        private void Address_DoubleClick(object sender, EventArgs e)
        {
            AboutBox about = new AboutBox();
            about.ShowDialog();
        }
    }
}