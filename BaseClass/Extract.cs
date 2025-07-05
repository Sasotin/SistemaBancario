using SistemaBancario.Util;

namespace SistemaBancario.BaseClass
{
    internal class Extract
    {
        public string Code { get; set; }
        public Utilities.OperationType Type { get; set; }
        public double Value { get; set; }
        public int SenderAccount { get; set; }
        public int? RecipientAccount { get; set; }
        public DateTime Date { get; set; }

        public Extract(string code, Utilities.OperationType type, double value, int senderAccount, int? recipientAccount = null) 
        {
            Code = code;
            Type = type;
            Value = value;
            SenderAccount = senderAccount;
            RecipientAccount = recipientAccount;        
            Date = DateTime.Now;
        }
    }
}
