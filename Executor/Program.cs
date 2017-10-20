using System;
using System.Reflection;
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
                                if (meth.AttributeType == typeof(ExecuteMe))
                                {
                                    Console.WriteLine(meth.AttributeType);
                                    //TODO Invoke method
                                    object result = null;
                                    ParameterInfo[] parameters = method.GetParameters();
                                    object classInstance = Activator.CreateInstance(type, null);

                                    switch (parameters.Length)
                                    {
                                        case 0:
                                            result = method.Invoke(classInstance, null);
                                            break;
                                        case 1:
                                            object[] parametersArray = new object[] {1};         
                                            result = method.Invoke(classInstance, parametersArray);
                                            break;
                                        case 2:
                                            
                                            break;
                                    }
                                }
                                
                    //Console.WriteLine(type.FullName);
                    Console.ReadLine();
                }
        }
    }
}
