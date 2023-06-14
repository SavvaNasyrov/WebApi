using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace WebApi.Models
{
    public class OccurrencesData
    {
        [Key]
        [Required]
        public string OwnerID { get; set; }
        public OccurrencesData(string ownerID)
        {
            Data = new Dictionary<char, int>[5];
            Data[0] = new Dictionary<char, int>(33);
            Data[1] = new Dictionary<char, int>(33);
            Data[2] = new Dictionary<char, int>(33);
            Data[3] = new Dictionary<char, int>(33);
            Data[4] = new Dictionary<char, int>(33);
            OwnerID = ownerID;
        }

        public String JsonString { get; set; }

        [NotMapped]
        public Dictionary<char, int>[] Data { get; set; }

        public void UpdateJsonString()
        {
            JsonString = JsonSerializer.Serialize(Data);
        }
    }
}
