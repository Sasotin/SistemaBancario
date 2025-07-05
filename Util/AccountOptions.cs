using SistemaBancario.BaseClass;
using SistemaBancario.Repos;
namespace SistemaBancario.Util
{
    internal class AccountOptions
    {
        public static void SearchAccount()
        {
            if (!Validators.ListHasItens("NENHUMA CONTA CADASTRADA!", Lists.listOfAccounts)) return;
            int searchAccountInListOfAccounts = Utilities.InputInt("Insira o ID da conta que deseja buscar: ");
            Account foundAccount = Lists.listOfAccounts.Find(f => f.Id == searchAccountInListOfAccounts);
            if (foundAccount != null)
            {
                Utilities.Dialogues($"""
                    -------------------------------------
                    ###CLIENTE ENCONTRADO!###                                       
                    |ID DA CONTA    |{foundAccount.Id}
                    |ID DO CLIENTE  |{foundAccount.IdClient}
                    |SALDO          |{foundAccount.Balance:f2}
                    """, true, ConsoleColor.DarkYellow);
                return;
            }
            Utilities.ErrorMessage("CONTA NAO ENCONTRADA!");
            return;        
        }

        public static void ListAccount()
        {
            foreach (Account a in Lists.listOfAccounts)
            {
                Utilities.Dialogues($"""
                    -------------------------------------
                    ###CLIENTE ENCONTRADO!###                                       
                    |ID DA CONTA    |{a.Id}
                    |ID DO CLIENTE  |{a.IdClient}
                    |SALDO          |{a.Balance:f2}
                    """, true, ConsoleColor.DarkYellow);                
            }
        }
    }
}
