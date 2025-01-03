using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ScanInRecords.Models
{
    public class Record
    {
        [StringLength(10), MinLength(10)]
        [RegularExpression("^[0-9]*$")]
        [Required(ErrorMessage = "Enter a 10-digit card Id.")]
        [DisplayName("Card Id")]
        public string? CardId { get; set; }
        [DisplayName("Scan In Time")]
        public DateTime ScanInTime { get; set; }
    }
}
