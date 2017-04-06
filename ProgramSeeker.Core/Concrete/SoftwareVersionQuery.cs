using ProgramSeeker.Core.Abstract;
using ProgramSeeker.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramSeeker.Core.Concrete
{
    public class SoftwareVersionQuery : BaseQuery
    {
        public SoftwareVersionQuery(WmicContext context) : base(context)
        {
            queryText = base.QueryText + " product get name, version";
        }

        private string queryText;
        override public string QueryText
        {
            get
            {
                return queryText;
            }
        }
    }
}
