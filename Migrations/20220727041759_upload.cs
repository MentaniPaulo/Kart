using CorridaDeKart.Logs_corrida;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CorridaDeKart.Migrations
{
    public partial class upload : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            LeituraDoLog leituraLog = new LeituraDoLog();
            foreach (var log in leituraLog.ResultadoParcial)
            {
                migrationBuilder.Sql("INSERT INTO logsofraces(Data,PilotCode,PilotName,Turn,TimeOfTurn,Speed)" +
                $"VALUE('2000-01-01 {log.Data}','{log.PilotCode}','{log.PilotName}','{log.Turn}','2000-01-01 01:{log.TimeOfTurn}','{log.Speed.Replace(",", ".")}')");
            }
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM logsofraces");
        }
    }
}
