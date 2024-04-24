namespace TimApp2.Models
{
    public class Partner
    {

        public string Id { get; set; } //1.1 necessary, since we need to store them in database, so we need a ID 

        public string Name { get; set; }
        public string Location { get; set; }
        public string Contact { get; set; }
        public string Resource { get; set; }
        public string Description { get; set; }
    }
}
