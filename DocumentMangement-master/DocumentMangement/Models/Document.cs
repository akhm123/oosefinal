using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentMangement.Models
{
    class Document
    {
            public int DocumentId { get; set; }
            public string Name { get; set; }
            public string Type { get; set; }
            public string UserName { get; set; }
            //public string Username { get; set; }
            public string Url { get; set; }
            public bool IsSharable { get; set; }
            public bool IsStarred { get; set; }
         }

}
