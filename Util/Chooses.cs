namespace SistemaBancario.Util
{
    internal static class Chooses
    {        
        public static void MainChooses()
        {
            bool run = true;
            while(run)
            {
                Utilities.Dialogues("""
                    -------------------------------------
                    ###OPÇÕES###
                    1. CLIENTES
                    2. CONTAS
                    3. OPERAÇÕES
                    4. SAIR
                    """, true, ConsoleColor.Yellow);

                var selectedOption = Console.ReadLine().Trim();

                switch (selectedOption)
                {
                    case "1":
                        ClientChooses();
                        break;
                    case "2":
                        AccountChooses();
                        break;
                    case "3":
                        BankOperationsChooses();
                        break;
                    case "4":
                        run = false;
                        break;
                    default:
                        Utilities.ErrorMessage("OPÇÃO INVÁLIDA!");
                        break;
                }
            }
        }

        public static void ClientChooses()
        {
            while(true)
            {
                Utilities.Dialogues("""
                    -------------------------------------
                    ###OPÇÕES###
                    1. CADASTRAR CLIENTE
                    2. BUSCAR CLIENTE
                    3. LISTAR CLIENTES
                    4. SAIR
                    """, true, ConsoleColor.Cyan);

                var selectedOption = Console.ReadLine().Trim();
                switch (selectedOption)
                {
                    case "1":
                        ClientRegister newRegister = new();
                        AccountRegister newAccountReg = new();
                        newAccountReg.Bind(newRegister);                        
                        return;
                    case "2":
                        ClientOptions.SearchClient();
                        break;
                    case "3":
                        ClientOptions.ListCustomers();
                        break;
                    case "4":
                        return;
                    default:
                        Utilities.ErrorMessage("OPÇÃO INVÁLIDA!");
                        break;
                }
            }
        }

        public static void AccountChooses()
        {
            while (true)
            {
                Utilities.Dialogues("""
                    -------------------------------------
                    ###OPÇÕES###
                    1. BUSCAR CONTA
                    2. LISTAR CONTAS
                    3. SAIR
                    """, true, ConsoleColor.Cyan);

                var selectedOption = Console.ReadLine().Trim();
                switch (selectedOption)
                {
                    case "1":
                        AccountOptions.SearchAccount();
                        break;
                    case "2":
                        AccountOptions.ListAccount();
                        break;
                    case "3":
                        return;
                    default:
                        Utilities.ErrorMessage("OPÇÃO INVÁLIDA!");
                        break;
                }
            }
        }

        public static void BankOperationsChooses()
        {
            while (true)
            {
                Utilities.Dialogues("""
                    -------------------------------------
                    ###OPÇÕES###
                    1. DEPOSITAR
                    2. SACAR
                    3. TRANSFERIR
                    4. EXTRATOS
                    5. SAIR
                    """, true, ConsoleColor.Cyan);

                var selectedOption = Console.ReadLine().Trim();
                switch (selectedOption)
                {
                    case "1":
                        BankingOperations.Deposit();
                        break;
                    case "2":
                        BankingOperations.CashOut();
                        break;
                    case "3":
                        AlertMessage a = new();
                        a.Bind();
                        BankingOperations.Transfer();
                        break;
                    case "4":
                        BankingOperations.ViewExtracts();
                        break;
                    case "5":
                        return;
                    default:
                        Utilities.ErrorMessage("OPÇÃO INVÁLIDA!");
                        break;
                }
            }
        }
    }
}
