using Newtonsoft.Json;
using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProcessKill
{
    public partial class Form1 : Form
    {
        public BackgroundWorker bg = new BackgroundWorker();
        public System.Timers.Timer zamanlama;
        public bool durdur = false;
        public  string AppDir = Directory.GetParent(Application.ExecutablePath).ToString() + "\\";
        public SSHIslemleri ssh;
        public string secilenProcess = "";
        public Form1()
        {
            InitializeComponent();
            Form1.CheckForIllegalCrossThreadCalls = false;
        }

        private void btnBasla_Click(object sender, EventArgs e)
        {
            if (btnBasla.Text == "Stop")
            {
                durdur = true;
                btnBasla.Text = "Start";
                zamanlama.Stop();
                zamanlama.Enabled = false;
            }
            else
            {
                durdur = false;
                if (txtUsername.Text == "" || txtPassword.Text == "")
                {
                    MessageBox.Show("Do not leave information blank");
                }
                else
                {
                    if (listProcess.SelectedItem==null)
                    {
                        MessageBox.Show("Select Process.");
                    }else {
                        secilenProcess = listProcess.Items[listProcess.SelectedIndex].ToString().Trim();
                        VeriOkumayaBasla();
                        /*
                        if (bg.IsBusy != true)
                        {
                            bg.RunWorkerAsync();
                        }
                        */
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ssh = new SSHIslemleri();
            bg.DoWork += Bg_DoWork;
        }



        private void Bg_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            if ((worker.CancellationPending == true))
            {
                e.Cancel = true;
            }
            else
            {
                System.Threading.Thread.Sleep(500);
            }

            Thread newThread = new Thread(VeriOkumayaBasla);
            newThread.IsBackground = true;
            newThread.Start();
            newThread.Join();
        }

        private void VeriOkumayaBasla()
        {
            int saniye = 0;
            int gelen = Int32.Parse(txtZaman.Text);

            switch (cmbTur.Text)
            {
                case "Hour":
                    saniye = gelen * 3600;
                    break;
                case "Minute":
                    saniye = gelen * 60;
                    break;
                default:
                    saniye = gelen;
                    break;
            }

            btnBasla.Text = "Stop";

            zamanlama = new System.Timers.Timer();
            zamanlama.Enabled = true;
            zamanlama.Interval = saniye*1000;
            zamanlama.Elapsed += Zamanlama_Elapsed;
            zamanlama.Start();

        }

        private void Zamanlama_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (durdur)
            {
                zamanlama.Enabled = false;
                zamanlama.Stop();
            }
            else
            {
                using (SshClient ssh = new SshClient(CreateConnectionInfo()))
                {
                    ssh.Connect();
                    var hostnameCommand = ssh.RunCommand("get system status");
                    string hostname = GetHostName(hostnameCommand.Result);
                    var status = ssh.RunCommand("fnsysctl cat /var/run/"+ secilenProcess+".pid");
                    string komut = status.Result;
                    string pid = komut.Replace(hostname + " #", "").Trim();
                    var kill = ssh.RunCommand("dia sys kill 1 " + pid);
                    ssh.Disconnect();
                    getProcessList(pid);
                }
            }
        }

        private string GetHostName(string result)
        {
            string[] lines = result.Split('\n');
            string hostname = "";
            foreach (string item in lines)
            {
                string metin = item.Replace("--More--", "");
                string[] bol = metin.Split(':');
                if (bol[0].Trim().ToLower() == "hostname")
                {
                    hostname = bol[1].Trim();
                }
            }

            return hostname;
        }

        private void DosyayaKaydet(string status)
        {
            //string sonuc = JsonConvert.SerializeObject(status);
            StreamWriter stream = new StreamWriter(AppDir+"sonuc.txt", false);
            stream.Write(status);
            stream.Close();
            stream.Dispose();
        }

        private void getProcessList(string result)
        {
            lblSonuc.Text = secilenProcess+":" + result + " terminated.";
        }

        private ConnectionInfo CreateConnectionInfo()
        {
            AuthenticationMethod auth = new PasswordAuthenticationMethod(txtUsername.Text, txtPassword.Text);
            ConnectionInfo info = new ConnectionInfo(txtIP.Text,Int32.Parse(txtPort.Text), txtUsername.Text, auth);
            return info;
        }

        private void btnGetProcess_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Do not leave information blank");
            }
            else
            {
                string pattern = @"([a-z0-9_\.]{1,20}\.pid)";
                RegexOptions options = RegexOptions.Multiline;
                ssh.ip = txtIP.Text;
                ssh.username = txtUsername.Text;
                ssh.password = txtPassword.Text;
                ssh.port = Int32.Parse(txtPort.Text);
                string sonuc = ssh.TumProcessler();
                //DosyayaKaydet(sonuc);
                listProcess.Items.Clear();
                foreach (Match m in Regex.Matches(sonuc, pattern, options))
                {
                    listProcess.Items.Add(m.Value.Split('.')[0]);
                }

                lblSonuc.Text = "Processes received";
            }
        }

        private void listProcess_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listProcess.SelectedItem != null)
                btnBasla.Enabled = true;
        }
    }
}
