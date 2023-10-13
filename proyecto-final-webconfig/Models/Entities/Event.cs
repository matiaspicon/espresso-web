namespace proyecto_final_webconfig.Models.Entities
{
    public class Event
    {
        public int Id { get; set; }
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
        public string EventLocation { get; set; }
        public string IpSource { get; set; }
        public string MacSource { get; set; }
        public string IpDestination { get; set; }
        public string MacDestination { get; set; }
        public string TypeDetection { get; set; }
        public int CantPacketsDetect { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
