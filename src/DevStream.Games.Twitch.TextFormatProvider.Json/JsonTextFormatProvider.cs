namespace DevStream.Games.Twitch.TextFormatProvider.Json
{
    using DevStream.Games.Twitch.Core.DTOs;
    using DevStream.Games.Twitch.Core.Services;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Provider for json text format
    /// </summary>
    public class JsonTextFormatProvider : ITextFormatProvider
    {
        /// <inheritdoc />
        public string Convert(ICollection<TwitchGameDataDto> data, DateTime downloadDatetime)
        {
            return System.Text.Json.JsonSerializer.Serialize(data);
        }
    }
}
