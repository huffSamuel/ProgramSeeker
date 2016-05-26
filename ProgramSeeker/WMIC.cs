using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Management;
using System.Windows.Forms;

namespace ProgramSeeker
{
    public class WMIC
    {
        public WMIC(string name, string username, string pwd, bool ver, bool serial, bool model)
        {
            Name = name;
            Username = username;
            Password = pwd;
            Version = ver;
            Model = model;
            Serial = serial;
        }

        public string createQuery(int queryType)
        {
            string query = @"/c wmic";

            if (Name.ToLower() != Environment.MachineName.ToLower())
            {
                query += @" /node:" + Name + " /user:" + Name + @"\" + Username + " /password:\"" + Password + "\"";
            }

            switch (queryType)
            {
                case 0:
                    query += " product get name" + (Version ? ", version" : "");
                    break;
                case 1:
                    query += " bios get serialnumber";
                    break;
                case 2:
                    query += " csproduct get name";
                    break;
            }

            return query;
        }

        public bool Version { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public bool Serial { get; set; }
        public bool Model { get; set; }
    }
}
