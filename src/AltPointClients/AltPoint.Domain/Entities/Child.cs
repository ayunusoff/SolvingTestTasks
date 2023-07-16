namespace AltPoint.Domain.Entities
{
    public class Child
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Patronymic { get; set; } = null!;
        public IList<Client> Parents { get; set; } = null!;
    }
}
