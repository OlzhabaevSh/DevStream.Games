namespace DevStream.Games.Twitch.ConsoleApplication
{
    using DevStream.Games.Twitch.ConsoleApplication.Helpers;
    using DevStream.Games.Twitch.Core.Services;
    using DevStream.Games.Twitch.WebClient;
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;

    class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args">
        ///     example 1: --help
        ///     example 2: --is-show-data true | draw list of games in console
        ///     example n:
        /// </param>
        /// <returns></returns>
        static async Task Main(string[] args)
        {
            try 
            {
                // bootstrapping
                var consoleHelper = new ConsoleHelper();
                var fileSaveHelper = new FileSaveHelper();
                var textFormatConverterHelper = new FindTextFormatConverterHelper();
                using var httpClient = new HttpClient();
                var twitchConfig = new TwitchConfig() { Url = "https://gql.twitch.tv/gql" };

                var consoleArgs = consoleHelper.ParseArgs(args);
                IGameDataService gameDataService = new GameDataService(httpClient, twitchConfig);
                ITextFormatProvider textFormater = textFormatConverterHelper.Match(consoleArgs.ExportType);

                // run
                var gameCollection = await gameDataService.Get();

                // draw
                if (consoleArgs.IsShowData)
                    consoleHelper.DrawGamesInConsole(gameCollection);

                // save
                if (consoleArgs.IsExport) 
                {
                    var stringContent = textFormater.Convert(gameCollection, DateTime.Now);
                     
                    var filePath = await fileSaveHelper.Save(consoleArgs.ExportPath, stringContent);
                    Console.WriteLine($"Your new file location: {filePath}");
                }
            }
            catch (Exception ex) 
            {
                Console.WriteLine("Application has stoped. Detail info:");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
