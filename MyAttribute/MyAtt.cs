using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace MyAttribute
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class ExecuteMe : Attribute
    {
        private int v { get; }
        private string v1 { get; }
        private string v2 { get; }

        public ExecuteMe() { }

        public ExecuteMe(int v)
        {
            this.v = v;
        }

        public ExecuteMe(string v1, string v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }
    }
}
