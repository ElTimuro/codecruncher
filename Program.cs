using System;
using System.IO;
using System.Linq;
using System.Text;

namespace CodeCruncher
{
    class Program
    {
        static void Main(string[] args)
        {
            string rootPath = AppDomain.CurrentDomain.BaseDirectory;
            var header = "***********************************" + Environment.NewLine;

            var files = Directory.GetFiles(rootPath, "*.cs", SearchOption.AllDirectories);

            var result = files.Select(path => new { Name = Path.GetFileName(path), Contents = File.ReadAllText(path) })
                              .Select(info =>
                                  header
                                + "Filename: " + info.Name + Environment.NewLine
                                + header
                                + info.Contents);


            var singleStr = string.Join(Environment.NewLine, result);
            //Console.WriteLine(singleStr);
            Console.WriteLine("Crunching...");
            var p = AppDomain.CurrentDomain.BaseDirectory + @"Crunched.cs";
            File.WriteAllText(p, singleStr, Encoding.UTF8);
            Console.WriteLine("Done");
            Console.ReadKey();
        }
    }
}