using System.Collections.Generic;

namespace Domain.Context
{
    public class DatabaseCommunication
    {
        public int ObjectId { get; set; }

        public List<DatabaseDeleteEstancias> listDeleted { get; set; }

        public string ErrorMessage { get; set; }
        public bool Result { get; set; }

        public DatabaseCommunication()
        {
            listDeleted = new List<DatabaseDeleteEstancias>();
        }

        public DatabaseCommunication(int pId)
        {
            ObjectId = pId;
            ErrorMessage = "";
            Result = true;
        }

        public DatabaseCommunication(string pErrorMessage)
        {
            Result = false;
            ErrorMessage = pErrorMessage;
        }
    }
}