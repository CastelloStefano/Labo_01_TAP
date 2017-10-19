﻿using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MyAttribute;

namespace Executor
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = Assembly.LoadFrom("MyLibrary.dll");
            foreach (var type in a.GetTypes())
                if (type.IsClass)
                {
                    foreach (var method in type.GetMethods())
                        if (method.IsPublic)
                            foreach (var meth in method.CustomAttributes)
                                if(meth.AttributeType == typeof(ExecuteMe))
                                    Console.WriteLine(meth.AttributeType);
                    //Console.WriteLine(type.FullName);
                    Console.ReadLine();
                }
        }
    }
}
