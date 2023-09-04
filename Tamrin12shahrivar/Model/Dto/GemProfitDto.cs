using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tamrin12shahrivar.Model.Dto
{
    public class GemProfitDto
    {
        [Column(TypeName = "decimal(1,0)")]
        public decimal? WeightSumBuy { get; set; }
        [Column(TypeName = "decimal(1,0)")]
        public decimal? WeightSumSell { get; set; }
        public decimal PriceSumBuy { get; set; }
        public decimal PriceSumSell { get; set; }

        public string PriceSumBuyFormatted
        {
            get { return this.PriceSumBuy.ToString("N0"); }
        }

        public string PriceSumSellFormatted
        {
            get { return this.PriceSumSell.ToString("N0"); }
        }

        [Column(TypeName = "decimal(1,0)")]
        public decimal? Inventory { get { return WeightSumBuy - WeightSumSell ; } }
        [Column(TypeName = "decimal(1,0)")]
        public decimal? AverageBuy { get {return PriceSumBuy / Inventory  ; } }
        [Column(TypeName = "decimal(1,0)")]
        public decimal? AverageSell
        {
            get
            {
                if (PriceSumSell != 0) 
                {
                   return (PriceSumSell / WeightSumSell) ;
                }
                else
                {
                    
                    return 0; 
                }
            }
        }

        [Column(TypeName = "decimal(2,1)")]
        public decimal? Profit
        {
            get
            {
                var average = AverageBuy - AverageSell;
                if (average != AverageBuy)
                {
                    return AverageSell - AverageBuy  ;
                }
                else
                {
                    return 0;
                }


            }
        }

        public decimal? SumProfit { get { return (AverageSell * WeightSumSell)-(AverageBuy * WeightSumSell); } }

    }
}
