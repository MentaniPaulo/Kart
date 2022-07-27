using CorridaDeKart.Models;
using System.Text.RegularExpressions;

namespace CorridaDeKart.Logs_corrida
{
    public struct Log
    {
        public string Data { get; set; }
        public string PilotCode { get; set; }
        public string PilotName { get; set; }
        public string Turn { get; set; }
        public string TimeOfTurn { get; set; }
        public string Speed { get; set; }
    }
    public class LeituraDoLog
    {
        //public List<List<string>> ResultadoParcial = new List<List<string>>();
        public List<Log> ResultadoParcial = new List<Log>();

        public LeituraDoLog()
        {
            readFile();
        }
        private void readFile()
        {
            string file = System.IO.File.ReadAllText(@"Logs_corrida\LogsDaCorrida.txt");
            
            string[] resultadosIndividuais = file.Split('\n');

            foreach (var linha in resultadosIndividuais)
            {

                List<string> logs = new List<string>();
                
                var linhaLimpa = Regex.Replace(linha, "–", " ");
                linhaLimpa = Regex.Replace(linhaLimpa, @"\s+", " ");
                var colunas = linhaLimpa.Split(' ');
                if(colunas.Count() >= 6)
                {
                    Log log = new Log();
                    log.Data = colunas[0];
                    log.PilotCode = colunas[1];
                    log.PilotName = colunas[2];
                    log.Turn = colunas[3];
                    log.TimeOfTurn = colunas[4];
                    log.Speed = colunas[5];
                    ResultadoParcial.Add(log);
               }
      
            }
        }
    }
}
