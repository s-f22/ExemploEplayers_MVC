using System.Collections.Generic;
using EXEMPLO_EPLAYERS_MVC.Models;

namespace EXEMPLO_EPLAYERS_MVC.Interfaces
{
    public interface IJogador
    {
         void CriarJogador(Jogador j1);
         List<Jogador> LerTodos();
         void AlterarJogador(Jogador j1);
         void Deletar(int _id);

    }
}