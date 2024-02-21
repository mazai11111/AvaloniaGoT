using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AvaloniaApplication.Models
{
    [Table("book")] 
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonProperty("id")]
        public int Id { get; set; }
        
        [JsonProperty("url")]
        public string url { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("isbn")]
        public string isbn { get; set; }

        [JsonProperty("authors")]
        public string[] authors { get; set; }

        [JsonProperty("numberOfPages")]
        public int numberofpages { get; set; }

        [JsonProperty("publisher")]
        public string publisher { get; set; }

        [JsonProperty("country")]
        public string country { get; set; }

        [JsonProperty("mediaType")]
        public string mediatype { get; set; }

        [JsonProperty("released")]
        public string released { get; set; }

        [JsonProperty("characters")]
        public string[] characters { get; set; }

        [JsonProperty("povCharacters")]
        public string[] povcharacters { get; set; }
    }
}