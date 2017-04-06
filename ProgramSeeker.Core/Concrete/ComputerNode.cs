using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramSeeker.Core
{
    public class ComputerNode
    {
        List<Software> installedSoftware = new List<Software>();
        public string Name { get; set; }
        public string SerialNumber { get; set; }
        public string Model { get; set; }
    }
}
