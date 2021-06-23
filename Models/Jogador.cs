using System;
using System.Collections.Generic;
using System.IO;
using EXEMPLO_EPLAYERS_MVC.Interfaces;

namespace EXEMPLO_EPLAYERS_MVC.Models
{
    public class Jogador : EPlayersBase, IJogador
    {
        public int IDJogador { get; set; }
        public string Nome { get; set; }
        public int IDEquipe { get; set; }

        public string Email { get; set; }
        
        public string Senha { get; set; }
        
        private const string CAMINHO = "DataBase/jogador.csv";  // CONSTANTE COM NOME E LOCAL DO ARQUIVO CSV



        public Jogador()    // CONSTRUTOR DE PASTA E CAMINHO
        {
            CriarPastaEArquivo(CAMINHO);
        }


        private string Preparar(Jogador j1)                     // Primeiro criar PREPARAR, depois CriarJogador()
        {
            return $"{j1.IDJogador};{j1.Nome};{j1.IDEquipe};{j1.Email};{j1.Senha}";
        }

        public void CriarJogador(Jogador j1)
        {
            string[] linha = { Preparar(j1) };
            File.AppendAllLines(CAMINHO, linha);

        }


        public void AlterarJogador(Jogador j1)
        {
            List<string> linhas = LerTodasLinhasCSV(CAMINHO);

            linhas.RemoveAll(x => x.Split(";")[0] == j1.IDEquipe.ToString()); // "remova tudo cuja primeira posição no array for igual ao IDequipe do objeto recebido - em string"
            linhas.Add( Preparar(j1) ); // Preparar() recebe um objeto e o retorna como string à lista
            ReescreverCSV(CAMINHO, linhas);
        }


        public void Deletar(int _id)
        {
            List<string> linhas = LerTodasLinhasCSV(CAMINHO);
            linhas.RemoveAll(x => x.Split(";")[0] == _id.ToString());
            
            ReescreverCSV(CAMINHO, linhas);
        }

        public List<Jogador> LerTodos()
        {
            List<Jogador> jogadores = new List<Jogador>();
            string[] linhas = File.ReadAllLines(CAMINHO);

            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");

                Jogador novoJogador = new Jogador();
                
                novoJogador.IDJogador = Int32.Parse( linha[0] );
                novoJogador.Nome = linha[1];
                novoJogador.IDEquipe = Int32.Parse( linha[2] );
                novoJogador.Email = ( linha[3] );
                novoJogador.Senha = ( linha[4] );

                jogadores.Add(novoJogador);
            }

            return jogadores;
        }
    }
}