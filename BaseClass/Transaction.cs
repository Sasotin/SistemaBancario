namespace SistemaBancario.BaseClass
{
    internal class Transaction
    {
        public string Type { get; set; }
        public double Value { get; set; }
        public DateTime TransactionDate => DateTime.Now;

        public Transaction(string type, double value)
        {
            Type = type;
            Value = value;
        }
    }
}
