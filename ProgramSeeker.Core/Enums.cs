using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramSeeker.Core
{
    [Flags]
    public enum QueryType
    {
        SerialNumber = 0,
        ComputerModel = 1,
        Software = 2,
        SoftwareVersion = 4
    }
}
