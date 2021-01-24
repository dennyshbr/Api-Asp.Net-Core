using System;

namespace Negocio.Model
{
    public class Filme
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string AnoLancamento { get; set; }
        public byte IdIdiomaDublagem { get; set; }
        public byte? IdIdiomaOriginal { get; set; }
        public Int16? DuracaoEmMinutos { get; set; }
        public string Classificacao { get; set; }
        public byte[] ImagemCapa { get; set; }
    }
}
