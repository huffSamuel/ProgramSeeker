using ProgramSeeker.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramSeeker.Core.Abstract
{
    public abstract class BaseQuery : IQuery
    {
        public BaseQuery(WmicContext context)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("/c wmic");

            if (!context.MachineName.Equals(Environment.MachineName, StringComparison.OrdinalIgnoreCase))
            {
                sb.Append(@" /node:");
                sb.Append(context.MachineName);
                sb.Append(@" /user:");
                sb.Append(context.MachineName);
                sb.Append(@"\");
                sb.Append(context.Username);
                sb.Append(" /password:\"");
                sb.Append(context.Password);
                sb.Append("\"");
            }

            queryText = sb.ToString();
        }

        private string queryText;
        
        virtual public string QueryText
        {
            get { return queryText; }
        }
    }
}
