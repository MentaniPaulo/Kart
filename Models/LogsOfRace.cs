namespace CorridaDeKart.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class LogsOfRace
    {
        [Key]
        public int LogsOfRaceKey { get; set; }
        
        [Required]
        public DateTime Data { get; set; }
        [Required]
        [StringLength(80)]
        public string PilotCode { get; set; }
        [Required]
        [StringLength(80)]
        public string PilotName { get; set; }
        [Required]
        public int Turn { get; set; }
        [Required]
        public DateTime TimeOfTurn { get; set; }
        [Required]
        [Column(TypeName = "decimal(10,3)")]
        public decimal Speed { get; set; }
    }
}
