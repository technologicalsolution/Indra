using System.Collections.Generic;

namespace WebApiRest.Model
{
    public class Pt1Request
    {
        public List<Pt1Casa> LsCasas { get; set; }        
        public int Dias { get; set; }
    }
}
