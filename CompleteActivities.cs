using System;
using System.IO;

namespace mis221_pa5
{
    public class CompleteActivities
    {
        //this is for marking activities as completed
        static private int completedActivitiesCount;

        public void selectActivityID()
        {
            //display all the various activities with their id numbers
            //read in activity id number from user

            StreamReader inFile = new StreamReader("list.txt");
            string line = inFile.ReadLine();
            while(line != null)
            {
                string[] temp = line.Split('#');
                
                Console.WriteLine(line);
                
                line = inFile.ReadLine();
                
            }
            inFile.Close();

            fillActivityInfo(Console.ReadLine());

            
        }

        public void fillActivityInfo(string activityID)
        {
            //fill in the various variables of the activity selected
            string actID = activityID;
            StreamReader inFile = new StreamReader("list.txt");
            StreamWriter outFile = new StreamWriter("completed.txt");
            string line = inFile.ReadLine();
            string[] temp = line.Split('#');

            if(actID == temp[0])
            {
                temp[6] = "true";
                
                outFile.WriteLine(line);
            }

            inFile.Close();
            outFile.Close();
        }

        public static void setCompletedCount(CompleteActivities[] complete)
        {
            StreamWriter outFile = new StreamWriter("completed.txt");
            // for (int i = 0; i < CompleteActivities.completedActivitiesCount(); i++)
            // {
            //     outFile.WriteLine($"{comple")
            // }
            outFile.Close();
        }

        // public static CompleteActivities[] getCompletedFile()
        // {
        //     CompleteActivities[] completed = new CompleteActivities[100];
        //     StreamReader inFile = new StreamReader("completed.txt");
        //     string line = inFile.ReadLine();
        //     CompleteActivities.setCompletedCount(0);

        //     while (line != null)
        //     {
        //          string[] temp = line.Split('#');
        //     }
        //     inFile.Close();

        //     return completed;
        // }

        public void incCompletedCount()
        {
            completedActivitiesCount++;
        }

        public void completeFile()
        {
            //create or write to completed activities file
        }
    }
}