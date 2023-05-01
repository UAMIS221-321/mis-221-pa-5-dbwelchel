namespace mis_221_pa_5_dbwelchel
{
    public class ManageTransactions
    {
         private Trainer[] trainers;
        private Transactions[] transaction;
        private Listings[] listing;
        public ManageTransactions(Trainer[] trainers, Transactions[] transaction, Listings[] listing) {
            this.trainers = trainers;
            this.transaction = transaction;
            this.listing = listing;
        }

        public void BookSession() {
            Transactions.SetCount(0);
            System.Console.WriteLine("To book, please select a Session ID or enter STOP to STOP");
            string input = Console.ReadLine().ToUpper();
            
            while(input != "STOP") {
                if(int.TryParse(input, out int selectID)) {
                int foundIndex = Find(selectID, listing);
                
                    if(foundIndex == -1) { 
                        System.Console.WriteLine("ID not found Please try again"); 
                        continue;
                    }
            
                transaction[Transactions.GetCount()] = new Transactions(0, "", "", "", selectID,"",  "");
                transaction[Transactions.GetCount()].SetSessionID(listing[foundIndex].GetListID());
                
                System.Console.WriteLine("Please enter a customer name");
                transaction[Transactions.GetCount()].SetCustName(Console.ReadLine().ToUpper());

                System.Console.WriteLine("Enter customer Email");
                transaction[Transactions.GetCount()].SetCustEmail(Console.ReadLine().ToUpper());
                 
                transaction[Transactions.GetCount()].SetTrainDate(listing[foundIndex].GetDate());
                transaction[Transactions.GetCount()].SetTrainerName(listing[foundIndex].GettName());
                
                //    
                int trainerIndex = FindTrainer(trainers, listing,foundIndex);
                if (trainerIndex == -1) {
                    System.Console.WriteLine("Trainer not found. Please try again.");
                    Console.ReadKey();
                return;
                }
                
                transaction[Transactions.GetCount()].SetTrainerID(trainers[trainerIndex].GetID());
                // 
                transaction[Transactions.GetCount()].SetTrainerName(listing[foundIndex].GettName());
                UpdateBooking(listing, foundIndex, selectID);
                transaction[Transactions.GetCount()].SetBooking(listing[foundIndex].GetAvailability());
                Transactions.IncCount();

                System.Console.WriteLine("Thank you for booking! Returning to Main Menu. ");
                input = "STOP";
                
            }
            else{
                System.Console.WriteLine("Please try again");
                input = Console.ReadLine().ToUpper();
                continue;
            }
            Save();
            }
        }   
        static int Find(int selectID, Listings[] listing) {
            for(int i = 0; i < listing.Length; i++) {
                if(listing[i] != null && listing[i].GetListID() == selectID) {
                    return i;
                }
            }
            return -1;
        }
    
        public int FindTrainer(Trainer[] trainers, Listings[] listing,int foundIndex) {
            int i = 0;
            string name = listing[foundIndex].GettName();
            
            while(trainers[i] != null) {
                if(trainers[i].GetName().ToString() == name) {
                    return i; 
                }
                    i++;
            }
            
            return -1;
        }
    

        public void UpdateBooking(Listings[] listing, int foundIndex, int sessionID) {
            if(listing[foundIndex].GetAvailability() == "NOT BOOKED" && listing[foundIndex].GetListID().ToString() == sessionID.ToString()) {
                listing[foundIndex].SetAvailability("BOOKED");
                SaveBooked(listing);
            }
        }
 

        public void Save() {
            StreamWriter outFile = new StreamWriter("TransactionInfo.txt", true);
            for(int i = 0; i < transaction.Length; i++) {
                if(transaction[i] != null) {
                    outFile.WriteLine(transaction[i].GetSessionID()+ "#" + transaction[i].GetCustName() + "#" + transaction[i].GetCustEmail() + "#"+ transaction[i].GetTrainDate() +"#" + transaction[i].GetTrainerID() +"#" + transaction[i].GetTrainerName() +"#" +transaction[i].GetBooking());
                }
            }
            outFile.Close();
        }     
            
            
            public void SaveBooked(Listings[] listing) {
                StreamWriter outFile = new StreamWriter("ListingInfo.txt", false);
                for(int i = 0; i < Listings.GetCount(); i++) {
                    if(listing[i] != null) {
                        outFile.WriteLine(listing[i].GetListID() + "#" + listing[i].GettName() +"#" +listing[i].GetDate() +"#" + listing[i].GetTime() +"#" +listing[i].GetCost() +"#" +  listing[i].GetAvailability());
                    }
                }
                outFile.Close();
            }  
        
        public void UpdateSession(){
            System.Console.WriteLine("Which would Session ID would you like to update? Or you can enter Stop to STOP");
            string input = Console.ReadLine().ToUpper();
            while(input != "STOP") {
                if(int.TryParse(input, out int selectID)) {
                    int foundIndex = FindUpdateID(selectID,transaction);
                    
                    if(foundIndex == -1) { 
                    System.Console.WriteLine("ID not found please try again or enter stop to STOP");
                    input = Console.ReadLine().ToUpper();
                    continue; 
                    }
                
                    else {

                                System.Console.WriteLine("Please enter an option:");
                                System.Console.WriteLine("COMPLETE : CANCEL : NO SHOW : STOP");
                                string updateChoice = Console.ReadLine().ToUpper();
                                while(updateChoice != "STOP"){
                                if(updateChoice == "COMPLETE") {
                                    System.Console.WriteLine("Thank you for training.");
                                    transaction[foundIndex].SetBooking("COMPLETED");
                                    Update();
                                    return;
                                }
                                if(updateChoice == "CANCEL" || updateChoice == "NO SHOW") {
                                    System.Console.WriteLine("Session Cancelled");
                                    transaction[foundIndex].SetBooking("CANCELLED");
                                    Update();
                                    Console.ReadKey();
                                    return;
                                }
                                
                                else {
                                    System.Console.WriteLine("Not a valid input. Would you like to COMPLETE or CANCEL?");
                                    updateChoice = Console.ReadLine().ToUpper();
                                }
                    }
                            }
                        }
                    }
                }
            
        
    
    public int FindUpdateID(int selectID, Transactions[] transaction) {
            string testID = selectID.ToString();
            for(int i = 0; i < transaction.Length; i++) {
                if(transaction[i] != null && transaction[i].GetSessionID() == selectID) {
                    return i;
                }
            }
            return -1;
        }
       public void PrintBookedSessions() {
            
            Console.WriteLine("Sessions currently booked");
                int i = 0;
                System.Console.WriteLine("test");
                while(transaction[i] != null) {
                    if(transaction[i].GetBooking() == "BOOKED") {
                    Console.WriteLine(transaction[i].ToFile());
                    }
                    i++;
                }   
                }
            
        
        public void Update() {
            Transactions.GetCount();
            StreamWriter outFile = new StreamWriter("TransactionInfo.txt", false);
            for(int i = 0; i < Transactions.GetCount(); i++) {
                if(transaction[i] != null) {
                outFile.WriteLine(transaction[i].GetSessionID()+ "#" + transaction[i].GetCustName() + "#" + transaction[i].GetCustEmail() + "#"+ transaction[i].GetTrainDate() +"#" + transaction[i].GetTrainerID() +"#" +transaction[i].GetTrainerName() +"#" +transaction[i].GetBooking());
                }
            }
            outFile.Close();
            }  

        public void GetAllBookingsFromFile() {
            Console.WriteLine("test");
            int i = 0;
            StreamReader inFile = new StreamReader("TransactionInfo.txt");
            string line = inFile.ReadLine();
            while(line != null && i < transaction.Length) {
                string[] temp = line.Split('#');
                transaction[i] = new Transactions(int.Parse(temp[0]), temp[1], temp[2], temp[3], int.Parse(temp[4]), temp[5], temp[6]);
                Transactions.IncCount();
                i++;
                line = inFile.ReadLine();
                
            }
            inFile.Close();
        }
    }
}