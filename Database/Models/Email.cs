using System;
using System.Collections.Generic;

namespace AdroitEmail.Database.Models {
    public class Email {
        [System.ComponentModel.Browsable(false)]
        public string Id { get; set; }
        public string Name { get; set; }
        public List<string> Recipients { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public int SendDay { get; set; }
        public DateTime LastSent { get; set; }
    }
}
