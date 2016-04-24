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
        private string m_nodeName;
        private string m_Username;
        private string m_Password;
        private bool m_getVersion;

        public WMIC(string name, string username, string pwd, bool ver)
        {
            m_nodeName = name;
            m_Username = username;
            m_Password = pwd;
            m_getVersion = ver;
        }
        
        public string createQuery()
        {
            return @"/c wmic product get name, version";
        }

        public string getName()
        {
            return m_nodeName;
        }
    }
}
