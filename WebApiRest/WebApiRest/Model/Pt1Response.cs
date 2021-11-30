using System.Collections.Generic;

namespace WebApiRest.Model
{
    public class Pt1Response
    {
        public int Dias { get; set; }
        public List<Pt1Casa> Entrada { get; set; }
        public List<Pt1Casa> Salida { get; set; }
    }
}
