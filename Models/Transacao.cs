namespace PaymetAPI.Models
{
    public class Transacao : Usuario
    {
        public int Id;

        public int IdClienteEnvia;

        public int IdClienteRecebe;

        public double Valor;

    }
}
