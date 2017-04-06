using ProgramSeeker.Core;
using ProgramSeeker.Worker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramSeeker.Playground
{
    class Program
    {
        static void Main(string[] args)
        {
            WmicContext context = new WmicContext();
            context.MachineName = "Thor";
            context.Password = "HAHA, you looked for passwords, huh?";
            context.Username = "asdfasdfa";
            QueryType type = QueryType.ComputerModel | QueryType.Software | QueryType.SoftwareVersion;
            WmicWorker worker = new WmicWorker(context, type);
            worker.OnQueryCompleted += () => { Console.WriteLine("Finished"); };
            worker.Go();
            Console.ReadLine();
        }
    }
}
