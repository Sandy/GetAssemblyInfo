using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GetAssemblyIndo
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Please provide the path to the DLL.");

            string dllPath = Console.ReadLine();
            Assembly assembly;

            try
            {
                assembly = Assembly.LoadFrom(dllPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading assembly: " + ex.Message);
                return;
            }

            // You can modify the type name or iterate over all types
            Console.WriteLine("Loaded assembly: " + assembly.FullName);
            foreach (Type type in assembly.GetTypes())
            {
                // Replace 'HttpModules.CorsHttpModule' with the actual class you want to check,
                // or remove the condition to print all types.
                if (type.FullName.Contains("XSSHTTPModule"))
                {
                    Console.WriteLine("Full name: " + type.FullName);
                    Console.WriteLine("Assembly qualified name: " + type.AssemblyQualifiedName);
                }
            }
            Console.ReadLine();
        }
    }
}