using ActivityLibrary;
using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkflowRunner {
    class Program {
        static void Main(string[] args) {

            var def = new Activity1();
            var wf = new WorkflowInvoker(def);
            wf.Invoke();

            Console.ReadKey();

        }
    }
}
