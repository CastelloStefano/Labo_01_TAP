using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MyAttribute;

namespace MyLibrary
{
    public class MyLib
    {
        /*
         * An attribute argument must be
         * a constant expression, 
         * typeof expression 
         * or array creation expression of an attribute parameter type
         */


        [ExecuteMe]
        public void M1(){
            Console.WriteLine("M1");
        }

        [ExecuteMe(45)]
        [ExecuteMe(0)]
        [ExecuteMe(3)]
        public void M2(int a)
        {
            Console.WriteLine("M2 a={0}", a);
        }

        [ExecuteMe("hello", "reflection")]
        public void M3(string s1, string s2)
        {
            Console.WriteLine("M3 s1={0} s2={1}", s1, s2);
        }
     
    }
}
