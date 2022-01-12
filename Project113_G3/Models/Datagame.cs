namespace Project113_G3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Datagame")]
    public partial class Datagame
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string NameGame { get; set; }

        [StringLength(50)]
        public string TypeGame { get; set; }

        [StringLength(250)]
        public string Description_Game { get; set; }

        [StringLength(50)]
        public string url { get; set; }
    }
}
