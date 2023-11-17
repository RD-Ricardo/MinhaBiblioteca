namespace MB.Core.DomainObjects
{
    public abstract class Entity 
    {
        public int Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAtualizacao { get; set; }
    }
}
