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

        public ExecuteMe() { }

        public ExecuteMe(int v)
        {
            this.v = v;
        }

        public ExecuteMe(String a, String b)
        {
            
        }

    }


}
