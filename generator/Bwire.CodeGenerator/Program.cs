using Ahc.Club.Shared;
using System;

namespace Bwire.CodeGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Files : ");
            var assembly = typeof(AhcEntity).Assembly;
            ModulesBuilder.Generate(assembly, "Ahc");
            //LocalizationBuilder.Generate(assembly, "Ahc");
            //DbContextBuilder.Generate(assembly, "Ahc");
            //PermissionsBuilder.Generate(assembly, "Ahc");

            Console.WriteLine("Files : " + GeneralSetting.FileCount);
        }
    }
}
