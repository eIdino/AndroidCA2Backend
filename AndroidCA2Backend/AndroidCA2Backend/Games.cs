using System.Text.Json.Serialization;

namespace AndroidCA2Backend
{
    public class Games
    {
        public string Game { get; set; }

        public string Genre { get; set; }

        public int Like { get; set; } = 0;

        [JsonIgnore]
        public string GameInfo
        { get
            {
                return $"{Game} Genres: {Genre} Likes: {Like}";
            }
        }
    }
}