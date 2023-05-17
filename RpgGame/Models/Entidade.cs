namespace RpgGame.Models
{
    public abstract class Entidade
    {
        public long Id { get; set; }
        public DateTime CriadoEm { get; set; }
        public bool Deletado { get; set; }
    }
}
