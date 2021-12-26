namespace DevStream.Games.Twitch.ConsoleApplication.Helpers
{
    using DevStream.Games.Twitch.Core.Services;
    using DevStream.Games.Twitch.TextFormatProvider.Csv;
    using DevStream.Games.Twitch.TextFormatProvider.Json;
    using DevStream.Games.Twitch.TextFormatProvider.Xml;
    using System.Collections.Generic;

    /// <summary>
    /// 
    /// </summary>
    public class FindTextFormatConverterHelper
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly Dictionary<string, ITextFormatProvider> _map;

        /// <summary>
        /// 
        /// </summary>
        public FindTextFormatConverterHelper()
        {
            _map = new Dictionary<string, ITextFormatProvider>();
            _map.Add("json", new JsonTextFormatProvider());
            _map.Add("xml", new XmlTextFormatProvider());
            _map.Add("csv", new CsvTextFormatProvider());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="exportType"></param>
        /// <returns></returns>
        public ITextFormatProvider Match(string exportType) 
        {
            return _map[exportType];
        }
    }
}
