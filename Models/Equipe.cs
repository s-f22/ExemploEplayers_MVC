using System;
using System.Collections.Generic;
using System.IO;
using EXEMPLO_EPLAYERS_MVC.Interfaces;

namespace EXEMPLO_EPLAYERS_MVC.Models
{
    public class Equipe : EPlayersBase, IEquipe // 3 - HERDAR SUPERCLASSE E INTERFACE
    {
        public int IDEquipe { get; set; }
        
        public string Nome { get; set; }
        
        public string Imagem { get; set; }

        private const string CAMINHO = "DataBase/equipe.csv"; //4.	Criar construtor para pasta/arquivo logo ao iniciar primeiro objeto;

        public Equipe(){                    //4.	Criar construtor para pasta/arquivo logo ao iniciar primeiro objeto;
            CriarPastaEArquivo(CAMINHO);
        }

        private string Preparar(Equipe e){

            return $"{e.IDEquipe};{e.Nome};{e.Imagem}";
        }

        public void Alterar(Equipe e)
        {
            List<string> linhas = LerTodasLinhasCSV(CAMINHO);
            linhas.RemoveAll(x => x.Split(";")[0] == e.IDEquipe.ToString());
            linhas.Add(Preparar(e));
            ReescreverCSV(CAMINHO, linhas);
        }

        public void Criar(Equipe e)
        {
            string[] linha = {Preparar(e)};
            File.AppendAllLines(CAMINHO, linha);
        }

        public void Deletar(int id)
        {
            List<string> linhas = LerTodasLinhasCSV(CAMINHO);
            linhas.RemoveAll(x => x.Split(";")[0] == id.ToString());
            
            ReescreverCSV(CAMINHO, linhas);
        }

        public List<Equipe> LerTodas()
        {
            List<Equipe> equipes = new List<Equipe>();

            string[] linhas = File.ReadAllLines(CAMINHO);
            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");
                Equipe equipe = new Equipe();
                equipe.IDEquipe = Int32.Parse(linha[0]);
                equipe.Nome = linha[1];
                equipe.Imagem = linha[2];

                equipes.Add(equipe);
            }

            return equipes;
        }
    }
}