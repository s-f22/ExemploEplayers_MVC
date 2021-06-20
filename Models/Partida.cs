using System;

namespace EXEMPLO_EPLAYERS_MVC.Models
{
    public class Partida
    {
        public int IDPartida { get; set; }
        
        public int IDJogador1 { get; set; }
        
        public int IDJogador2 { get; set; }
        
        public DateTime HorarioInicio { get; set; }
        
        public DateTime HorarioTermino { get; set; }
    }
}