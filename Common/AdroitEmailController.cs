using AdroitEmail.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdroitEmail.Common {
    class AdroitEmailController {

        private static AdroitEmailController _instance;
        public static AdroitEmailController Instance {
            get {
                if(_instance == null) {
                    _instance = new AdroitEmailController();
                }
                return _instance;
            }
        }

        public Email CreateNewEmailItem(string name, List<string> recipients, string body, string subject, int sendDay) {
            var newItem = new Email() {
                Id = Guid.NewGuid().ToString(),
                Name = name,
                Subject = subject,
                Recipients = recipients,
                Body = body,
                SendDay = sendDay
            };
            return newItem;
        }
    }
}
