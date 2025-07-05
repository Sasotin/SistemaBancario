using SistemaBancario.Util;
using System.Text.Json;

namespace SistemaBancario.Repos
{
    internal class GenericRepository<GenericList>
    {
        private readonly string _filePath;
        
        public GenericRepository(string fileName)
        {
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            _filePath = Path.Combine(documentsPath, fileName);
        }

        public List<GenericList> LoadList()
        {
            try
            {
                if (!File.Exists(_filePath))
                {
                    return [];
                }
                string json = File.ReadAllText(_filePath);
                return JsonSerializer.Deserialize<List<GenericList>>(json) ?? [];
            }
            catch(Exception ex)
            {
                Utilities.ErrorMessage($"""
                    Erro ao carregar lista!
                    -\
                    Caminho: {_filePath}
                    -\
                    Erro: {ex.Message}
                    -\
                    """);
                return [];
            }
        }

        public void SaveList(List<GenericList> list)
        {
            try
            {
                string json = JsonSerializer.Serialize(list, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(_filePath, json);
            }
            catch(Exception ex)
            {
                Utilities.ErrorMessage($"""
                    Erro ao salvar lista!
                    -\
                    Caminho: {_filePath}
                    -\
                    Erro: {ex.Message}
                    -\
                    """);
            }
        }
    }
}
