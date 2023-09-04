using System.ComponentModel.DataAnnotations.Schema;

namespace Tamrin12shahrivar.Model
{
    public class Gem
    {
        public Guid GemId { get; set; }

        public DateTime Data { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Weight { get; set; }

        public int cutie { get; set; }

        public long Price { get; set; }



        public string Status { get; set; }

    }
}
