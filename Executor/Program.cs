using System;
using System.Reflection;
using MyAttribute;

namespace Executor
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = Assembly.LoadFrom("..\\..\\..\\MyLibrary\\bin\\Debug\\MyLibrary.dll");
            foreach (var type in a.GetTypes())
                if (type.IsClass)
                {
                    foreach (var method in type.GetMethods())
                        if (method.IsPublic)
                            foreach (var meth in method.CustomAttributes)
                                if (meth.AttributeType == typeof(ExecuteMe))
                                {
                                    object result = null;
                                    object classInstance = Activator.CreateInstance(type, null);
                                   
                                    ExecuteMe[] attr = (ExecuteMe[])method.GetCustomAttributes(typeof(ExecuteMe), true);
                                    foreach (var aExecuteMe in attr)
                                    {
                                        Object[] prm = aExecuteMe.param;
                                        result = method.Invoke(classInstance, prm);
                                    }
                                    
                                }
                                
                    //Console.WriteLine(type.FullName);
                    Console.ReadKey();
                }
        }
    }
}