namespace mis_221_pa_5_dbwelchel
{
    public class Reports
    {
         private int sessionID;
        private string custName;
        private string custEmail;
        private string trainDate;
        private int trainerID;
        private string trainerName;
        private string booking;
        private static int count;

        public Reports(int sessionID,string custName, string custEmail, string trainDate, int trainerID, string trainerName, string booking) {
            this.sessionID = sessionID;
            this.custName = custName;
            this.custEmail = custEmail;
            this.trainDate = trainDate;
            this.trainerID = trainerID;
            this.trainerName = trainerName;
            this.booking = booking;
        }
        
         public void SetSessionID(int sessionID) {
            this.sessionID = sessionID;
        }

        public int GetSessionID() {
            return sessionID;
        }
        public void SetCustName(string custName) {
            this.custName = custName;
        }
        public string GetCustName() {
            return custName;
        }
        public void SetCustEmail(string custEmail) {
            this.custEmail = custEmail;
        }
        public string GetCustEmail() {
            return custEmail;
        }
        public void SetTrainDate(string trainDate) {
            this.trainDate = trainDate;
        }
        public string GetTrainDate() {
            return trainDate;
        }
        public void SetTrainerID(int trainerID) {
            this.trainerID = trainerID;
        }
        public int GetTrainerID() {
            return trainerID;
        }
        public void SetTrainerName(string trainerName) {
            this.trainerName = trainerName;
        }
        public string GetTrainerName() {
            return trainerName;
        }
        public void SetBooking(string booking) {
            this.booking = booking;
        }
        public string GetBooking() {
            return booking;
        }
        
        public static void SetCount(int count) {
            Reports.count = count;
        }
        

        public static int GetCount() {
            return Reports.count;
        }

        public static void IncCount() {
            Reports.count++;
        }
       
        // public override string EmailToString() {
        //     return $"Session: {sessionID} Customer: {custName} Customer Email: {custEmail} Date: {trainDate} Trainer ID: {trainerID} Trainer Name: {trainerName} Availability: {booking}";
        // }
        public override string ToString() {
            return $"{sessionID}#{custName}#{custEmail}#{trainDate}#{trainerID}#{trainerName}#{booking}";

        }
    }
}