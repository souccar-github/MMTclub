using System;
using System.IO;
using System.Threading;

namespace CodeGeneratorFront
{
    public class ModuleBuilder
    {

        public static void CreateIfNotExist(string name, string dir)
        {
            //var dir = AppConst.FrontPath + $"\\{name}";
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
                Console.WriteLine("Create Directory: " + dir);
            }
            CreateModuleFile(name, dir);
            CreateRouteFile(name, dir);
            CreateComponentFile(name, dir);
        }

        private static void CreateModuleFile(string name, string dir)
        {
            var fullName = dir + $"\\{name}.module.ts";
            if (!File.Exists(fullName))
            {
                var path = AppConst.CodePath + "\\xxxx.module.ts";
                string text = File.ReadAllText(path);
                text = text.Replace("xxxxs", name.Plural());
                text = text.Replace("Xxxxs", name.FirstCharToUpper().Plural());
                text = text.Replace("xxxx", name);
                text = text.Replace("Xxxx", name.FirstCharToUpper());
                
                var file = File.Create(fullName);
                file.Close();
                Console.WriteLine("Create File: " + fullName);
                Thread.Sleep(50);
                File.WriteAllText(fullName, text);
            }
            
        }

        public static void CreateRouteFile(string name, string dir)
        {
            var fullName = dir + $"\\{name}-routing.module.ts";
            if (!File.Exists(fullName))
            {
                var path = AppConst.CodePath + "\\xxxx-routing.module.ts";
                string text = File.ReadAllText(path);
                text = text.Replace("xxxx", name);
                text = text.Replace("Xxxx", name.FirstCharToUpper());
                text = text.Replace("Xxxxs", name.FirstCharToUpper().Plural());
                text = text.Replace("xxxxs", name.Plural());

                
                var file = File.Create(fullName);
                file.Close();
                Console.WriteLine("Create File: " + fullName);
                Thread.Sleep(50);
                File.WriteAllText(fullName, text);
            }
            
        }

        public static void CreateComponentFile(string name, string dir)
        {
            var fullName = dir + $"\\{name}.component.ts";
            if (!File.Exists(fullName))
            {
                var path = AppConst.CodePath + "\\xxxx.component.ts";
                string text = File.ReadAllText(path);
                text = text.Replace("xxxx", name);
                text = text.Replace("Xxxx", name.FirstCharToUpper());
                text = text.Replace("Xxxxs", name.FirstCharToUpper().Plural());
                text = text.Replace("xxxxs", name.Plural());

                var file = File.Create(fullName);
                file.Close();
                Console.WriteLine("Create File: " + fullName);
                Thread.Sleep(50);
                File.WriteAllText(fullName, text);
            }
        }
    }
}
