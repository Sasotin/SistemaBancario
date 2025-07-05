using SistemaBancario.BaseClass;

namespace SistemaBancario.Repos
{
    internal static class Repositories
    {
        public static GenericRepository<Client> clientRepos = new("Repositorio_Clientes.json");
        public static GenericRepository<Account> accountRepos = new("Repositorio_Contas.json");
        public static GenericRepository<Extract> extractRepos = new("Repositorio_Extratos.json");
    }
}
