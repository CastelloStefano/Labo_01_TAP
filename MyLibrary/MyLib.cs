using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyAttribute;

namespace MyLibrary
{
    public class MyLib
    {
        [ExecuteMe]
        public void M1()
        {
            Console.WriteLine("Hi I'm Hi !");
        }
    }
}
