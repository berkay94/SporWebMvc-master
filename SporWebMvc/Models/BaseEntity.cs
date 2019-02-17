using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SporWebMvc.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }

        [DisplayName("Oluşturma Tarihi")]
        [DataType(DataType.Date)]
        [Column(TypeName = "DateTime2")]
        public DateTime CreateDate { get; set; }



        [DisplayName("Güncelleme Tarihi")]
        [DataType(DataType.Date)]
        [Column(TypeName = "DateTime2")]
        public DateTime UpdateDate { get; set; }
    }
}