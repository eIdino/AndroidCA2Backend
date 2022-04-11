using System.Text.Json.Serialization;

namespace AndroidCA2Backend
{
    public class Console
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [JsonIgnore]
        public string ConsoleInfo
        {
            get
            {
                return $"Console: {Name}";
            }
        }
    }
}