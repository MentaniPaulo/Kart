using CorridaDeKart.Context;
using CorridaDeKart.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CorridaDeKart.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class KartController : ControllerBase
    {
        private readonly AppDbContext _context;
        public KartController(AppDbContext context)
        {
            _context = context;
        }
        List<string> myStrings = new List<string>();
        
        [HttpGet("ResultadoDaCorrida")]
        public List<Dictionary<string, string>> GetResult()
        {
            return winnersResult();
            //return winnerCode();
        }
      
        private ActionResult<List<string>> ListOfCodePilots()
        {
            return _context.logsOfRaces.Select(m => m.PilotCode).Distinct().ToList();
            
        }
        private List<string> winnerCode()
        {
            var finalistasCode = _context.logsOfRaces.OrderByDescending(m => m.Turn).OrderBy(m => m.Data).Select(m => m.PilotCode).Distinct().ToList();
            
            return finalistasCode;
        }
        private List<Dictionary<string, string>> winnersResult()
        {
            
            List<Dictionary<string, string>> result = new List<Dictionary<string, string>>();
            List<string> finalistaCode = winnerCode();
            int posicao = 1;
            foreach(var PilotCode in finalistaCode)
            {
                Dictionary<string, string> PilotResult = new Dictionary<string, string>();
                var PilotQuery = _context.logsOfRaces.Where(m => m.PilotCode == PilotCode);

                var name = PilotQuery.Where(m => m.Turn == 1).Select(m => m.PilotName).ToList();
                var code = PilotQuery.Where(m => m.Turn == 1).Select(m => m.PilotCode).ToList();
                var LapsNumber = PilotQuery.Max(m => m.Turn).ToString();

                var timeoStart = PilotQuery.Min(m => m.Data);
                var timeoEnd = PilotQuery.Max(m => m.Data);
                string timeOfRace = rangeOfTime(timeoStart, timeoEnd);


                PilotResult.Add("Posicao", posicao.ToString());
                PilotResult.Add("Codigo", code[0]);
                PilotResult.Add("Nome", name[0]);
                PilotResult.Add("Numero_de_voltas", LapsNumber);
                PilotResult.Add("tempo", timeOfRace);


                result.Add(PilotResult);
                posicao++;
            }
            return result;
        }
        private string rangeOfTime(DateTime timeoStart, DateTime timeoEnd)
        {
      
            int millisTimeStart = timeoStart.Millisecond + timeoStart.Second * 1000 + timeoStart.Minute * 1000 * 60 + timeoStart.Hour * 1000*60*60;
            int millisTimeEnd = timeoEnd.Millisecond + timeoEnd.Second * 1000 + timeoEnd.Minute * 1000 * 60 + timeoEnd.Hour * 1000 * 60 * 60;
            int millisTimeRace = millisTimeEnd - millisTimeStart;
            int horas = millisTimeRace / (60 * 60 * 1000);
            int minutes = (millisTimeRace - horas * 60 * 60 * 1000) / (60 * 1000);
            int seconds = (millisTimeRace - minutes * 60 * 1000)/1000;
            int millis = (millisTimeRace - seconds * 1000);
            string minutos_str;
            string seconds_str;
            if(minutes < 10)
            {
                minutos_str = "0"+minutes.ToString();
            }
            else
            {
                minutos_str = minutes.ToString();
            }
            if (seconds < 10)
            {
                seconds_str = "0" + seconds.ToString();
            }
            else
            {
                seconds_str = seconds.ToString();
            }

            return (minutos_str + ":"+ seconds_str + "."+millis.ToString());
        }
    }
}
