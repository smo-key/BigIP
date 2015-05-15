using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace BigIP
{
    public partial class BigIP : Form
    {
        private System.Timers.Timer timer = new System.Timers.Timer(60000);
        public BigIP()
        {
            InitializeComponent();
            this.Location = new Point(GetCornerScreen().X - this.Width, GetCornerScreen().Y);
            Address.Text = GetIPAddress();
            timer.Elapsed += TimerElapsed;
            timer.Start();
        }

        void TimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            this.Location = new Point(GetCornerScreen().X - this.Width, GetCornerScreen().Y);
            Address.Text = GetIPAddress();
        }
        public Point GetCornerScreen()
        {
            return new Point(Screen.PrimaryScreen.Bounds.Right, Screen.PrimaryScreen.Bounds.Top);
        }
        public bool IsConnected()
        {
            return System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();
        }
        public string GetIPAddress()
        {
            if (!IsConnected())
            {
                return "Not connected.";
            }
            else
            {
                IPHostEntry host;
                string localIP = "No IP.";
                host = Dns.GetHostEntry(Dns.GetHostName());
                foreach (IPAddress ip in host.AddressList)
                {
                    if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    {
                        localIP = ip.ToString();
                        break;
                    }
                }
                return localIP;
            }
        }

        private void OnActivated(object sender, EventArgs e)
        {
            this.SendToBack();
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