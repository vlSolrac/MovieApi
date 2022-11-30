using Newtonsoft.Json;

namespace MoviesApi.Models
{
    public class GenreResponse
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

    }
}
