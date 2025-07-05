using SistemaBancario.BaseClass;
using SistemaBancario.Repos;

namespace SistemaBancario.Util
{
    internal class ClientRegister
    {
        public event EventHandler<ClientEventArgs> ClientRegistered;
        public void Register()
        {
            int age = Utilities.InputAge("Idade do cliente: ");
            string name = Utilities.InputString("Nome do cliente: ");
            string cpf = Utilities.InputCpf("CPF do cliente: ");
            int id = IdGenerator.GenerateId(Lists.listOfClients);

            Client newClient = new(name, age, cpf, id);
            Lists.listOfClients.Add(newClient);
            Repositories.clientRepos.SaveList(Lists.listOfClients);
            Utilities.Dialogues($"""
                -------------------------------------
                ###CLIENTE CADASTRADO COM SUCESSO!###          
                |NOME       |{newClient.Name}
                |CPF        |{newClient.Cpf}
                |ID         |{newClient.Id}
                """, true, ConsoleColor.Green);

            ClientRegistered?.Invoke(this, new ClientEventArgs(newClient));
        }        
    }
}
