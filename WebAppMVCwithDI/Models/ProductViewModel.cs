using Domain;
using System.Globalization;

namespace WebAppMVCwithDI.Models
{
    public class ProductViewModel
    {
        private static CultureInfo PriceCulture = new CultureInfo("uk-UA");
        public string SummaryText { get;}

        public ProductViewModel(DiscountedProduct discountedProduct)
        {
            this.SummaryText = string.Format(PriceCulture, "{0} ({1:C})", discountedProduct.Name, discountedProduct.UnitPrice);
        }

        public ProductViewModel(string name, decimal unitPrice)
        {
            this.SummaryText = string.Format(PriceCulture, "{0} ({1:C})", name, unitPrice);
        }

    }
}
