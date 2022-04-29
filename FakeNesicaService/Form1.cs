using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.Threading;

namespace FakeNesicaService
{

    public partial class Form1 : Form
    {
        CancellationTokenSource cts;

        public Form1()
        {
            //_context = SynchronizationContext.Current;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            s_gameid.Enabled = false;
            s_tenpoid.Enabled = false; ;
            s_tenponame.Enabled = false;
            s_address.Enabled = false;
            s_prefecture.Enabled = false;
            s_version.Enabled = false;
            s_img.Enabled = false;
            s_host.Enabled = false;

            cts = new CancellationTokenSource();
            await CreateTask();


        }
        public static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
        private async Task CreateTask()
        {
            //Create a progress object that can be used within the task
            Progress<string> mProgress; //you can set this to Int for ProgressBar
            //Set the Action to a function that will catch the progress sent within the task
            Action<string> progressTarget = ReportProgress;
            //Your new Progress with the included action function
            mProgress = new Progress<string>(progressTarget);

            //start your task
            PipeServer ps = new PipeServer();

            ps.cts = cts;
            ps.e_sp.s_gameid = s_gameid.Text;
            ps.e_sp.s_tenpoid = s_tenpoid.Text;
            ps.e_sp.s_tenponame = s_tenponame.Text;
            ps.e_sp.s_address = s_address.Text;
            ps.e_sp.s_prefecture = s_prefecture.Text;
            ps.e_sp.s_version = s_version.Text;
            ps.e_sp.s_img = s_img.Text;
            ps.e_sp.s_host = s_host.Text;
            ps.e_sp.s_ticket = CreateMD5(s_gameid.Text);

            string result = await ps.RunPipe(mProgress);

            MessageBox.Show(this, result);
        }

        private void ReportProgress(string message)
        {
            //typically to update a progress bar or whatever
            //this is where you Update your UI thread with text from within the Task.

            listBox1.Items.Add(message);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void s_tenpoid_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void s_host_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
