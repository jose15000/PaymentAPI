namespace PaymetAPI.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string? Nome { get; set; }

        public double Saldo { get; set; }

        public double Limite { get; set; }

        public static implicit operator int(Usuario? v)
        {
            throw new NotImplementedException();
        }
    }
}
