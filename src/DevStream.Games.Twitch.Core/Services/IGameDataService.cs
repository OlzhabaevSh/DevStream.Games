namespace DevStream.Games.Twitch.Core.Services
{
    using DevStream.Games.Twitch.Core.DTOs;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// The interfact for getting data by current service
    /// </summary>
    public interface IGameDataService
    {
        /// <summary>
        /// Get data
        /// </summary>
        /// <param name="skip">pagination. count of skip rows</param>
        /// <param name="take">pagination. count of take rows</param>
        /// <returns></returns>
        Task<ICollection<TwitchGameDataDto>> Get(int skip = 0, int take = 30);
    }
}
