using ProgramSeeker.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramSeeker.Core.Concrete
{
    public class ModelQuery : BaseQuery
    {
        public ModelQuery(WmicContext context) : base(context)
        {
            queryText = base.QueryText + " csproduct get name";
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
