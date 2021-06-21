using System;
using EXEMPLO_EPLAYERS_MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EXEMPLO_EPLAYERS_MVC.Controllers
{
    [Route("Jogador")]

    public class JogadorController : Controller     // Deve herdar a classe AspNet Controller
    {
        Jogador jogadorModel = new Jogador();

        [Route("Listar")]
        public IActionResult Index()
        {
            ViewBag.Jogadores = jogadorModel.LerTodos();
            return View();
        }

        [Route("Cadastrar")]
        public IActionResult Cadastrar(IFormCollection form)
        {
            Jogador novoJogador = new Jogador();

            novoJogador.IDJogador = Int32.Parse(form[ "IDJogador" ]);
            novoJogador.Nome = form[ "Nome" ];
            novoJogador.IDEquipe = Int32.Parse(form[ "IDEquipe" ]);

            jogadorModel.CriarJogador(novoJogador);

            ViewBag.Jogadores = jogadorModel.LerTodos();

            return LocalRedirect( "~/Jogador" );
        }

    }



}