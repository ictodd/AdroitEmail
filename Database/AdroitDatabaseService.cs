using AdroitEmail.Database.Models;
using LiteDB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace AdroitEmail.Database {

    class AdroitDatabaseService {

        private const string APP_FOLDER = "Adroit Email";
        private const string DB_NAME = "adroit.db";
        private string APP_FOLDER_PATH => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), APP_FOLDER);
        private string DB_FILE_PATH => Path.Combine(APP_FOLDER_PATH, DB_NAME);

        public AdroitDatabaseService() {
            if (!Directory.Exists(APP_FOLDER_PATH)) 
                Directory.CreateDirectory(APP_FOLDER_PATH);

            var db = new LiteDatabase(DB_FILE_PATH);
            _col = db.GetCollection<Email>("emails");
            var mapper = BsonMapper.Global;
            mapper.Entity<Email>()
                .Id(x => x.Id);
        }

        private static AdroitDatabaseService _instance;
        private ILiteCollection<Email> _col;
        
        public static AdroitDatabaseService Instance {
            get {
                
                if(_instance == null) {
                    _instance = new AdroitDatabaseService();
                }
                return _instance;
            }
        }

        public ICollection<Email> AllEmails => _col.FindAll().ToList();
        public void AddEmail(Email email) => _col.Insert(email);
        public bool UpdateEmail(Email email) => _col.Update(email);
        public bool DeleteEmail(Email email) => _col.Delete(email.Id);
    }
}
