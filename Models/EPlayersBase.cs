using System.Collections.Generic;
using System.IO;

namespace EXEMPLO_EPLAYERS_MVC.Models
{
    public class EPlayersBase       // 1 - Após apagar/comentar erros iniciais, criar superclasse que irá abstrair os métodos de criação de pastas e arquivos .csv;
    {
        public void CriarPastaEArquivo(string _caminho)
        {

            string pasta = _caminho.Split("/")[0];
            string arquivo = _caminho.Split("/")[1];

            if (!Directory.Exists(pasta))
            {
                Directory.CreateDirectory(pasta);
            }

            if (!File.Exists(_caminho))
            {
                File.Create(_caminho).Close();
            }

        }

        public List<string> LerTodasLinhasCSV(string _caminho)      //metodo alternativo aos metodos LerTodas, em cada Classe. Executa as mesmas funções
        {

            List<string> linhas = new List<string>();

            using (StreamReader file = new StreamReader(_caminho))      //executa função paralela ao foreach, lendo do o "caminho"
            {
                string linha;
                while ((linha = file.ReadLine()) != null)
                {
                    linhas.Add(linha);
                }
            }
            return linhas;
        }

        public void ReescreverCSV(string _caminho, List<string> linhas)     // atua em conjunto com o metodo LerTodasLinhasCSV, acima
        {
            using (StreamWriter output = new StreamWriter(_caminho))    // executa função paralela ao foreach, escrevendo no "caminho"
            {
                foreach (var item in linhas)
                {
                    output.Write(item + "\n");
                }
            }
        }
    }
}