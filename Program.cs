using mis_221_pa_5_dbwelchel;
// main
Trainer[] trainers = new Trainer[100];
ManageTrainer selectTrainer = new ManageTrainer(trainers);


Listings[] listing = new Listings[100];
ManageListing selectListing = new ManageListing(listing);

Transactions[] transaction = new Transactions[100];
ManageTransactions selectTransaction = new ManageTransactions(trainers, transaction,listing);
Reports[] report = new Reports[100];
ManageReports selectReport = new ManageReports(report, listing, transaction);

int letsRoute = MainMenu();
MenuRoute(letsRoute, trainers, selectTrainer, listing, selectListing, transaction, selectTransaction, report, selectReport);

static int MainMenu() {
    
    bool getMenu = true;
    int getChoice = 0;
    // getMenu runs a loop until a correct input is made
    while(getMenu) {
        Console.WriteLine("Main Menu");
        System.Console.WriteLine("Please choose an option:");
        System.Console.WriteLine("1. Manage Trainers");
        System.Console.WriteLine("2. Manage Listings");
        System.Console.WriteLine("3. Manage Bookings");
        System.Console.WriteLine("4. Manage Reports");
        System.Console.WriteLine("5. Exit");
        string tryChoice = Console.ReadLine();
        if(int.TryParse(tryChoice, out getChoice) && getChoice >= 1 && getChoice <= 5) {
            getMenu = false;
        } else {
            System.Console.WriteLine("Invalid input, please try again");
            Console.ReadKey();
            Console.Clear();
        }

    }
    return getChoice;
}
//Make a menu selection 
static void MenuRoute(int letsRoute, Trainer[] trainers, ManageTrainer selectTrainer, Listings[] listing, ManageListing selectListing, Transactions[] transaction, ManageTransactions selectTransaction, Reports[] report, ManageReports selectReport) {
    bool intCheck = true; 
    while(intCheck) {
        if(letsRoute == 1) {
            int trainerChoice = 0;
            System.Console.WriteLine("Please select an option");
            System.Console.WriteLine("1:Add a trainer");
            System.Console.WriteLine("2: Delete a trainer");
            System.Console.WriteLine("3: Edit a trainer");
            System.Console.WriteLine("4. Exit to Main Menu");
            string tryTrainer = Console.ReadLine();
            if(int.TryParse(tryTrainer, out trainerChoice) && trainerChoice >=1 && trainerChoice <=4) {
                TrainerMenu(trainerChoice, trainers, selectTrainer, listing, selectListing, letsRoute);
            }
            else{
                System.Console.WriteLine("Please try again");
                continue;
            }
            Console.ReadKey();
           
        }
        
        else if(letsRoute == 2) {
            int listingChoice = 0;
            System.Console.WriteLine("Please select an option");
            System.Console.WriteLine("1. Add a listing");
            System.Console.WriteLine("2. Delete a listing");
            System.Console.WriteLine("3. Edit a listing");
            System.Console.WriteLine("4. Exit to Main Menu");
            string trySession = Console.ReadLine();
              if(int.TryParse(trySession, out listingChoice) && listingChoice >=1 && listingChoice <=4) {
                ListingMenu(listingChoice, trainers, selectTrainer, listing, selectListing, letsRoute);
            }
            else{
                System.Console.WriteLine("Please try again");
                continue;
            }
            Console.ReadKey();
            
        }
        
        else if(letsRoute == 3) {
            int bookingChoice = 0;
            selectListing.GetAllListingsFromFile();
            selectListing.PrintNotBookedListings();
            System.Console.WriteLine("Please select an option");
            System.Console.WriteLine("1: Make a Booking");
            System.Console.WriteLine("2. Update Customer Session");
            System.Console.WriteLine("3. Exit to Main Menu");
            
            string tryOption = Console.ReadLine();
            if(int.TryParse(tryOption, out bookingChoice) && bookingChoice >=1 && bookingChoice <=3) {
                BookingMenu(bookingChoice, trainers, selectTrainer, listing,  selectListing,letsRoute, transaction, selectTransaction);
            }
            else{
                System.Console.WriteLine("Please try again");
                continue;
            }
           Console.ReadKey();
        }
        
        else if(letsRoute == 4) {
            int reportChoice = 0;
            System.Console.WriteLine(" Please select an option");
            System.Console.WriteLine("1. View Customer Sessions");
            System.Console.WriteLine("2. View Revenue History");
            System.Console.WriteLine("3. View Historical Revenue Report");
            System.Console.WriteLine("4. Save Report");
            string tryReport = Console.ReadLine();
            if(int.TryParse(tryReport, out reportChoice) && reportChoice >=1 && reportChoice <=4) {
                ReportMenu(reportChoice, trainers, selectTrainer, listing,  selectListing,letsRoute, transaction, selectTransaction, report, selectReport);
            }
            else{
                System.Console.WriteLine("Please try again");
                continue;
            }
            Console.ReadKey();
            
        }
        else if (letsRoute == 5) {
            break;
        }
        letsRoute = MainMenu();
    }
}
//Trainer menu
static void TrainerMenu(int trainerChoice, Trainer[] trainers, ManageTrainer selectTrainer, Listings[] listing, ManageListing selectListing, int letsRoute) {
    while(trainerChoice != 4) {
        if(trainerChoice == 1) {
            selectTrainer.AddTrainers();
            break;
        }
    
        if(trainerChoice == 2) {
            selectTrainer.GetAllTrainersFromFile();
            selectTrainer.PrintAllTrainers();
            selectTrainer.DeleteTrainer();
            break;
        
        }
    
        if(trainerChoice == 3) {  
            selectTrainer.GetAllTrainersFromFile();
            selectTrainer.EditTrainers();
           break;
        }
    
        if(trainerChoice == 4) {
            letsRoute = MainMenu();
            break;
        }
    }
}
    

