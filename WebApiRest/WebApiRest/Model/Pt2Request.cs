using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiRest.Model
{
    public class Pt2Request
    {
        public List<int> LstPaquetes { get; set; }
        public int TamanioCamion { get; set; }
    }
}
