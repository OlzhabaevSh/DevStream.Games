namespace DevStream.Games.Twitch.TextFormatProvider.Xml
{
    using DevStream.Games.Twitch.Core.DTOs;
    using DevStream.Games.Twitch.Core.Services;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Xml.Serialization;

    /// <summary>
    /// Provider for xml text format
    /// </summary>
    public class XmlTextFormatProvider : ITextFormatProvider
    {
        /// <inheritdoc />
        public string Convert(ICollection<TwitchGameDataDto> data, DateTime downloadDatetime)
        {
            var schema = new XmlSerializer(typeof(List<TwitchGameDataDto>));

            using var stream = new MemoryStream();

            schema.Serialize(stream, data);

            var bytes = stream.ToArray();

            var stringVal = System.Text.Encoding.Default.GetString(bytes);

            return stringVal;
        }
    }
}
