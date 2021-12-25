namespace DevStream.Games.Twitch.Core.Services
{
    using DevStream.Games.Twitch.Core.DTOs;
    using System;
    using System.Collections.Generic;

    public interface ITextFormatProvider
    {
        string Convert(ICollection<TwitchGameData> data, DateTime downloadDatetime);
    }
}
