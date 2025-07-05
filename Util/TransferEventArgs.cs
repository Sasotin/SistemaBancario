using SistemaBancario.BaseClass;

namespace SistemaBancario.Util
{
    internal class TransferEventArgs : EventArgs
    {
        public Account SenderAccount { get; }
        public Account RecipientAccount { get; }
        public double TransferValue { get; }
        public DateTime Date {  get; }

        public TransferEventArgs(Account sender, Account recipient, double tranferValue)
        {
            SenderAccount = sender;
            RecipientAccount = recipient;
            TransferValue = tranferValue;
            Date = DateTime.Now;
        }
    }
}
