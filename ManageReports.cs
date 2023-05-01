namespace mis_221_pa_5_dbwelchel
{
    public class ManageReports
    {
        private Reports[] report;
        private Transactions[] transaction;
        private Listings[] listing;

        public ManageReports(Reports[] report,  Listings[] listing, Transactions[] transaction) {
            this.report = report;
            this.transaction = transaction;
            this.listing = listing;
        }


        public void GetEmailSelection() {
            
            System.Console.WriteLine("Enter customer email to view report or enter stop to STOP ");
           string getAnswer = "";
            string searchEmail = Console.ReadLine().ToUpper();
            while(searchEmail != "STOP" && getAnswer != "NO") {
                
                int searchVal = FindEmail(searchEmail, report,transaction);
                if(searchVal == -1) {
                   getAnswer = "";
                    while (getAnswer != "YES" && getAnswer != "NO") {
                    System.Console.WriteLine("Would you like to save this user history? Enter YES or NO");
                    getAnswer = Console.ReadLine().ToUpper();
                    }
            
                if(getAnswer == "YES") {
                    Save();
                    break;
                    
                }
               
                }
             else {
                System.Console.WriteLine("Please try again");
             }
           
                }
                   
        System.Console.WriteLine("Returning to Main Menu");
         Console.ReadKey();
}   
    
        
        public void GetAllTransactionsFromFile() {
            int i = 0;
            StreamReader inFile = new StreamReader("TransactionInfo.txt");
            
            string line = inFile.ReadLine();

            while (line != null) {
                if(i < transaction.Length) {
                string[] temp = line.Split('#');
                transaction[i] = new Transactions(int.Parse(temp[0]), temp[1], temp[2], temp[3], int.Parse(temp[4]), temp[5], temp[6]);
                Transactions.IncCount();
                i++;
                
            }
           line = inFile.ReadLine();
        }
         inFile.Close();
        }
        
        
      static int FindEmail(string searchEmail, Reports[] report, Transactions[] transaction) {
                Reports.SetCount(0);
                int i = 0;
                while(transaction[i] != null&& i < transaction.Length) {
                    
                    if(transaction[i].GetCustEmail() == searchEmail) {
                    
                     report[Reports.GetCount()] = new Reports(0, "", "", "", 0, "","");
                     report[Reports.GetCount()].SetSessionID(transaction[i].GetSessionID());
                        report[Reports.GetCount()].SetCustName(transaction[i].GetCustName());
                        report[Reports.GetCount()].SetCustEmail(transaction[i].GetCustEmail());
                        report[Reports.GetCount()].SetTrainDate(transaction[i].GetTrainDate());
                        report[Reports.GetCount()].SetTrainerID(transaction[i].GetTrainerID());
                        report[Reports.GetCount()].SetTrainerName(transaction[i].GetTrainerName());
                        report[Reports.GetCount()].SetBooking(transaction[i].GetBooking());
                        System.Console.WriteLine("Session: " + report[Reports.GetCount()].GetSessionID()+ " Customer: " + report[Reports.GetCount()].GetCustName() + " Customer Email: " + report[Reports.GetCount()].GetCustEmail() + " Date: "+ report[Reports.GetCount()].GetTrainDate() +" Trainer ID: " + report[Reports.GetCount()].GetTrainerID() +" Trainer Name: " + report[Reports.GetCount()].GetTrainerName() +" Status: " + report[Reports.GetCount()].GetBooking());
                        Reports.IncCount();
                        }  
                         
                         i++;
                    
                }
          return -1;
    }

        public void Save() {
                 
                        Reports.GetCount();
                        StreamWriter outFile = new StreamWriter("ReportsInfo.txt", true);
                        
                            for(int i = 0; i < Reports.GetCount(); i++) {
                            if(report[i]!= null) {
                                outFile.WriteLine(report[i].GetSessionID()+ "#" + report[i].GetCustName() + "#" + report[i].GetCustEmail() + "#"+ report[i].GetTrainDate() +"#" + report[i].GetTrainerID() +"#" +report[i].GetTrainerName() +"#" +report[i].GetBooking());
                            
                            }
                        
                    }
                    outFile.Close(); 
        }
         
    }
}