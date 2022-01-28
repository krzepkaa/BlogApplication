using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApplication.Models
{
    public class PostModel
    {
        [Key]
        public int PostId { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Title { get; set; }

        [Column(TypeName = "nvarchar(500)")]
        [DisplayName("Post Context")]
        public string PostContext { get; set; }

        [Column(TypeName = "nvarchar(500)")]
        [DisplayName("Post Author")]
        public string Author { get; set; }

    }
}
