using SistemaBancario.Util;

namespace SistemaBancario.BaseClass
{    
    internal class Account : IEntity
    {
        public int Id { get; set; }
        public int IdClient { get; set; }
        public double Balance { get; set; }
               
        public Account(int id, int idClient, double balance)
        {
            Id = id;
            IdClient = idClient;
            Balance = balance;            
        }
    }
}
