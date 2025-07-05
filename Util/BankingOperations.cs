using SistemaBancario.BaseClass;
using SistemaBancario.Repos;
using System.Reflection.Emit;
using System.Text;

namespace SistemaBancario.Util
{   
    internal static class BankingOperations
    {
        public static void Deposit()
        {
            var accountA = Utilities.SearchAccount();            
            OperationBankingValidators.ValidateValueDeposit(accountA);
        }

        public static void CashOut()
        {
            var a = Utilities.SearchAccount();
            OperationBankingValidators.ValidateValueCashOut(a);
        }

        public static void Transfer()
        {
            var a = Utilities.SearchAccount("Insira o ID da conta remetente: ");
            var b = Utilities.SearchAccount("Insira o ID da conta destinatária: ");
            OperationBankingValidators.ValidateValueTransfer(a, b);
        }

        public static void ViewExtracts()
        {
            if(Validators.ListHasItens("LISTA DE EXTRATOS VAZIA!",Lists.listOfExtracts)) return;
            foreach(Extract e in Lists.listOfExtracts)
            {
                if (e.Type != Utilities.OperationType.TRANFERENCIA)
                {
                    Utilities.Dialogues($"""
                    ---------------------------------------------------------
                    ###EXTRATO {e.Code}###
                    |ID         |{e.Code}
                    |TIPO       |{e.Type}
                    |VALOR      |{e.Value:f2}
                    |CONTA      |{e.SenderAccount}
                    |DATA       |{e.Date}
                    """, true, ConsoleColor.DarkYellow);                    
                }
                else
                {
                    Utilities.Dialogues($"""
                    ---------------------------------------------------------
                    ###EXTRATO {e.Code}###
                    |ID         |{e.Code}
                    |TIPO       |{e.Type}
                    |VALOR      |{e.Value:f2}
                    |CONTA R.   |{e.SenderAccount}
                    |CONTA D.   |{e.RecipientAccount}
                    |DATA       |{e.Date}
                    """, true, ConsoleColor.DarkYellow);
                    continue;
                }                    
            }
        }
    }
}
