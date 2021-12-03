using System;
using System.IO;

namespace mis221_pa5
{
    class Vacation
    {
        //this is for the vacation section
        private int vacationID;
        private string vacationDestination;
        private string vacationStart;
        private string vacationEnd;
        private double vacationBudget;
        private bool vacationDeleted;
        static private int vacationCount;

        //constructor methods
        public Vacation()
        {

        }

        public Vacation(int vacationID, string vacationDestination, string vacationStart, string vacationEnd, double vacationBudget, bool vacationDeleted)
        {
            this.vacationID = vacationID;
            this.vacationDestination = vacationDestination;
            this.vacationStart = vacationStart;
            this.vacationEnd = vacationEnd;
            this.vacationBudget = vacationBudget;
            this.vacationDeleted = vacationDeleted;
        }

        public void setVacationID(int vacationID)
        {
            this.vacationID = vacationID;
        }
        public int getVacationID()
        {
            return vacationID;
        }
        public void setDestination(string vacationDestination)
        {
            this.vacationDestination = vacationDestination;
        }
        public string getDestination()
        {
            return vacationDestination;
        }
        public void setStartDate(string vacationStart)
        {
            this.vacationStart = vacationStart;
        }
        public string getStartDate()
        {
            return vacationStart;
        }
        public void setEndDate(string vacationEnd)
        {
            this.vacationEnd = vacationEnd;
        }
        public string getEndDate()
        {
            return vacationEnd;
        }
        public void setBudget(double vacationBudget)
        {
            this.vacationBudget = vacationBudget;
        }
        public double getBudget()
        {
            return vacationBudget;
        }
        public void setDeleted(bool vacationDeleted)
        {
            this.vacationDeleted = vacationDeleted;
        }
        public bool getDeleted()
        {
            return vacationDeleted;
        }
        public static void setVacationCount(int vacationCount)
        {
            Vacation.vacationCount = vacationCount;
        }

        public static int getVacationCount()
        {
            return vacationCount;
        }
        public static void IncVacationCount()
        {
            vacationCount++;
        }
        public static void setVacationFile(Vacation[] vacations)
        {
            //print the new array of vacations to vacation.txt
            StreamWriter outFile = new StreamWriter("vacation.txt");
            
            for(int i=0; i<Vacation.getVacationCount(); i++)
            {
                outFile.WriteLine($"{vacations[i].getVacationID()}#{vacations[i].getDestination()}#{vacations[i].getStartDate()}#{vacations[i].getEndDate()}#{vacations[i].getBudget()}#{vacations[i].getDeleted()}");
            }

            outFile.Close();
        }

        public static Vacation[] getVacationFile()
        {
            //an array of vacations to be used for the vacations on file
            Vacation[] vacations = new Vacation[200];
            //open file
            StreamReader inFile = new StreamReader("vacation.txt");
            //process file
            string line = inFile.ReadLine();
            Vacation.setVacationCount(0);
            
            while (line != null)   //while there is still text in the file
            {
                vacations[Vacation.getVacationCount()] = new Vacation();
                string[] temp = line.Split('#');
                //take info from file and put into variables
                vacations[Vacation.getVacationCount()].setVacationID(int.Parse(temp[0]));
                vacations[Vacation.getVacationCount()].setDestination(temp[1]);
                vacations[Vacation.getVacationCount()].setStartDate(temp[2]);
                vacations[Vacation.getVacationCount()].setEndDate(temp[3]);
                vacations[Vacation.getVacationCount()].setBudget(double.Parse(temp[4]));
                vacations[Vacation.getVacationCount()].setDeleted(bool.Parse(temp[5]));

                line = inFile.ReadLine();
                Vacation.IncVacationCount();
            }

            //close the file that was read from initially
            inFile.Close();

            return vacations;
        }

        public override string ToString()
        {
            return $"Vacation Destination #{this.getVacationID()}: {this.getDestination()} from {this.getStartDate()} - {this.getEndDate()}; Budget: ${this.getBudget()}";
        }
    }
}