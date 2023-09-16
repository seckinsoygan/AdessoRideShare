namespace Entities.Concrete
{
    public class Travel
    {
        public int TravelId { get; set; }
        public string FromWhere { get; set; }
        public string FromTo { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public int SeatCount { get; set; }
        public bool TravelStatus { get; set; }
    }
}
