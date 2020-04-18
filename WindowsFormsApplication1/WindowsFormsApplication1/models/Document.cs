using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WindowsFormsApplication1
{
    public class Document
    {
        public int DocumentId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int UserId { get; set; }
        public string Url { get; set; }
        public bool IsSharable { get; set; }
        public bool IsStarred { get; set; }
    }
}