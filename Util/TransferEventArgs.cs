using SistemaBancario.BaseClass;

namespace SistemaBancario.Util
{
    internal class TransferEventArgs : EventArgs
    {
        public Account SenderAccount { get; }
        public Account RecipientAccount { get; }
        public double TranferValue { get; }
        public DateTime Date {  get; }

        public TransferEventArgs(Account sender, Account recipient, double tranferValue)
        {
            SenderAccount = sender;
            RecipientAccount = recipient;
            TranferValue = tranferValue;
            Date = DateTime.Now;
        }
    }
}
