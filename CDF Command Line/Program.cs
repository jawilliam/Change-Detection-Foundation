using Jawilliam.CDF.CSharp.RoslynML;
using Jawilliam.CDF.Labs;
using Jawilliam.CDF.Labs.DBModel;
using System;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Globalization;
using System.Linq;

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

                string[] command = (input ?? "").Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (command.Length == 0)
                {
                    Console.WriteLine("Specify a command.");
                }
                else
                {
                    switch (command[0])
                    {
                        case "RoslynML":
                            if (command.Length < 2)
                                Console.WriteLine("RoslynML command takes at least 1 argument.");
                            else
                                HandleRoslynMLCommand(command[1], command.Length > 2 ? command.Skip(2).ToArray() : null);
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

                        case "BetweenComparison":
                            if (command.Length < 3)
                                Console.WriteLine("BetweenComparison command takes at least 2 arguments (information of interest and project name).");
                            else
                                HandleBetweenComparisonCommand(command.Skip(1).ToArray());
                            break;
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
        private static void HandleRoslynMLCommand(string fullPath, params string[] options)
        {
            try
            {
                var loader = new RoslynML();
                var xElement = loader.Load(fullPath, true);

                var opts = options ?? new string[0];

                if (opts.Any(o => o == "-gumtreefy"))
                    xElement = loader.Gumtreefy(xElement);

                var saveToFile = opts.SingleOrDefault(o => o.StartsWith("-saveToFile="));
                if (saveToFile != null)
                {
                    var path = saveToFile.Replace("-saveToFile=", "");
                    System.IO.File.WriteAllText(path, xElement.ToString());
                }
                else
                {
                    Console.WriteLine(xElement.ToString());
                }
                    
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Handles the BetweenComparison command.
        /// </summary>
        private static void HandleBetweenComparisonCommand(params string[] options)
        {
            var recognizer = new BetweenComparison()
            {
                MillisecondsTimeout = 600000
            };
            
            try
            {
                switch (options[0])
                {
                    case "statistics":
                        if (options.Length != 4)
                            Console.WriteLine("statistics command requires 3 arguments (project name, left approach , and right approach).");
                        int leftApproach, rightApproach;
                        try { leftApproach = int.Parse(options[2], CultureInfo.InvariantCulture); } catch (Exception) { throw new ApplicationException("Bad left approach."); }
                        try { rightApproach = int.Parse(options[3], CultureInfo.InvariantCulture); } catch (Exception) { throw new ApplicationException("Bad right approach."); }

                        var dbRepository = new GitRepository(options[1]) { Name = options[1] };
                        ((IObjectContextAdapter)dbRepository).ObjectContext.CommandTimeout = 600;

                        recognizer.ConfigForwardVsBackward(((ChangeDetectionApproaches)leftApproach, null), ((ChangeDetectionApproaches)rightApproach, null));
                        recognizer.SqlRepository = dbRepository;
                        recognizer.Cancel = null;

                        var output = recognizer.ReportBetweenMatches();
                        Console.WriteLine($"BetweenComparison - statistics ({output.Project})");
                        Console.WriteLine($"File revision pairs: Total-({output.TotalOfFileRevisionPairs}) " +
                            $"Affected-(" +
                            $"LR:{output.TotalOfAffectedFileRevisionPairs.LR}({output.PercentageOfAffectedFileRevisionPairs.LR}%), " +
                            $"RL:{output.TotalOfAffectedFileRevisionPairs.RL}({output.PercentageOfAffectedFileRevisionPairs.RL}%), " +
                            $"All:{output.TotalOfAffectedFileRevisionPairs.All}({output.PercentageOfAffectedFileRevisionPairs.All}%))");
                        Console.WriteLine($"Symptoms-(LR:{output.TotalOfSymptoms.LR}, RL:{output.TotalOfSymptoms.RL}, All:{output.TotalOfSymptoms.All})");
                        break;

                    default:
                        break;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
