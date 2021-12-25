namespace DevStream.Games.Twitch.TextFormatProvider.Json
{
    using DevStream.Games.Twitch.Core.DTOs;
    using DevStream.Games.Twitch.Core.Services;
    using System;
    using System.Collections.Generic;

    public class JsonTextFormatProvider : ITextFormatProvider
    {
        public string Convert(ICollection<TwitchGameData> data, DateTime downloadDatetime)
        {
            return System.Text.Json.JsonSerializer.Serialize(data);
        }
    }
}
