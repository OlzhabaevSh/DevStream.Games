namespace DevStream.Games.Twitch.Core.DTOs
{
    /// <summary>
    /// DTO for Twitch game information
    /// </summary>
    public class TwitchGameDataDto
    {
        /// <summary>
        /// Game name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Viewer count in current moment
        /// </summary>
        public decimal ViewerCount { get; set; }
    }
}
