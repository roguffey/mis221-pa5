using System;
using System.IO;

namespace mis221_pa5
{
    public class SummaryReport
    {
        //this is for printing various reports for the differt reports for the vacation
        public void byDayCompleted(CompleteActivities[] completed)
        {
            CompleteActivities[] test = completed;
            for (int i = 0; i < CompleteActivities.getCompletedCount() - 1; i++)
            {
                int min_Index = i;
                for (int j = i + 1; j < CompleteActivities.getCompletedCount(); j++)
                {
                    if (test[j].getDate() < test[min_Index].getDate())
                    {
                        min_Index = j;
                    }
                }
                if (min_Index != i)
                {
                    CompleteActivities temp = test[i];
                    test[i] = test[min_Index];
                    test[min_Index] = temp;
                }
            }

            for (int i = 0; i < CompleteActivities.getCompletedCount(); i++)
            {
                Console.WriteLine(test[i].ToString());
            }

            Console.WriteLine("\nWould you like to either: \n1)       Save this report \n2)       Return to the menu");
            int choice = int.Parse(Console.ReadLine());
            if (choice == 1)
            {
                Console.WriteLine("Enter what name you want the file to be saved to (CANNOT BE: vacation.txt, list.txt, or completed.txt): ");
                string fileName = Console.ReadLine();
                StreamWriter outFile = new StreamWriter($"{fileName}");

                for (int i = 0; i < CompleteActivities.getCompletedCount(); i++)
                {
                    outFile.WriteLine(test[i].ToString());
                }

                outFile.Close();
            }
        }

        public void byRatings(CompleteActivities[] completed)
        {
            CompleteActivities[] test = completed;
            for (int i = 0; i < CompleteActivities.getCompletedCount() - 1; i++)
            {
                int min_Index = i;
                for (int j = i + 1; j < CompleteActivities.getCompletedCount(); j++)
                {
                    if (test[j].getRating() > test[min_Index].getRating())
                    {
                        min_Index = j;
                    }
                }
                if (min_Index != i)
                {
                    CompleteActivities temp = test[i];
                    test[i] = test[min_Index];
                    test[min_Index] = temp;
                }
            }

            for (int i = 0; i < CompleteActivities.getCompletedCount(); i++)
            {
                if (test[i].getRating() > 3) Console.WriteLine(test[i].ToString());
            }

            Console.WriteLine("\nWould you like to either: \n1)       Save this report \n2)       Return to the menu");
            int choice = int.Parse(Console.ReadLine());
            if (choice == 1)
            {
                Console.WriteLine("Enter what name you want the file to be saved to (CANNOT BE: vacation.txt, list.txt, or completed.txt): ");
                string fileName = Console.ReadLine();
                StreamWriter outFile = new StreamWriter($"{fileName}");

                for (int i = 0; i < CompleteActivities.getCompletedCount(); i++)
                {
                    if (test[i].getRating() > 3) outFile.WriteLine(test[i].ToString());
                }

                outFile.Close();
            }
        }

        public void byIncomplete(Activity[] activities)
        {
            Activity[] test = activities;
            for (int i = 0; i < Activity.getActivityCount(); i++)
            {
                if (test[i].getIsDeleted() == false && test[i].getIsDone() == false) Console.WriteLine(test[i].ToString()); ;
            }

            Console.WriteLine("\nWould you like to either: \n1)       Save this report \n2)       Return to the menu");
            int choice = int.Parse(Console.ReadLine());
            if (choice == 1)
            {
                Console.WriteLine("Enter what name you want the file to be saved to (CANNOT BE: vacation.txt, list.txt, or completed.txt): ");
                string fileName = Console.ReadLine();
                StreamWriter outFile = new StreamWriter($"{fileName}");

                for (int i = 0; i < CompleteActivities.getCompletedCount(); i++)
                {
                    if (test[i].getIsDeleted() == false && test[i].getIsDone() == false) outFile.WriteLine(test[i].ToString());
                }

                outFile.Close();
            }
        }

