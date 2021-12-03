using System;
using System.IO;

namespace mis221_pa5
{
    public class Activity
    {
        //this is for the activity section
        private int activityID;
        private string activityName;
        private string activityCategory;
        private string priceRange;
        private int activityTime;
        private string needsTickets;
        private bool isDone;
        private bool isDeleted;
        private static int activitiesCount;

        public CompleteActivities completed;

        //constructor methods
        public Activity()
        {

        }

        public Activity(int activityID, string activityName, string activityCategory, string priceRange, int activityTime, string needsTickets, bool isDone, bool isDeleted)
        {
            this.activityID = activityID;
            this.activityName = activityName;
            this.activityCategory = activityCategory;
            this.priceRange = priceRange;
            this.activityTime = activityTime;
            this.needsTickets = needsTickets;
            this.isDone = isDone;
            this.isDeleted = isDeleted;
        }

        public void setActivityID(int activityID)
        {
            this.activityID = activityID;
        }
        public int getActivityID()
        {
            return activityID;
        }
        public void setName(string activityName)
        {
            this.activityName = activityName;
        }
        public string getName()
        {
            return activityName;
        }
        public void setCategory(string activityCategory)
        {
            this.activityCategory = activityCategory;
        }
        public string getCategory()
        {
            return activityCategory;
        }
        public void setPrice(string priceRange)
        {
            this.priceRange = priceRange;
        }
        public string getPrice()
        {
            return priceRange;
        }
        public void setTime(int activityTime)
        {
            this.activityTime = activityTime;
        }
        public int getTime()
        {
            return activityTime;
        }
        public void setTicketInfo(string needsTickets)
        {
            this.needsTickets = needsTickets;
        }
        public string getTicketInfo()
        {
            return needsTickets;
        }
        public void setIsDone(bool isDone)
        {
            this.isDone = isDone;
        }
        public bool getIsDone()
        {
            return isDone;
        }
        public void setIsDeleted(bool isDeleted)
        {
            this.isDeleted = isDeleted;
        }
        public bool getIsDeleted()
        {
            return isDeleted;
        }
        public static void setActivityCount(int activitiesCount)
        {
            Activity.activitiesCount = activitiesCount;
        }

        public static int getActivityCount()
        {
            return activitiesCount;
        }
        public static void IncActivityCount()
        {
            activitiesCount++;
        }
        public static void setActivitiesFile(Activity[] activities)
        {
            //print the new array of activities to vacation.txt
            StreamWriter outFile = new StreamWriter("list.txt");
            
            for(int i=0; i<Activity.getActivityCount(); i++)
            {
                outFile.WriteLine($"{activities[i].getActivityID()}#{activities[i].getName()}#{activities[i].getCategory()}#{activities[i].getPrice()}#{activities[i].getTime()}#{activities[i].getTicketInfo()}#{activities[i].getIsDone()}#{activities[i].getIsDeleted()}");
            }

            outFile.Close();
        }

        public static Activity[] getActivitiesFile()
        {
            //an array of activities to be used for the activities on file
            Activity[] activities = new Activity[1000];
            //open file
            StreamReader inFile = new StreamReader("list.txt");
            //process file
            string line = inFile.ReadLine();
            Activity.setActivityCount(0);
            while (line != null)   //while there is still text in the file
            {
                activities[Activity.getActivityCount()] = new Activity();
                string[] temp = line.Split('#');
                //take info from file and put into variables
                activities[Activity.getActivityCount()].setActivityID(int.Parse(temp[0]));
                activities[Activity.getActivityCount()].setName(temp[1]);
                activities[Activity.getActivityCount()].setCategory(temp[2]);
                activities[Activity.getActivityCount()].setPrice(temp[3]);
                activities[Activity.getActivityCount()].setTime(int.Parse(temp[4]));
                activities[Activity.getActivityCount()].setTicketInfo(temp[5]);
                activities[Activity.getActivityCount()].setIsDone(bool.Parse(temp[6]));
                activities[Activity.getActivityCount()].setIsDeleted(bool.Parse(temp[7]));

                line = inFile.ReadLine();
                Activity.IncActivityCount();
            }

            //close the file that was read from initially
            inFile.Close();

            return activities;
        }

        public override string ToString()
        {
            return $"\t-Name: {this.getName()}; Category: {this.getCategory()}; Range: ${this.getPrice()}; Time Needed: {this.getTime()} hours; Tickets Required: {this.getTicketInfo()}\n";
        }

    }
}