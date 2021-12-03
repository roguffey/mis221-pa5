using System;
using System.IO;

namespace mis221_pa5
{
    public class CompleteActivities
    {
        //this is for marking activities as completed
        private static int completedActivitiesCount;

        private string name;

        private DateTime date;

        private double spendings;

        private int rating;

        private string review;

        private string recomendation;

        public CompleteActivities()
        {

        }

        public void setName(string name)
        {
            this.name = name;
        }

        public void setDate(DateTime date)
        {
            this.date = date;
        }

        public void setSpendings(double spendings)
        {
            this.spendings = spendings;
        }

        public void setRating(int rating)
        {
            this.rating = rating;
        }

        public void setReview(string review)
        {
            this.review = review;
        }

        public void setRecommend(string recomendation)
        {
            this.recomendation = recomendation;
        }

        public string getName()
        {
            return name;
        }

        public DateTime getDate()
        {
            return date;
        }

        public double getSpendings()
        {
            return spendings;
        }

        public int getRating()
        {
            return rating;
        }

        public string getReview()
        {
            return review;
        }

        public string getRecommend()
        {
            return recomendation;
        }

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

        public static void setCompletedCount(int count)
        {
            CompleteActivities.completedActivitiesCount = completedActivitiesCount;
        }

        public static int getCompletedCount()
        {
            return completedActivitiesCount;
        }

        public static void setCompletedFile(CompleteActivities[] complete)
        {
            StreamWriter outFile = new StreamWriter("completed.txt");
             for (int i = 0; i < CompleteActivities.completedActivitiesCount; i++)
             {
                 outFile.WriteLine($"{complete[i].getName()}#{complete[i].getDate()}#{complete[i].getSpendings()}#{complete[i].getRating()}#{complete[i].getReview()}#{complete[i].getRecommend()}");
             }
            outFile.Close();
        }

        public static CompleteActivities[] getCompletedFile()
        {
            CompleteActivities[] completed = new CompleteActivities[100];
            StreamReader inFile = new StreamReader("completed.txt");
            string line = inFile.ReadLine();
            CompleteActivities.setCompletedCount(0);

            while (line != null)
            {
                completed[CompleteActivities.getCompletedCount()] = new CompleteActivities();
                string[] temp = line.Split('#');

                completed[CompleteActivities.getCompletedCount()].setName(temp[0]);
                completed[CompleteActivities.getCompletedCount()].setDate(DateTime.Parse(temp[1]));
                completed[CompleteActivities.getCompletedCount()].setSpendings(double.Parse(temp[2]));
                completed[CompleteActivities.getCompletedCount()].setRating(int.Parse(temp[3]));
                completed[CompleteActivities.getCompletedCount()].setReview(temp[4]);
                completed[CompleteActivities.getCompletedCount()].setRecommend(temp[5]);

                line = inFile.ReadLine();
                CompleteActivities.incCompletedCount();
            }
            inFile.Close();

            return completed;
        }

        public static void incCompletedCount()
        {
            completedActivitiesCount+=1;
        }

        public void completeFile()
        {
            //create or write to completed activities file
        }
    }
}