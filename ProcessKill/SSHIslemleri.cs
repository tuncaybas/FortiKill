using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Renci.SshNet;
namespace ProcessKill
{
    public class SSHIslemleri
    {
        public int port { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string ip { get; set; }
        internal string TumProcessler()
        {
            string sonuclar = "";
            using (SshClient ssh = new SshClient(CreateConnectionInfo()))
            {
                ssh.Connect();
                var hostnameCommand = ssh.RunCommand("get system status");
                string hostname = GetHostName(hostnameCommand.Result);
                var status = ssh.RunCommand("fnsysctl ls -al /var/run");
                sonuclar = status.Result.Replace(hostname + " #", "").Trim();
                ssh.Disconnect();
            }
            return sonuclar;
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

        private ConnectionInfo CreateConnectionInfo()
        {
            AuthenticationMethod auth = new PasswordAuthenticationMethod(username, password);
            ConnectionInfo info = new ConnectionInfo(ip, port, username, auth);
            return info;
        }

    }
}
