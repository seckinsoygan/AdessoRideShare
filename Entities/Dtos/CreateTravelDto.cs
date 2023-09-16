using System.Text.Json.Serialization;

namespace Entities.Dtos
{
    public class CreateTravelDto
    {
        public string FromWhere { get; set; }
        public string FromTo { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public int SeatCount { get; set; }
        [JsonIgnore]
        public bool TravelStatus { get; set; }
    }
}
