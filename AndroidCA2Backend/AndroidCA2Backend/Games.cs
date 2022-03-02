namespace AndroidCA2Backend
{
    public class Games
    {
        public string Game { get; set; }

        public string Genre { get; set; }

        public int Like { get; set; }

        public string GameInfo { get; { return "Game: " + Game + "\t" + "Genre: " + Genre + "\t" + "Like(s): " + Like} }
    }
}