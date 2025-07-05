using SistemaBancario.Repos;
using SistemaBancario.BaseClass;

namespace SistemaBancario.Util
{
    internal static class ClientOptions
    {
        public static void SearchClient() 
        {
            if (Validators.ListHasItens("NENHUM CLIENTE CADASTRADO!", Lists.listOfClients)) return;
            int searchClientInListOfClients = Utilities.InputInt("Insira o ID do cliente que deseja buscar: ");                  
            Client foundClient = Lists.listOfClients.Find(f => f.Id == searchClientInListOfClients);
            if(foundClient != null)
            {
                Utilities.Dialogues($"""
                    -------------------------------------
                    ###CLIENTE ENCONTRADO!###
                    |CLIENTE        |{foundClient.Name}
                    |ID             |{foundClient.Id}
                    |CPF            |{foundClient.Cpf}
                    |ID DA CONTA    |{foundClient.AccountId}
                    """, true, ConsoleColor.DarkYellow);
            }
            else
            {
                Utilities.ErrorMessage("CLIENTE NAO ENCONTRADO!");
                return;
            }
        }

        public static void ListCustomers()
        {
            if(Validators.ListHasItens("LISTA DE CLIENTES VAZIA!", Lists.listOfClients)) return;
            foreach (Client c in Lists.listOfClients)
            {
                Utilities.Dialogues($"""
                    -------------------------------------
                    ###CLIENTE ENCONTRADO!###
                    |CLIENTE        |{c.Name}
                    |ID             |{c.Id}
                    |CPF            |{c.Cpf}
                    |ID DA CONTA    |{c.AccountId}
                    """, true, ConsoleColor.DarkYellow);
            }
        }
    }
}
