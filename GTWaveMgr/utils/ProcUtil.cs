using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using IronPython.Hosting;


namespace AnyBoBu.utils
{
    public  class   ProcUtil
    {
        public  static  void    run_static(string path, string file)
        {
            Process ps = new Process();
            ps.StartInfo.FileName = file;
            //ps.StartInfo.Arguments = @"C:\AnyCrawl\exec";
            ps.StartInfo.WorkingDirectory = path;
            ps.Start();
            //ps.WaitForExit(1000);
        }

        public  void    run_python(string path, string pythonFile)
        {
            var engine  = Python.CreateEngine();
            var vScope  = engine.CreateScope();
            try {
                //var vSource = engine.CreateScriptSourceFromFile("../AnyBoBu/GetTable/GenTable.py");
                var vSource = engine.CreateScriptSourceFromFile(@"C:/Project/AnyCrawl/Program/Manager/AnyBoBu/GetTable/test.py");
                vSource.Execute(vScope);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }

        public  void run_cmd(string path, string file)
        {
            var psi = new ProcessStartInfo
            {
                //FileName = @"C:\Users\user\AppData\Local\Programs\Python\Python310\python.exe", // 파이썬 설치 경로
                FileName = $"\"{path}\\{file}",
                //Arguments = $"\"{path}\\{file}",
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true
            };

            var erros = string.Empty;
            var results = string.Empty;

            using (Process process = Process.Start(psi))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    while (!process.HasExited)
                    {
                        Console.WriteLine(reader.ReadLine());
                    }

                    erros = process.StandardError.ReadToEnd();
                    results = process.StandardOutput.ReadToEnd();
                }
            }

            Console.WriteLine(erros);
            Console.WriteLine(results);
        }
    }
}
