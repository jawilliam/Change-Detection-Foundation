using Jawilliam.CDF.CSharp.RoslynML;
using System;
using System.Diagnostics;

namespace CDF_Command_Line
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "quit")
                    break;

                string[] command = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (command.Length == 0)
                {
                    Console.WriteLine("Specify a command.");
                }
                else
                {
                    switch (command[0])
                    {
                        case "RoslynML":
                            if (command.Length != 2)
                                Console.WriteLine("RoslynML command takes 2 arguments.");
                            else
                                HandleRoslynMLCommand(command[1]);
                            break;
                        //case "sd":
                        //    using (var _process = new Process())
                        //    {
                        //        var procStartInfo = new ProcessStartInfo("powershell.exe")
                        //        {
                        //            RedirectStandardOutput = true,
                        //            RedirectStandardInput = true,
                        //            UseShellExecute = false,
                        //            CreateNoWindow = true
                        //        };

                        //        var proc = new Process { StartInfo = procStartInfo };
                        //        proc.Start();
                        //        //proc.StandardInput.WriteLine(@"cd E:\MyRepositories\Change-Detection-Foundation\CDF Command Line\bin\Debug\netcoreapp2.0");
                        //        proc.StandardInput.WriteLine(@"dotnet '.\CDF Command Line.dll'");
                        //        proc.StandardInput.WriteLine($@"RoslynML E:\SourceCode\OriginalAbstractBoardGame.cs");
                        //        proc.StandardInput.WriteLine(command);
                        //        proc.StandardInput.Flush();
                        //        proc.StandardInput.Close();
                        //        // Get the output into a string
                        //        //proc.WaitForExit();
                        //        var result = proc.StandardOutput.ReadToEnd()/*.Replace(header, "")*/;
                        //        //result = result.Replace($@"{sPrefix}{args.GumTreePath}\bin>", "")
                        //        //               .Replace($@"{args.GumTreePath}\bin>", "");
                        //        _process.Close();
                        //    }
                        //    break;
                        default:
                            Console.WriteLine("Unknown command.");
                            break;
                    }
                }                
            }
        }

        /// <summary>
        /// Handles the RoslynML command.
        /// </summary>
        /// <param name="fullPath">the full path from which loading the content.</param>
        private static void HandleRoslynMLCommand(string fullPath)
        {
            try
            {
                var loader = new RoslynML();
                var xElement = loader.Load(fullPath, true);
                Console.WriteLine(xElement.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
