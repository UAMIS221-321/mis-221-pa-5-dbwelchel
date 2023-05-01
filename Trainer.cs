namespace mis_221_pa_5_dbwelchel
{
    public class Trainer
    {   //instances
        private int identification;
        private string name;
        private string address;
        private string email;
        static private int count;
    
    //set constructors
        public Trainer(int identification, string name, string address, string email) {
            this.identification = identification;
            this.name = name;
            this.address = address;
            this.email = email;
        }
    //accessors and mutators
        public void SetID(int identification) {
            this.identification = identification;
        }
    
        public int GetID() {
            return identification;
        }

        public void SetName(string name) {
            this.name = name;
        }

        public string GetName() {
            return name;
        }

        public void SetAddress(string address) {
            this.address = address;
        }

        public string GetAddress() {
            return address;
        } 

        public void SetEmail(string email) {
            this.email = email;
        }

        public string GetEmail() {
            return email;
        } 
          public static void SetCount(int count) {
            Trainer.count = count;
        }
        
        public static void IncCount() {
            Trainer.count++;
        }

        public static int GetCount() {
            return Trainer.count;
        }

        public override string ToString() {
            return $"{identification}#{name}#{address}#{email}";
        }
    }
}