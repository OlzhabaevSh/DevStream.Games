namespace DevStream.Games.Twitch.Core.Services
{
    using DevStream.Games.Twitch.Core.DTOs;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IGameDataService
    {
        Task<ICollection<TwitchGameData>> Get(int skip = 0, int take = 30);
    }
}
