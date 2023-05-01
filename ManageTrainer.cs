namespace mis_221_pa_5_dbwelchel
{
    public class ManageTrainer
    {
        private Trainer[] trainers;
        public ManageTrainer(Trainer[] trainers) {
            this.trainers = trainers;
        }
        //adds a trainer
        public void AddTrainers() {
            Trainer.SetCount(0);
            System.Console.WriteLine("Please enter ID. Enter stop to STOP");
            string userInput = Console.ReadLine().ToUpper();
            while(userInput != "STOP") {
                if(int.TryParse(userInput, out int trainerTest)) {
                // if(!userInput)System.Console.WriteLine("Invalid input. Please enter a valid ID.");
        
                trainers[Trainer.GetCount()] = new Trainer(trainerTest, "", "", "");
                trainers[Trainer.GetCount()].SetID(trainerTest);
                
                System.Console.WriteLine("Please enter the name");
                trainers[Trainer.GetCount()].SetName(Console.ReadLine().ToUpper());

                System.Console.WriteLine("Enter address");
                trainers[Trainer.GetCount()].SetAddress(Console.ReadLine().ToUpper());
                 

                System.Console.WriteLine("Enter email");
                trainers[Trainer.GetCount()].SetEmail(Console.ReadLine().ToUpper());
               
                Trainer.IncCount();
                System.Console.WriteLine("Please enter ID or enter stop to STOP");
            
                
            
            }
            else {
                System.Console.WriteLine("Invalid input. Please enter a valid ID.");
                userInput = Console.ReadLine().ToUpper();
            }
            userInput = Console.ReadLine().ToUpper();
                if(userInput == "STOP") {
                    break;
                }
            }
            Save();
        }
            
            // edit features of trainer
            public void EditTrainers() {
                // Reports report = new Reports(trainers);
                // report.GetAllTrainersFromFile();
                
                System.Console.WriteLine("Which trainer would you like to edit?");
                int searchVal = int.Parse(Console.ReadLine());
                
                int foundIndex = Find(searchVal, trainers);
                    if(foundIndex != -1) {
                        System.Console.WriteLine("Please enter ID");
                        trainers[foundIndex].SetID(int.Parse(Console.ReadLine()));
                        
                        System.Console.WriteLine("PLease enter Name");
                        trainers[foundIndex].SetName(Console.ReadLine());
                        
                        System.Console.WriteLine("Please enter address");
                        trainers[foundIndex].SetAddress(Console.ReadLine());
                        
                        System.Console.WriteLine("Enter email");
                        trainers[foundIndex].SetEmail(Console.ReadLine());
                    
                        Update();

                    }
                    else {
                        System.Console.WriteLine("Trainer was not found");
                    }
                       
               }   
           //delete a trainer
              public void DeleteTrainer()
        {
            System.Console.WriteLine("Please enter ID of the trainer you want to delete");
            int searchVal = int.Parse(Console.ReadLine());

            int foundIndex = Find(searchVal, trainers);
            if (foundIndex != -1)
            {
                trainers[foundIndex] = null;
                Update();
                System.Console.WriteLine("Trainer has been deleted");
            }
            else
            {
                System.Console.WriteLine("Trainer was not found");
            }
        }
     
            

         // save to streamwriter
  public void Save() {
            Trainer.GetCount();
            StreamWriter outFile = new StreamWriter("TrainerInfo.txt", true);
            for(int i = 0; i < trainers.Length; i++) {
                while(trainers[i] != null) {
                outFile.WriteLine(trainers[i].GetID()+ "#" + trainers[i].GetName() + "#" + trainers[i].GetAddress() + "#"+ trainers[i].GetEmail());
                }
            }
            outFile.Close();
            }  
//update streamwriter
 public void Update() {
            Trainer.GetCount();
            StreamWriter outFile = new StreamWriter("TrainerInfo.txt", false);
            for(int i = 0; i < trainers.Length; i++) {
                if(trainers[i] != null) {
                outFile.WriteLine(trainers[i].GetID()+ "#" + trainers[i].GetName() + "#" + trainers[i].GetAddress() + "#"+ trainers[i].GetEmail());
                }
            }
            outFile.Close();
            }  

//Pulls from txt.file
             public void GetAllTrainersFromFile() {
                StreamReader inFile = new StreamReader("TrainerInfo.txt");
                int i = 0;
                //process
                string line = inFile.ReadLine();
                while(line != null && i < trainers.Length) {
                string[] temp = line.Split('#');
                trainers[i] = new Trainer(int.Parse(temp[0]),temp[1],temp[2],temp[3]);
                Trainer.IncCount();
                line = inFile.ReadLine();
                i++;
                }
            
            
            inFile.Close();
        }
 //Looks for ID 
static int Find(int searchVal, Trainer[] trainers) {
    
    for(int i = 0; i < trainers.Length; i++) {
        if(trainers[i] != null && trainers[i].GetID() == searchVal) {
            return i;
        }
        
    }
    return -1;
}
  //Prints all trainers
 public void PrintAllTrainers() {
            Console.ReadKey();
            Console.WriteLine("Available Trainers");
            for(int i = 0; i < trainers.Length; i++) {
                
                if(trainers[i] != null) {
                    Console.WriteLine(trainers[i].ToString());
                
         
            }
        }  
        }
    }
}