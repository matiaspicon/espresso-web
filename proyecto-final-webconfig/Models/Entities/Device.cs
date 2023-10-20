using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proyecto_final_webconfig.Models.Entities
{
    [Table("devices")]
    public class Device
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        [Column("mac_source")]
        public string MacSource { get; set; }

        [MaxLength(255)]
        [Column("description")]
        public string? Description { get; set; }

        [Column("events_detected")]
        public int EventsDetected { get; set; }

        [Column("last_timestamp")]
        public DateTime LastTimestamp { get; set; }
    }
}