//Listing menu
static void ListingMenu(int listingChoice,Trainer[] trainers, ManageTrainer selectTrainer, Listings[] listing, ManageListing selectListing, int letsRoute) {
    while(listingChoice != 4) {
    if(listingChoice == 1) {
        selectListing.AddListing();
        break;
    }
    if(listingChoice == 2) {
        selectListing.GetAllListingsFromFile();
        selectListing.PrintAllListings();
        selectListing.DeleteListing();
        break;
    }
    if(listingChoice == 3) {
        selectListing.GetAllListingsFromFile();
        selectListing.PrintAllListings();
        selectListing.EditListing();
        
        Console.ReadKey();
        break;
     if(listingChoice == 4) {
        letsRoute = MainMenu();
     }   
    }
    }
}
//Booking Menu 
static void BookingMenu(int bookingChoice, Trainer[] trainers, ManageTrainer selectTrainer, Listings[] listing, ManageListing selectListing, int letsRoute, Transactions[] transaction, ManageTransactions selectTransaction) {
    if(bookingChoice == 1) {
        selectTrainer.GetAllTrainersFromFile();
        //selectTrainer.PrintAllTrainers();
        selectListing.GetAllListingsFromFile();
        selectListing.PrintNotBookedListings();
        
        selectTransaction.BookSession();
        letsRoute = MainMenu();
    }
    if(bookingChoice == 2) {
        selectTrainer.GetAllTrainersFromFile();
        //selectTrainer.PrintAllTrainers();
        //selectListing.GetAllListingsFromFile();
        selectTransaction.GetAllBookingsFromFile();
        selectTransaction.PrintBookedSessions();
        selectTransaction.UpdateSession();
        Console.ReadKey();
    }
    if(bookingChoice == 3) {
        letsRoute = MainMenu();
    }
}
//Report Menu
static void ReportMenu(int reportChoice, Trainer[] trainers, ManageTrainer selectTrainer, Listings[] listing, ManageListing selectListing, int letsRoute, Transactions[] transaction, ManageTransactions selectTransaction, Reports[] report, ManageReports selectReport) {
    if(reportChoice == 1) {
    selectReport.GetAllTransactionsFromFile();
    selectReport.GetEmailSelection();
    Console.ReadKey();
    if(reportChoice == 2) {
        // selectReport.Sort();
        System.Console.WriteLine(reportChoice);
    }
}
}