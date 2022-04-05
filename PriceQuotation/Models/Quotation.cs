using System.ComponentModel.DataAnnotations;

namespace PriceQuotation.Models
{
    public class Quotation
    {

        [Required(ErrorMessage =
            "Please enter a subtotal.")]
        [Range(1, 999999999999999, ErrorMessage =
            "Subtotal must be one or more.")]
        public decimal? Subtotal { get; set; }


        [Required(ErrorMessage =
            "Please enter a discount percentage.")]
        [Range(1, 100, ErrorMessage =
            "Discount percentage must be from 1 to 100.")]
        public decimal? DiscountPercent { get; set; }

        decimal? TotalDiscount = 0;

        public decimal? CalculateTotal()
        {
            decimal? Total = 0;
            CalculateTotalDiscount();
            Total = Subtotal - TotalDiscount;
            return Total;
        }

        public decimal? CalculateTotalDiscount()
        {
            
            TotalDiscount = Subtotal * (DiscountPercent / 100);
            return TotalDiscount;
        }

        

    }
}