namespace DevStream.Games.Twitch.TextFormatProvider.Xml
{
    using DevStream.Games.Twitch.Core.DTOs;
    using DevStream.Games.Twitch.Core.Services;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Xml.Serialization;

    public class XmlTextFormatProvider : ITextFormatProvider
    {
        public string Convert(ICollection<TwitchGameData> data, DateTime downloadDatetime)
        {
            var schema = new XmlSerializer(typeof(List<TwitchGameData>));

            using var stream = new MemoryStream();

            schema.Serialize(stream, data);

            var bytes = stream.ToArray();

            var stringVal = System.Text.Encoding.Default.GetString(bytes);

            return stringVal;
        }
    }
}
