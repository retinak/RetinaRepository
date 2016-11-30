using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace SASSMMS.Domain.Entities
{
    public class Comment
    {
        public Guid  CommentId { get; set; }
        public string Content { get; set; }
       
        public Guid CommentGivenToId { get; set; }
       [ForeignKey("CommentGivenToId")]
        public virtual Member Member { get; set; }
    }
}
