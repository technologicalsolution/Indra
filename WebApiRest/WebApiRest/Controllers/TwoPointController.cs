using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiRest.Model;

namespace WebApiRest.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TwoPointController : ControllerBase
    {
        [HttpPost]
        public ActionResult<Pt2Response> Post(Pt2Request Data)
        {
            return ValidateContent(Data);
        }

        private Pt2Response ValidateContent(Pt2Request Data)
        {
            int TotalEspacio = Data.TamanioCamion - 30;
            Pt2Response Result = new Pt2Response {
                Return = new List<int>()
            };

            if (Data.LstPaquetes.Sum() <= TotalEspacio)
            {
                Result.Return = Data.LstPaquetes;
            }
            else
            {                
                int EndValue = 0;
                while (!(EndValue == TotalEspacio))
                {
                    foreach (int item in Data.LstPaquetes)
                    {
                        foreach (int Subitem in Data.LstPaquetes)
                        {
                            if (item != Subitem)
                            {
                                if (item + Subitem == TotalEspacio)
                                {
                                    Result.Return.Add(item);
                                    Result.Return.Add(Subitem);
                                    EndValue = TotalEspacio;
                                    break;
                                }
                            }                            
                        }
                        if (EndValue == TotalEspacio)
                        {
                            break;
                        }
                    }
                }                
            }

            return Result;
        }
    }
}
