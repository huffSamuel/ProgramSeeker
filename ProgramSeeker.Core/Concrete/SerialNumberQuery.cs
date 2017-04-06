using ProgramSeeker.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramSeeker.Core.Concrete
{
    public class SerialNumberQuery : BaseQuery
    {
        public SerialNumberQuery(WmicContext context) : base(context)
        {
            queryText = base.QueryText + " bios get serialnumber";
        }
        private string queryText;
        override public string QueryText
        {
            get { return queryText; }
        }
    }
}
