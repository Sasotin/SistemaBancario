using SistemaBancario.BaseClass;
using SistemaBancario.Repos;

namespace SistemaBancario.Util
{
    internal class AccountRegister
    {
        public void Bind(ClientRegister c)
        {
            c.ClientRegistered += GenerateAccount;
            c.Register();
            return;
        }
        private void GenerateAccount(object sender, ClientEventArgs e)
        {
            int accountId = IdGenerator.GenerateId(Lists.listOfAccounts);
            double balance = 0;
            Client client = e.Client;
            Account newAccount = new(accountId, e.Client.Id, balance);
            client.AccountId = accountId;
            Lists.listOfAccounts.Add(newAccount);
            Repositories.accountRepos.SaveList(Lists.listOfAccounts);
            Repositories.clientRepos.SaveList(Lists.listOfClients);
            Utilities.Dialogues($"""
                -------------------------------------
                ###CONTA CRIADA###
                |CLIENTE ID |{e.Client.Id}
                |CONTA ID   |{newAccount.Id} 
                """, true, ConsoleColor.DarkYellow);
        }
    }
}
