using ProgramSeeker.Core;
using ProgramSeeker.Core.Concrete;
using ProgramSeeker.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramSeeker.Worker
{
    /// <summary>
    /// 
    /// </summary>
    public class WmicWorker
    {
        private List<IQuery> queries = new List<IQuery>();
        public event Action OnQueryCompleted;

        /// <summary>
        /// 
        /// </summary>
        public WmicWorker(WmicContext context, QueryType queryFlags)
        {
            // Create the queries to run based off the context and flags

            if(queryFlags.HasFlag(QueryType.Software))
            {
                if (queryFlags.HasFlag(QueryType.SoftwareVersion))
                    this.queries.Add(new SoftwareVersionQuery(context));
                else
                    this.queries.Add(new SoftwareQuery(context));
            }

            if (queryFlags.HasFlag(QueryType.ComputerModel))
                this.queries.Add(new ModelQuery(context));

            if (queryFlags.HasFlag(QueryType.SerialNumber))
                this.queries.Add(new SerialNumberQuery(context));
        }

        /// <summary>
        /// 
        /// </summary>
        public void Go()
        {
            List<string> processOutputs = new List<string>();
            string processOutput = string.Empty;
            ComputerNode node = null;

            foreach(IQuery query in this.queries)
            {
                processOutput = string.Empty;
                ProcessStartInfo psi = new ProcessStartInfo("cmd", query.QueryText)
                {
                    RedirectStandardOutput = true,
                    RedirectStandardError = false,
                    WindowStyle = ProcessWindowStyle.Normal,
                    UseShellExecute = false,
                };

                Process p = new Process() { StartInfo = psi };

                p.Start();

                using (System.IO.StreamReader sr = p.StandardOutput)
                    processOutput += sr.ReadToEnd();

                processOutputs.Add(processOutput);
            }
            

            node = CreateComputerNode(processOutput);

            if (OnQueryCompleted != null)
                OnQueryCompleted.Invoke();
        }

        /// <summary>
        /// Creates a computer node from the output of WMIC
        /// </summary>
        /// <param name="queryString"></param>
        /// <returns></returns>
        private ComputerNode CreateComputerNode(string queryString)
        {
            ComputerNode node = new ComputerNode();


            return node;
        }
    }
}
