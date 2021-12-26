namespace DevStream.Games.Twitch.ConsoleApplication.Helpers
{
    using System.IO;
    using System.Threading.Tasks;

    /// <summary>
    /// 
    /// </summary>
    public class FileSaveHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public async Task<string> Save(string path, string content) 
        {
            using var file = File.CreateText(path);
            file.Close();
            
            await File.WriteAllTextAsync(path, content);

            return Path.GetFullPath(path);
        }
    }
}
