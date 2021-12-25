namespace DevStream.Games.Twitch.ConsoleApplication.Helpers
{
    using DevStream.Games.Twitch.Core.DTOs;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ConsoleHelper
    {
        private readonly Dictionary<string, string> _args;

        public ConsoleHelper()
        {
            _args = new Dictionary<string, string>();

            _args.Add("--help",
                "Show the help page");
            _args.Add("-h",
                "Show the help page");
            _args.Add("--is-show-data",
                "Show datas in console | boolean | default: true | example: --is-show-data true");
            _args.Add("--is-export",
                "Export data as file | boolean | default: false | example: --is-export true");
            _args.Add("--export-type",
                "Export file as neeeded format | [json, xml, csv] | default: csv | example: --export-type json");
            _args.Add("--path-with-filename",
                "Path with filename to save a file (don't include a file extension) | string | default: [root]/{datetime}.{exportType} | example: my-data");
        }

        public TwitchConsoleApplicationSettings ParseArgs(string[] args)
        {
            var result = new TwitchConsoleApplicationSettings()
            {
                IsShowData = true,
                IsExport = false,
                ExportType = "csv",
                ExportPath = $"{DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss")}.csv"
            };

            if (args.Any(x => x.Contains("help")))
            {
                ShowCommands();
                throw new Exception("Application finished. Please restart");
            }

            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] == "--is-show-data")
                    result.IsShowData = bool.Parse(args[i + 1]);

                if (args[i] == "--is-export")
                    result.IsExport = bool.Parse(args[i + 1]);

                if (args[i] == "--export-type")
                {
                    result.ExportType = args[i + 1];
                    result.ExportPath = result.ExportPath.Replace("csv", result.ExportType);
                }

                if (args[i] == "--export-path-with-filename")
                    result.ExportPath = $"{args[i + 1]}.{result.ExportType}";

            }

            return result;
        }

        public void ShowCommands()
        {
            Console.WriteLine("Hello! This is a help page");
            Console.WriteLine();

            foreach (var item in _args)
            {
                Console.WriteLine($"{item.Key}");
                Console.WriteLine($"{item.Value}");
                Console.WriteLine();
            }
        }

        public void DrawGamesInConsole(ICollection<TwitchGameData> collection)
        {
            foreach (var item in collection)
            {
                Console.WriteLine($"{item.Name} | {item.ViewerCount}");
            }
        }
    }
}
