using SistemaBancario.BaseClass;
using SistemaBancario.Repos;

namespace SistemaBancario.Util
{
    internal class OperationBankingValidators
    {
        public static event EventHandler<TransferEventArgs> TransferHigh;

        public static void ValidateValueDeposit(Account accountA)
        {
            if (accountA != null)
            {
                double depositValue = Utilities.InputDouble("Insira accountA quantidade do deposito: ");
                accountA.Balance += depositValue;
                Utilities.Dialogues($"""
                    ---------------------------------------------------------
                    VALOR DEPOSITADO COM SUCESSO!
                    SALDO ATUAL: {accountA.Balance:F2}
                    """, true, ConsoleColor.Green);
                Utilities.SaveExtract(Utilities.OperationType.DEPOSITO, depositValue, accountA);
                Repositories.accountRepos.SaveList(Lists.listOfAccounts);
            }
        }

        public static void ValidateValueCashOut(Account accountA)
        {
            if (accountA != null)
            {
                double cashOutValue = Utilities.InputDouble("Insira a quantidade do saque: ");
                if (accountA.Balance >= cashOutValue)
                {
                    accountA.Balance -= cashOutValue;
                    Utilities.Dialogues($"""
                    ---------------------------------------------------------
                    VALOR SACADO COM SUCESSO!
                    SALDO ATUAL: {accountA.Balance:F2}
                    """, true, ConsoleColor.Green);
                    Utilities.SaveExtract(Utilities.OperationType.SAQUE, cashOutValue, accountA);
                    Repositories.accountRepos.SaveList(Lists.listOfAccounts);
                }
                else
                {
                    Utilities.ErrorMessage("SALDO INSUFICIENTE!");
                }
            }
        }

        public static void ValidateValueTransfer(Account accountA, Account accountB)
        {
            if (accountA != null && accountB != null)
            {
                if (ValidadeIdAccount(accountA, accountB)) return;
                double transferValue = Utilities.InputDouble("Insira a quantidade da transferencia: ");
                if (accountA.Balance < transferValue)
                {
                    Utilities.ErrorMessage($"SALDO INSUFICIENTE NA CONTA REMETENTE: {accountA.Balance:F2}");
                    return;
                }
                if (transferValue >= 2500)
                {
                    TransferHigh?.Invoke(null, new TransferEventArgs(accountA, accountB, transferValue));
                }
                accountA.Balance -= transferValue;
                accountB.Balance += transferValue;
                Utilities.Dialogues($"""
                    ---------------------------------------------------------
                    ###VALOR TRANSFERIDO COM SUCESSO!###
                    SALDO ATUAL DA CONTA REMETENTE {accountA.Id}: {accountA.Balance:F2}
                    SALDO ATUAL DA CONTA DESTINATARIA {accountB.Id}: {accountB.Balance:F2}
                    """, true, ConsoleColor.Green);
                Utilities.SaveExtract(Utilities.OperationType.TRANFERENCIA, transferValue, accountA, accountB);
                Repositories.accountRepos.SaveList(Lists.listOfAccounts);                                         
            }
        }

        private static bool ValidadeIdAccount(Account accountA, Account accountB)
        {
            if (accountA == accountB)
            {
                Utilities.ErrorMessage("IMPOSSIVEL TRANSFERIR PARA A CONTA DE ORIGEM!");
                return true;
            }
            return false;
        }
    }
}
