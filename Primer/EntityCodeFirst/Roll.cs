namespace Primer.EntityCodeFirst
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Roll")]
    public partial class Roll
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int Width { get; set; }

        public int Length { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        public int Amount { get; set; }

        public int IdCountry { get; set; }

        public int IdColor { get; set; }

        public int IdStructure { get; set; }

        public virtual Color Color { get; set; }

        public virtual Country Country { get; set; }

        public virtual Structure Structure { get; set; }
    }
}
