using System.ComponentModel.DataAnnotations;

namespace WMS.Domain.Entities
{
    public class HtmlSignature
    {
        [Key]
        public string Id { get; set; } //version1
        public string Content { get; set; }
    }
}
