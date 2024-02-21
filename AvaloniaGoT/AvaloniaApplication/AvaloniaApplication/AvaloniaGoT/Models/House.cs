using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AvaloniaApplication.Models
{
    [Table("house")] 
    public class House
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonProperty("id")]
        public int id { get; set; }
        
        [JsonProperty("url")]
        public string url { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("region")]
        public string region { get; set; }

        [JsonProperty("coatofarms")]
        public string coatofarms { get; set; }

        [JsonProperty("words")]
        public string words { get; set; }

        [JsonProperty("titles")]
        public string[] titles { get; set; }

        [JsonProperty("seats")]
        public string[] seats { get; set; }

        [JsonProperty("currentlord")]
        public string currentlord { get; set; }

        [JsonProperty("heir")]
        public string heir { get; set; }

        [JsonProperty("overlord")]
        public string overlord { get; set; }

        [JsonProperty("founded")]
        public string founded { get; set; }

        [JsonProperty("founder")]
        public string founder { get; set; }

        [JsonProperty("diedout")]
        public string diedout { get; set; }

        [JsonProperty("ancestralweapons")]
        public string[] ancestralweapons { get; set; }

        [JsonProperty("cadetbranches")]
        public string[] cadetbranches { get; set; }

        [JsonProperty("swornmembers")]
        public string[] swornmembers { get; set; }
    }
}