        public void byCategoryAndPrice(Activity[] activities, CompleteActivities[] completed)
        {
            Activity[] testA = activities;
            CompleteActivities[] testC = completed;

            Console.WriteLine("Please enter the category you wish to view: ");
            string searchVal = Console.ReadLine();
            searchVal = searchVal.ToLower();


            for (int i = 0; i < Activity.getActivityCount() - 1; i++)
            {
                int min_Index = i;
                for (int j = i + 1; j < Activity.getActivityCount(); j++)
                {
                    if (testA[j].getCategory().CompareTo(testA[min_Index].getCategory()) < 0)
                    {
                        min_Index = j;
                    }
                }
                if (min_Index != i)
                {
                    Activity temp = testA[i];
                    testA[i] = testA[min_Index];
                    testA[min_Index] = temp;
                }
            }

            for (int i = 0; i < CompleteActivities.getCompletedCount() - 1; i++)
            {
                int min_Index = i;
                for (int j = i + 1; j < CompleteActivities.getCompletedCount(); j++)
                {
                    if (testC[j].getSpendings() < testC[min_Index].getSpendings())
                    {
                        min_Index = j;
                    }
                }
                if (min_Index != i)
                {
                    CompleteActivities temp = testC[i];
                    testC[i] = testC[min_Index];
                    testC[min_Index] = temp;
                }
            }

            for (int i = 0; i < Activity.getActivityCount(); i++)
            {
                for (int j = 0; j < CompleteActivities.getCompletedCount(); j++)
                {
                    if (testA[i].getCategory().Equals(searchVal) && testC[j].getName().Equals(testA[i].getName())) Console.WriteLine(testC[j].ToString());
                }
            }

            Console.WriteLine("\nWould you like to either: \n1)       Save this report \n2)       Return to the menu");
            int choice = int.Parse(Console.ReadLine());
            if (choice == 1)
            {
                Console.WriteLine("Enter what name you want the file to be saved to (CANNOT BE: vacation.txt, list.txt, or completed.txt): ");
                string fileName = Console.ReadLine();
                StreamWriter outFile = new StreamWriter($"{fileName}");

                for (int i = 0; i < Activity.getActivityCount(); i++)
                {
                    for (int j = 0; j < CompleteActivities.getCompletedCount(); j++)
                    {
                        if (testA[i].getCategory().Equals(searchVal) && testC[j].getName().Equals(testA[i].getName())) outFile.WriteLine(testC[j].ToString());
                    }
                }

                outFile.Close();
            }
        }

        public void byMoneySpent(Activity[] activities, CompleteActivities[] completed)
        {
            Activity[] test1 = activities;
            CompleteActivities[] test2 = completed;
            for (int i = 0; i < Activity.getActivityCount() - 1; i++)
            {
                int min_Index = i;
                for (int j = i + 1; j < Activity.getActivityCount(); j++)
                {
                    if (test1[j].getCategory().CompareTo(test1[min_Index].getCategory()) < 0)
                    {
                        min_Index = j;
                    }
                }
                if (min_Index != i)
                {
                    Activity temp = test1[i];
                    test1[i] = test1[min_Index];
                    test1[min_Index] = temp;
                }
            }

            string category = test1[0].getCategory();
            category = category.ToLower();
            double sum = 0;
            int count = 1;

            Console.Write($"Category #{count} - {category}: $");

            for (int i = 0; i < Activity.getActivityCount(); i++)
            {
                if (!test1[i].getCategory().Equals(category))
                {
                    sum = Math.Round(sum, 2);
                    Console.Write($"{sum}\n");
                    category = test1[i].getCategory();
                    count++;
                    sum = 0;
                    Console.Write($"Category #{count} - {category}: $");
                }
                for (int j = 0; j < CompleteActivities.getCompletedCount(); j++)
                {
                    if (test1[i].getCategory().Equals(category) && test1[i].getName().Equals(test2[j].getName()) && test1[i].getIsDeleted() == false) sum += test2[j].getSpendings();
                }
            }
            //fencepost error correction
            sum = Math.Round(sum, 2);
            Console.Write($"{sum}\n");

            Console.WriteLine("\nWould you like to either: \n1)       Save this report \n2)       Return to the menu");
            int choice = int.Parse(Console.ReadLine());
            if (choice == 1)
            {
                Console.WriteLine("Enter what name you want the file to be saved to (CANNOT BE: vacation.txt, list.txt, or completed.txt): ");
                string fileName = Console.ReadLine();
                StreamWriter outFile = new StreamWriter($"{fileName}");

                category = test1[0].getCategory();
                category = category.ToLower();
                sum = 0;
                count = 1;
                outFile.Write($"Category #{count} - {category}: $");
                for (int i = 0; i < Activity.getActivityCount(); i++)
                {
                    if (!test1[i].getCategory().Equals(category))
                    {
                        sum = Math.Round(sum, 2);
                        outFile.Write($"{sum}\n");
                        category = test1[i].getCategory();
                        count++;
                        sum = 0;
                        outFile.Write($"Category #{count} - {category}: $");
                    }
                    for (int j = 0; j < CompleteActivities.getCompletedCount(); j++)
                    {
                        if (test1[i].getCategory().Equals(category) && test1[i].getName().Equals(test2[j].getName()) && test1[i].getIsDeleted() == false) sum += test2[j].getSpendings();
                    }
                }
                //fencepost error correction
                sum = Math.Round(sum, 2);
                outFile.Write($"{sum}\n");

                outFile.Close();
            }
        }
    }
}