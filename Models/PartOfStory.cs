using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Talamus_Veronica.Models
{
    public class PartOfStory
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string? SubsequentPartsIds { get; set; }
        public bool SetSubsequent { get; set; }
    }
}
