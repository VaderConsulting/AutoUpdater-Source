using System;
using System.Windows.Forms;
using AutoUpdaterDotNET;

namespace AutoUpdaterTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1Load(object sender, EventArgs e)
        {
            AutoUpdater.Start("http://localhost/netsparkle/AutoUpdater.NET_AppCast.xml");
        }
    }
}
