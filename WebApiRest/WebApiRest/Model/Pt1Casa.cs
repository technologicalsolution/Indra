using System;
using System.ComponentModel.DataAnnotations;

namespace WebApiRest.Model
{
    public class Pt1Casa
    {
        [Range(0,1)]
        public int Estado { get; set; }
    }
}
