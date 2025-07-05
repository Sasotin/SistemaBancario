using SistemaBancario.BaseClass;
using SistemaBancario.Repos;

namespace SistemaBancario.Util
{
    internal static class Validators
    {        
        public static bool ValidadeCpf(string cpf)
        {
            if (ValidateRequiredField(cpf)) return false;
            cpf = new string(cpf.Where(char.IsDigit).ToArray());            
            if (cpf.Length != 11) return false;
            if (cpf.Distinct().Count() == 1) return false;
            return true;
        }

        public static bool ValidateRequiredField(string input, string error="CAMPO OBRIGATORIO!")
        {
            if (string.IsNullOrEmpty(input) && string.IsNullOrWhiteSpace(input))
            {
                Utilities.ErrorMessage(error);
                return true;
            }
            return false;
        }
    
        public static bool ListHasItens<T>(string contextMessage, List<T> list)
        { 
            if (list.Count <= 0)
            {
                Utilities.ErrorMessage(contextMessage);
                return false;
            }
            return false;            
        }                
    }
}
