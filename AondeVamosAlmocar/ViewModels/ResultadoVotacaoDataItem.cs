using System;

namespace AondeVamosAlmocar.ViewModels
{
    public class VotacaoDataItem
    {
        public DateTime Data { get; set; }
        public string DataFormatada => Data.ToString("dd/MM");
        public int IdRestaurante { get; set; }
        public string NmRestaurante { get; set; }
        public int QtdVotos { get; set; }
        public bool VotacaoFinalizada => DateTime.Today != Data;
    }
}