namespace mis_221_pa_5_dbwelchel
{
    public class Listings
    {
        private int listID;
        private string tName;
        private string date;
        private string time;
        private int cost;
        private string availability;
        static private int count;
        
        // private Trainer[] trainers;
        public Listings(int listID, string tName, string date, string time, int cost, string availability) {
            // this.trainers = trainers;
            this.listID = listID;
            this.tName = tName;
            this.date = date;
            this.time = time;
            this.cost = cost;
            this.availability = availability;
        }

        public void SetListID(int listID) {
            this.listID = listID;
        }

        public int GetListID() {
            return listID;
        }
        public void SettName(string tName) {
            this.tName = tName;
        }
        public string GettName() {
            return tName;
        }
        public void SetDate(string date) {
            this.date = date;
        }
        public string GetDate() {
            return date;
        }
        public void SetTime(string time) {
            this.time = time;
        }
        public string GetTime() {
            return time;
        }
        public void SetCost(int cost) {
            this.cost = cost;
        }
        public int GetCost() {
            return cost;
        }
        public void SetAvailability(string availability) {
            this.availability = availability;
        }
        public string GetAvailability() {
            return availability;
        }
        public static void SetCount(int count) {
            Listings.count = count;
        }
        

        public static int GetCount() {
            return Listings.count;
        }

        public static void IncCount() {
            Listings.count++;
        }
        public string ToFile() {
            return $"Session:{listID} Trainer: {tName} Date: {date} Time: {time} Cost: {cost} Availability: {availability}";
        }
        public override string ToString() {
            return $"{listID}#{tName}#{date}#{time}#{cost}#{availability}";
        }

    }
}