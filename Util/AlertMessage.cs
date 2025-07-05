namespace SistemaBancario.Util
{
    internal class AlertMessage
    {
        public void Bind()
        {
            OperationBankingValidators.TransferHigh += NotifyTransferHigh;            
        }
        void NotifyTransferHigh(object sender, TransferEventArgs args)
        {
            Utilities.ErrorMessage($"""
                ALERTA! TRANSFERENCIA DE ALTO VALOR DETECTADA!
                |CONTA REMENTENTE       |{args.SenderAccount.Id}
                |CONTA DESTINATARIA     |{args.RecipientAccount.Id}
                |VALOR DA TRANSAÇÃO     |{args.TransferValue}
                |DATA                   |{args.Date}
                """);
        }
    }
}
