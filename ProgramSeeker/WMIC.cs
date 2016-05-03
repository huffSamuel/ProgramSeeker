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
        public WMIC(string name, string username, string pwd, bool ver)
        {
            Name = name;
            Username = username;
            Password = pwd;
            Version = ver;
        }

        public string createQuery()
        {
            return @"/c wmic product get name, version";
        }

        public string createSoftwareQuery(bool getVersion)
        {
            string val = "";
            if (Name.ToLower() == Environment.MachineName.ToLower())
                val = @"/c wmic product get name" + (getVersion ? ",version" : "");
            else
                val = @"/c wmic /node:" + Name + " /user:" + Name + @"\" + Username + " /password:\"" + Password + "\" product get name" + (getVersion ? ",version" : "");

            return val;
        }

        public bool Version { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
    }
}
