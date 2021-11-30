using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApiRest.Model;

namespace WebApiRest.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OnePointController : ControllerBase
    {
        [HttpPost]
        public ActionResult<Pt1Response> Post(Pt1Request Data)
        {
            Pt1Response Result = new Pt1Response
            {
                Dias = Data.Dias,
                Entrada = Data.LsCasas,
                Salida = ResultDays(Data)
            };
            return Result;
        }

        private List<Pt1Casa> ResultDays(Pt1Request Data)
        {
            List<Pt1Casa> Temp = Data.LsCasas;
            List<Pt1Casa> Result = new List<Pt1Casa>();

            for (int a = 0; a < Data.Dias; a++)
            {
                for (int i = 0; i < Temp.Count(); i++)
                {
                    if (i == 0)
                    {
                        Result.Add(new Pt1Casa { Estado = (Temp[i + 1].Estado == 0) ? 0 : 1 });
                    }
                    else if (i == Temp.Count() - 1)
                    {

                        Result.Add(new Pt1Casa { Estado = (Temp[i - 1].Estado == 0) ? 0 : 1 });
                    }
                    else
                    {
                        Result.Add(new Pt1Casa { Estado = (Temp[i - 1].Estado == Temp[i + 1].Estado) ? 0 : 1 });
                    }
                }
                if (a < Data.Dias)
                {
                    Temp = Result;
                    if (a != Data.Dias - 1)
                    {
                        Result = new List<Pt1Casa>();
                    }                   
                }
            }

            if (Data.Dias == 0)
            {
                Result = Data.LsCasas;
            }

            return Result;
        }
    }
}
