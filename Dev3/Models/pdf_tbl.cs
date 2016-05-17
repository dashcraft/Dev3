namespace Dev3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class pdf_tbl
    {
        [Key]
        public int bookId { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("First Name")]
        public string authFirstName { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Last Name")]
        public string authLastName { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Company Name")]
        public string bookTitle { get; set; }

        [Required]
        [DisplayName("Prologe")]
        public string bookPrologue { get; set; }

        [Required]
        [DisplayName("Username")]
        public string userName { get; set; }
    }
}
