using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AvaloniaApplication.Models
{
    [Table("character")] 
    public class Character
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonProperty("id")]
        public int id { get; set; }
        
        [JsonProperty("url")]
        public string url { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("gender")]
        public string gender { get; set; }

        [JsonProperty("culture")]
        public string culture { get; set; }

        [JsonProperty("born")]
        public string born { get; set; }

        [JsonProperty("died")]
        public string died { get; set; }

        [JsonProperty("titles")]
        public string[] titles { get; set; }

        [JsonProperty("aliases")]
        public string[] aliases { get; set; }

        [JsonProperty("father")]
        public string father { get; set; }

        [JsonProperty("mother")]
        public string mother { get; set; }

        [JsonProperty("spouse")]
        public string spouse { get; set; }

        [JsonProperty("allegiances")]
        public string[] allegiances { get; set; }

        [JsonProperty("books")]
        public string[] books { get; set; }

        [JsonProperty("povBooks")]
        public string[] povbooks { get; set; }

        [JsonProperty("tvSeries")]
        public string[] tvseries { get; set; }

        [JsonProperty("playedBy")]
        public string[] playedby { get; set; }
    }
}