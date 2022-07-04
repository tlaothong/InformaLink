namespace InformaLink.WebApi.Models
{
    public class StationsQuery
    {
        private static readonly string[] EmptyStationIds = new string[0];
        public string[] StationIds { get; set; } = EmptyStationIds;
    }
}
