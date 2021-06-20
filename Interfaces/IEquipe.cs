using System.Collections.Generic;
using EXEMPLO_EPLAYERS_MVC.Models;

namespace EXEMPLO_EPLAYERS_MVC.Interfaces
{
    public interface IEquipe    // 2 - CRIAR INTERFACES DA EQUIPE
    {
         void Criar(Equipe e);

         List<Equipe> LerTodas();

         void Alterar(Equipe e);

         void Deletar(int id);
    }
}