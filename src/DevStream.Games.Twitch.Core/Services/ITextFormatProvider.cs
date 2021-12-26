namespace DevStream.Games.Twitch.Core.Services
{
    using DevStream.Games.Twitch.Core.DTOs;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Interface providing a text format (for example json, xml, csv etc)
    /// </summary>
    public interface ITextFormatProvider
    {
        /// <summary>
        /// Convert to needed text format
        /// </summary>
        /// <param name="data">Collection of data</param>
        /// <param name="downloadDatetime">Current datetime</param>
        /// <returns>text in needed text format</returns>
        string Convert(ICollection<TwitchGameDataDto> data, DateTime downloadDatetime);
    }
}
