namespace AltPoint.Domain.Entities
{
    public class Page
    {
        public int Limit { get; set; }
        public int PageNum { get; set; }
        public int Total { get; set; }
        public IEnumerable<Client> clients { get; set; } = null!;
    }
}
