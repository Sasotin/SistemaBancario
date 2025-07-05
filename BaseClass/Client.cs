using SistemaBancario.Util;

namespace SistemaBancario.BaseClass
{
    internal class Client : IEntity
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Cpf {  get; set; }
        public int Id { get; set; }
        public int? AccountId { get; set; }

        public Client(string name, int age, string cpf, int id)
        {
            Name = name;
            Age = age;
            Cpf = cpf;
            Id = id;
            AccountId = null;
        }
    }
}
