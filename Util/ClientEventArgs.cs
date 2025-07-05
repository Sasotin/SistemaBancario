using SistemaBancario.BaseClass;

namespace SistemaBancario.Util
{
    internal class ClientEventArgs : EventArgs
    {
        public Client Client { get; }

        public ClientEventArgs(Client client)
        {
            Client = client;
        }
    }
}
