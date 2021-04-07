using System.ComponentModel.DataAnnotations;

namespace Services.Dto
{
    public class LocationDto
    {
        [Required, StringLength(20)]
        public string Lat { get; set; }
        [Required, StringLength(20)]
        public string Long { get; set; }
    }
}
