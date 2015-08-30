namespace OnlineShop.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class AdType
    {
        private ICollection<Ad> ads;

        public AdType()
        {
            this.ads = new HashSet<Ad>();
        }
        // ID
        [Key] 
        public int Id { get; set; }

        // INDEX
        public int Index { get; set; }

        // NAME
        [Required]
        public string Name { get; set; }

        // PRICE PER DAY
        [Required]
        public decimal PricePerDay { get; set; }

        // ADS
        public virtual ICollection<Ad> Ads
        {
            get { return this.ads; }
            set { this.ads = value; }
        }
    }
}
