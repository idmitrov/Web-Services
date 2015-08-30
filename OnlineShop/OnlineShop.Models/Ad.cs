namespace OnlineShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Ad
    {
        private ICollection<Category> categories;

        public Ad()
        {
            this.categories = new HashSet<Category>();
        }

        // ID
        [Key]
        public int Id { get; set; }

        // NAME
        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        // DESCRIPTION
        public string Description { get; set; }

        // PRICE
        [Required]
        public decimal Price { get; set; }

        // POSTED ON
        [Required]
        public DateTime PostedOn { get; set; }

        // CLOSED ON
        public DateTime? ClosedOn { get; set; }

        // STATUS
        public AdStatus Status { get; set; }

        // TYPE
        [ForeignKey("Type")]
        public int TypeId { get; set; }
        public virtual AdType Type { get; set; }

        // OWNER
        public string OwnerId { get; set; }
        public virtual ApplicationUser Owner { get; set; }

        // CATEGORIES
        public virtual ICollection<Category> Categories
        {
            get { return this.categories; }
            set { this.categories = value; }
        }
    }
}
