using System;
using System.Collections.Generic;
using System.Text;

namespace WebAppBasite.Common.WebLibs
{
    public class ProxyInfo
    {
        public string Username
        {
            get;
            set;
        }

        public string Password
        {
            get;
            set;
        }

        public string Server
        {
            get;
            set;
        }

        public int Port
        {
            get;
            set;
        }

        public ProxyInfo(string server, int port, string username, string password)
        {
            this.Username = username;
            this.Password = password;
            this.Server = server;
            this.Port = port;
        }
    }
}
