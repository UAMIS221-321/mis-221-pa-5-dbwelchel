namespace mis_221_pa_5_dbwelchel
{
    public class ManageListing
    {
        
        private Listings[] listing;
        public ManageListing(Listings[] listing) {
            this.listing = listing;
            
        }
           public void AddListing() {
            Listings.SetCount(0);
        
            System.Console.WriteLine("Please enter 3 digit Listing ID. Enter STOP to stop");
            string userInput = Console.ReadLine().ToUpper();
        
            while(userInput.ToUpper() != "STOP") {
                if(userInput == "STOP") {
                    break;
                }
                if(int.TryParse(userInput, out int IDgot)) {
                    int foundIndex = Find(userInput, listing);
                
                
                listing[Listings.GetCount()] = new Listings(IDgot, "", "", "", 0, "");
                listing[Listings.GetCount()].SetListID(IDgot);
                
                System.Console.WriteLine("Please enter Trainer Name");
                listing[Listings.GetCount()].SettName(Console.ReadLine().ToUpper());

                System.Console.WriteLine("Enter Date of Session");
                listing[Listings.GetCount()].SetDate(Console.ReadLine());
                 
                System.Console.WriteLine("Enter time of session");
                listing[Listings.GetCount()].SetTime(Console.ReadLine());
                
                System.Console.WriteLine("Enter Cost of session");
                listing[Listings.GetCount()].SetCost(int.Parse(Console.ReadLine()));

                System.Console.WriteLine("Enter one of the following for Availability: BOOKED : NOT BOOKED");
                listing[Listings.GetCount()].SetAvailability(Console.ReadLine().ToUpper());
               
                Listings.IncCount();
                System.Console.WriteLine("To add another listing, enter another Listing ID or enter stop to STOP");
                userInput = Console.ReadLine().ToUpper();
                }

                else { 
                    System.Console.WriteLine("Please try again"); 
                    continue;
                }
                
            }
            Save();
           }
        
          public void EditListing() {
                
                
                System.Console.WriteLine("Which Listing would you like to edit?");
                string searchVal = Console.ReadLine();
                
                int foundIndex = Find(searchVal, listing);
                    if(foundIndex != -1) {
                        System.Console.WriteLine("Please enter Listing ID: 3 digits");
                        listing[foundIndex].SetListID(int.Parse(Console.ReadLine()));
                        
                        System.Console.WriteLine("PLease enter Name");
                        listing[foundIndex].SettName(Console.ReadLine().ToUpper());
                        
                        System.Console.WriteLine("Please date");
                        listing[foundIndex].SetDate(Console.ReadLine().ToUpper());
                        
                        System.Console.WriteLine("Enter time");
                        listing[foundIndex].SetTime(Console.ReadLine().ToUpper());

                        System.Console.WriteLine("Enter cost");
                        listing[foundIndex].SetCost(int.Parse(Console.ReadLine()));

                        System.Console.WriteLine("Enter Availability: BOOKED or NOT BOOKED");
                        string bookingCheck = Console.ReadLine().ToUpper();
                        while(bookingCheck != "BOOKED" && bookingCheck != "NOT BOOKED") {
                            System.Console.WriteLine("Please try again");
                            bookingCheck = Console.ReadLine().ToUpper();
                            

                        }
                        System.Console.WriteLine("Updated!");
                        listing[foundIndex].SetAvailability(bookingCheck);
                        Update();

                    }
                    else {
                        System.Console.WriteLine("Listing was not found");
                    }
                       
               }   
               

public void DeleteListing() {
    System.Console.WriteLine("Please enter ID of the session you want to delete");
            int searchVal = int.Parse(Console.ReadLine());

            int foundIndex = DeleteFind(searchVal, listing);
            if (foundIndex != -1)
            {
                listing[foundIndex] = null;
                Update();
                System.Console.WriteLine("Session has been deleted");
            }
            else
            {
                System.Console.WriteLine("Session was not found");
            }
        }



        public void Save() {
            Listings.GetCount();
            StreamWriter outFile = new StreamWriter("ListingInfo.txt", true);
            for(int i = 0; i < Listings.GetCount(); i++) {
                if(listing[i]!= null) {
                outFile.WriteLine(listing[i].GetListID()+ "#" + listing[i].GettName() + "#" + listing[i].GetDate() + "#"+ listing[i].GetTime() +"#" + listing[i].GetCost() + "#" +listing[i].GetAvailability());
                }
            }
            outFile.Close();
        }
         
         public void Update() {
            Listings.GetCount();
            StreamWriter outFile = new StreamWriter("ListingInfo.txt", false);
            for(int i = 0; i < Listings.GetCount(); i++) {
                if(listing[i] != null) {
                outFile.WriteLine(listing[i].GetListID()+ "#" + listing[i].GettName() + "#" + listing[i].GetDate() + "#"+ listing[i].GetTime() + "#" + listing[i].GetCost() +"#" + listing[i].GetAvailability());
                }
            }
            outFile.Close();
            }  


        public void GetAllListingsFromFile() {
            int i = 0;
            StreamReader inFile = new StreamReader("ListingInfo.txt");
            string line = inFile.ReadLine();

            while (line != null && i < listing.Length) {
                string[] temp = line.Split('#');
                listing[i] = new Listings(int.Parse(temp[0]), temp[1], temp[2], temp[3], int.Parse(temp[4]), temp[5]);
                Listings.IncCount();
                i++;
                line = inFile.ReadLine();
            }
            inFile.Close();
        }

    
        static int Find(string userInput, Listings[] listing) {
            for(int i = 0; i < listing.Length; i++) {
                if(listing[i] != null && listing[i].GetListID().ToString() == userInput) {
                    return i;
                }
        
            }
            return -1;
        }
        static int DeleteFind(int searchVal, Listings[] listing) {
            for(int i = 0; i < listing.Length; i++) {
                if(listing[i] != null && listing[i].GetListID() == searchVal) {
                    return i;
                }
        
            }
            return -1;
        }
 
        public void PrintAllListings() {
            int i = 0;
            Console.WriteLine("Available Sessions");
            
                
                while(listing[i] != null) {
                    Console.WriteLine(listing[i].ToFile());
                    i++;
                }   
         
            }
            public void PrintNotBookedListings() {
            int i = 0;
            Console.WriteLine("Available Sessions");
                while(listing[i] != null) {
                    if(listing[i].GetAvailability().ToString() == "NOT BOOKED") {
                        Console.WriteLine(listing[i].ToFile());
                        
                    }
                    i++;
                }   
         
            }
    }
}