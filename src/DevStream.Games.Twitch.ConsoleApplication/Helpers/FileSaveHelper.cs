namespace DevStream.Games.Twitch.ConsoleApplication.Helpers
{
    using System.IO;
    using System.Threading.Tasks;

    public class FileSaveHelper
    {
        public Task Save(string path, string content) 
        {
            using var file = File.CreateText(path);
            file.Close();
            
            return File.WriteAllTextAsync(path, content);
        }
    }
}
