using SistemaBancario.Repos;

namespace SistemaBancario.Util
{
    internal static class Loads
    {
        public static void LoadLists()
        {
            Lists.listOfClients = Repositories.clientRepos.LoadList();
            Lists.listOfAccounts = Repositories.accountRepos.LoadList();
            Lists.listOfExtracts = Repositories.extractRepos.LoadList();
        }
    }
}
