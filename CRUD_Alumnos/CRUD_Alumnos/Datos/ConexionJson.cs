using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class ConexionJson
    {
        public string server;
        public int port;
        public string user;
        public string password;
        public string db;

        public string Server
        {
            get
            {
                return server;
            }

            set
            {
                server = value;
            }
        }

        public int Port
        {
            get
            {
                return port;
            }

            set
            {
                port = value;
            }
        }

        public string User
        {
            get
            {
                return user;
            }

            set
            {
                user = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
        }

        public string Db
        {
            get
            {
                return db;
            }

            set
            {
                db = value;
            }
        }
    }
}
