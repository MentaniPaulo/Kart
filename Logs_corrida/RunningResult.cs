namespace CorridaDeKart.Logs_corrida
{
    public class RunningResult
    {
        public struct Piloto
        {
            public string Name { get; set; }
            public string Code { get; set; }
            public string StartTime { get; set; }
            public string EndTime { get; set; }
            public List<string> LapsTime { get; set; }
            public int position { get; set; }
            public List<string> speed { get; set; }
        }
        public void analysis()
        {
            LeituraDoLog leituraDoLog = new LeituraDoLog();
            List<Piloto> pilotos = new List<Piloto>();

            foreach(var log in leituraDoLog.ResultadoParcial)
            {
                
                if (log.Turn == "1")
                {
                     Piloto driver = new Piloto();
                     firtInformation(ref driver, log);

                     pilotos.Add(driver);
                     continue;
                }
                else
                {
                    for(int i = 0; i < pilotos.Count; i++)
                    {
                        if(log.PilotCode == pilotos[i].Code)
                        {
                            Piloto piloto = pilotos[i];
                            List<string> LapsTime = new List<string>();
                            List<string> speed = new List<string>();

                            LapsTime = piloto.LapsTime;
                            LapsTime.Add(log.TimeOfTurn);
                            speed = piloto.speed;
                            speed.Add(log.Speed);
                            piloto.speed = speed;
                            piloto.LapsTime = LapsTime;

                            pilotos[i] = piloto;

                        }
                    }
                }                
            }
        }

        private void firtInformation(ref Piloto driver, Log logs)
        {
            driver.Name = logs.PilotName;
            driver.Code = logs.PilotCode;
            driver.StartTime = logs.Data;
         
            List<string> LapsTime = new List<string>();
            List<string> speed = new List<string>();

            LapsTime.Add(logs.TimeOfTurn);
            
            driver.LapsTime = LapsTime;

            speed.Add(logs.Speed);
            
            driver.speed = speed;
        }
    }
}
