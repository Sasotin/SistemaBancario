using SistemaBancario.BaseClass;
using SistemaBancario.Repos;
using System.Text;

namespace SistemaBancario.Util
{
    internal static class Utilities
    {
        public enum OperationType
        {
            DEPOSITO,
            SAQUE,
            TRANFERENCIA,
        }
        
        public static string InputString(string contextMessage)
        {
            string input;
            do
            {
                Dialogues(contextMessage, false);
                input = Console.ReadLine();
            }
            while(Validators.ValidateRequiredField(input));
            return input;
        }

        public static string InputCpf(string contextMessage)
        {
            string input;
            while(true)
            {
                Dialogues(contextMessage, false);
                input = Console.ReadLine();
                if(Validators.ValidadeCpf(input)) break;
            }            
            return input;
        }        

        public static int InputAge(string contextMessage)
        {            
            int value;
            while(true)
            {
                Dialogues(contextMessage, false);
                var userInput = Console.ReadLine().Trim();
                if (int.TryParse(userInput, out value) && value >= 18)
                {
                    break;
                }
                ErrorMessage("IDADE INVALIDA!");
            }
            return value;
        }
        
        public static int InputInt(string contextMessage)
        {
            int value;
            while (true)
            {
                Dialogues(contextMessage, false);
                var userInput = Console.ReadLine().Trim();
                if (int.TryParse(userInput, out value) && value >= 100_000 && value <= 999_999)
                {
                    break;
                }
                ErrorMessage("ID INVALIDO!");                
            }
            return value;
        }

        public static double InputDouble(string contextMessage)
        {
            double value;
            while (true)
            {
                Dialogues(contextMessage, false);
                var userInput = Console.ReadLine().Trim();
                if (double.TryParse(userInput, out value) && value > 0)
                {
                    break;
                }
                ErrorMessage("VALOR INVALIDO!");                
            }
            return value;
        }

        public static void Dialogues(string message, bool inLine = true, ConsoleColor cor = ConsoleColor.White)
        {
            Console.ForegroundColor = cor;
            if (inLine == true)
            {
                Console.WriteLine(message);
            }
            else
            {
                Console.Write(message);
            }
            Console.ResetColor();
        }

        public static void ErrorMessage(string errorMessage)
        {
            Console.ForegroundColor= ConsoleColor.Red;
            Console.WriteLine($"\n{errorMessage}\n");
            Console.ResetColor();
        }

        public static void SaveExtract(OperationType extractType, double value, Account accountA, Account? accountB = null)
        {
            Extract newExtract = new(Code(), extractType, value, accountA.Id, accountB?.Id);
            Lists.listOfExtracts.Add(newExtract);
            if (accountB == null)
            {
                Dialogues($"""
                        ---------------------------------------------------------
                        ###EXTRATO GERADO###
                        |ID         |{newExtract.Code}
                        |TIPO       |{newExtract.Type}
                        |VALOR      |{newExtract.Value:f2}
                        |CONTA      |{accountA.Id}
                        |DATA       |{newExtract.Date}
                        """, true, ConsoleColor.Green);
                Repositories.extractRepos.SaveList(Lists.listOfExtracts);
                return;
            }
            Dialogues($"""
                    ---------------------------------------------------------
                    ###EXTRATO GERADO###
                    |ID         |{newExtract.Code}
                    |TIPO       |{newExtract.Type = OperationType.TRANFERENCIA}
                    |VALOR      |{newExtract.Value:f2}
                    |CONTA R.   |{accountA.Id}
                    |CONTA D.   |{accountB.Id}
                    |DATA       |{newExtract.Date}
                    """, true, ConsoleColor.Green);
            Repositories.extractRepos.SaveList(Lists.listOfExtracts);
            return;
        }

        public static Account SearchAccount(string contextMessage = "Insira o ID da conta: ")
        {
            if (Validators.ListHasItens("NENHUMA CONTA CADASTRADA!", Lists.listOfAccounts)) return null;
            int searchAccountInListOfAccounts = InputInt(contextMessage);
            var foundAccount = Lists.listOfAccounts.Find(f => f.Id == searchAccountInListOfAccounts);
            if (foundAccount != null)
            {
                return foundAccount;
            }
            else
            {
                ErrorMessage("CONTA NAO ENCONTRADA!");
                return null;
            }
        }

        private static string Code(int maxLen = 25)
        {
            Random rand = new();
            var code = new StringBuilder();

            for (int i = 0; i < maxLen; i++)
            {
                code.Append(rand.Next(0, 9));
            }
            return code.ToString();
        }
    }
}
