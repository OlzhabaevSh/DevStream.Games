namespace DevStream.Games.Twitch.TextFormatProvider.Csv
{
    using DevStream.Games.Twitch.Core.DTOs;
    using DevStream.Games.Twitch.Core.Services;
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Provider for Csv text format
    /// </summary>
    public class CsvTextFormatProvider : ITextFormatProvider
    {
        /// <inheritdoc />
        public string Convert(ICollection<TwitchGameDataDto> data, DateTime downloadDatetime)
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Name,ViewerCount");

            foreach (var item in data)
            {
                sb.AppendLine($"{item.Name},{item.ViewerCount}");
            }

            return sb.ToString();
        }
    }
}
