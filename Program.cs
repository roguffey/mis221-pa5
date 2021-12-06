using System;
using System.IO;

namespace mis221_pa5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the vacation program!");
            int choice = 0;

            do
            {
                Console.WriteLine("Please enter the number for your choice....");
                Console.WriteLine("1) Vacations");
                Console.WriteLine("2) Activities List");
                Console.WriteLine("3) Remaining Activities");
                Console.WriteLine("4) Complete Activities");
                Console.WriteLine("5) Trip Summary Report");
                Console.WriteLine("6) Exit");

                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        VacationSubmenu();
                        break;
                    case 2:
                        Console.Clear();
                        ActivitiesSubmenu();
                        break;
                    case 3:
                        Console.Clear();
                        RemainingActivities();
                        break;
                    case 4:
                        Console.Clear();
                        CompletedActivities();
                        break;
                    case 5:
                        Console.Clear();
                        SummaryReport();
                        break;
                    case 6:
                        break;
                    default:        //if anything other than the choices on the menu are selected
                        Console.Clear();
                        Console.WriteLine("Error! Please enter a valid choice \nPlease enter any key to continue....");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }
            while (choice != 6);
        }

        static void VacationSubmenu()
        {
            bool didChange = false;
            
            //an array of vacations to be used for the vacations on file
            Vacation[] vacations = Vacation.getVacationFile();

            //print out vacation list
            for(int i=0; i<Vacation.getVacationCount(); i++)
            {
                if(vacations[i].getDeleted() != true) Console.WriteLine(vacations[i].ToString());
            }

            Console.WriteLine("\nPlease choose what you would like to do with the list of vacations:");
            int choice = 0;
            while (choice != 4)
            {
                Console.WriteLine("1)   Add a vacation");
                Console.WriteLine("2)   Edit a vacation");
                Console.WriteLine("3)   Delete a vacation or vacation information");
                Console.WriteLine("4)   Exit");
                choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                {
                    Console.Clear();
                    didChange = true;

                    Console.WriteLine("Please enter the Vacations ID number:\n");
                    int id = int.Parse(Console.ReadLine());
                    Console.WriteLine("Please enter the Vacations destination:\n");
                    string dest = Console.ReadLine();
                    Console.WriteLine("Please enter the Vacations start date (enter as MM/DD/YYYY):\n");
                    string start = Console.ReadLine();
                    Console.WriteLine("Please enter the Vacations end date (enter as MM/DD/YYYY):\n");
                    string end = Console.ReadLine();
                    Console.WriteLine("Please enter the Vacations budget:\n");
                    double budget = double.Parse(Console.ReadLine());
                    budget = Math.Round(budget, 2);

                    vacations[Vacation.getVacationCount()] = new Vacation(id, dest, start, end, budget, false);
                    Vacation.IncVacationCount();
                }
                else if (choice == 2 || choice == 3)
                {
                    Console.Clear();
                    int target, search;
                    didChange = true;

                    do
                    {
                        Console.WriteLine("Please enter the ID number of the vacation you wish to edit, or enter -1 to return to the menu: ");
                        search = int.Parse(Console.ReadLine());
                        target = FindTarget(search, vacations);
                        if (target == -2) Console.WriteLine("ERROR - the vacation you are looking for doesn't exist");
                    }
                    while (target != -2);

                    if (target == -1) break;
                    else if (choice == 2)
                    {
                        EditVacation(vacations[target]);
                    }
                    else if (choice == 3)
                    {
                        Console.Clear();
                        Console.WriteLine("Do you wish to   \n1) Delete the entire vacation     \n2) Delete part of a vacation");
                        int temp = int.Parse(Console.ReadLine());

                        if (temp == 1)
                        {
                            vacations[target].setDeleted(true);
                        }
                        if (temp == 2)
                        {
                            EditVacation(vacations[target]);
                        }
                    }
                }
                else
                {
                    if(choice != 4) Console.WriteLine("ERROR - please choose a valid option");
                }
            }

            if(didChange == true) Vacation.setVacationFile(vacations);
        }

        static void ActivitiesSubmenu()
        {
            bool didChange = false;
            
            //an array of activities to be used for the activities on file
            Activity[] activities = Activity.getActivitiesFile();

            //print out activity list
            for(int i=0; i<Activity.getActivityCount(); i++)
            {
                if(activities[i].getIsDeleted() != true)Console.WriteLine(activities[i].ToString());
            }

            Console.WriteLine("Please choose what you would like to do with the list of activities:");
            int choice = 0;
            while (choice != 4)
            {
                Console.WriteLine("1)   Add an activity");
                Console.WriteLine("2)   Edit an activity");
                Console.WriteLine("3)   Delete an activity or activity information");
                Console.WriteLine("4)   Exit");
                choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                {
                    Console.Clear();
                    didChange = true;

                    Console.WriteLine("Please enter the Activity ID number (same as Vacation ID number):\n");
                    int id = int.Parse(Console.ReadLine());
                    Console.WriteLine("Please enter the Activity name:\n");
                    string name = Console.ReadLine();
                    Console.WriteLine("Please enter the Activity category:\n");
                    string category = Console.ReadLine();
                    Console.WriteLine("Please enter the Activity price range (enter as #-#, do not include dollar signs):\n");
                    string range = Console.ReadLine();
                    Console.WriteLine("Please enter the time needed for Activity (to the closest whole hour, EX: 2):\n");
                    int time = int.Parse(Console.ReadLine());
                    Console.WriteLine("Please enter whether or not the Activity requires tickets (enter either 'Yes' or 'No'):\n");
                    string tickets = Console.ReadLine();

                    activities[Activity.getActivityCount()] = new Activity(id, name, category, range, time, tickets, false, false);
                    Activity.IncActivityCount();
                }
                else if (choice == 2 || choice == 3)
                {
                    Console.Clear();
                    string input;
                    int target;
                    didChange = true;

                    do
                    {
                        Console.WriteLine("Please enter the name of the activity you wish to edit, or enter -1 to return to the menu: ");
                        input = Console.ReadLine();
                        target = FindName(input, activities);
                        if (target == -2) Console.WriteLine("ERROR - the activity you are looking for doesn't exist");
                    }
                    while (target != -1);

                    if (target == -1) break;
                    
                    else if (choice == 2)
                    {
                        EditActivity(activities[target]);
                    }
                    
                    else if (choice == 3)
                    {
                        Console.Clear();
                        Console.WriteLine("Do you wish to   \n1) Delete the entire activity     \n2) Delete part of an activity");
                        int temp = int.Parse(Console.ReadLine());

                        if (temp == 1)
                        {
                            activities[target].setIsDeleted(true);
                        }
                        if (temp == 2)
                        {
                            EditActivity(activities[target]);
                        }
                    }
                }
                else if(choice == 4) break;
                else Console.WriteLine("ERROR - please choose a valid option");  

            if(didChange == true) Activity.setActivitiesFile(activities);
            }
        }

        static void RemainingActivities()
        {
            RemainingActivities remActivities = new RemainingActivities();

            Console.WriteLine("Please choose how you wish to view remaining uncompleted activities:");
            int choice = 0;
            while (choice != 6)
            {
                Console.WriteLine("1)   All");
                Console.WriteLine("2)   Category");
                Console.WriteLine("3)   Time Needed");
                Console.WriteLine("4)   Price Range (Lowest to Highest)");
                Console.WriteLine("5)   Tickets Needed");
                Console.WriteLine("6)   Exit");
                choice = int.Parse(Console.ReadLine());

                //use the case break methods for the different sorting methods
                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        remActivities.viewAll();
                        break;
                    case 2:
                        Console.Clear();
                        remActivities.viewCategory();
                        break;
                    case 3:
                        Console.Clear();
                        remActivities.viewTimeNeeded();
                        break;
                    case 4:
                        Console.Clear();
                        remActivities.viewPrice();
                        break;
                    case 5:
                        Console.Clear();
                        remActivities.viewNeedTickets();
                        break;
                    case 6:
                        break;
                    default:        //if anything other than the choices on the menu are selected
                        Console.Clear();
                        Console.WriteLine("Error! Please enter a valid choice \nPlease enter any key to continue....");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }

            }
        }

        static void CompletedActivities()
        {
            CompleteActivities comActivities = new CompleteActivities();



            Console.WriteLine("Please enter the activity ID number you wish to mark as completed:");

            comActivities.selectActivityID();

            Activity[] activities = Activity.getActivitiesFile();
            CompleteActivities[] completed = CompleteActivities.getCompletedFile();

            Console.WriteLine("Please select which field of the activity you wish to fill out. Please choose one, you will return to this menu after the field is filled out:");
            int choice = 0;
            while (choice != 6)
            {
                Console.WriteLine("1)	Date that activity was completed");
                Console.WriteLine("2)	Money spent");
                Console.WriteLine("3)	Rating");
                Console.WriteLine("4)	Review");
                Console.WriteLine("5)	Recommend to others");
                Console.WriteLine("6)   Exit");
                choice = int.Parse(Console.ReadLine());
            }
             switch (choice)
                 {
                     case 1:
                        Console.Clear();
                         comActivities.getDate();
                         break;
                     case 2:
                         Console.Clear();
                        comActivities.getSpendings();
                         break;
                     case 3:
                         Console.Clear();
                         comActivities.getRating();
                         break;
                     case 4:
                         Console.Clear();
                         comActivities.getReview();
                         break;
                     case 5:
                        Console.Clear();
                        comActivities.getRecommend();
                        break;
                    case 6:
                        return;
                        
                    default:        //if anything other than the choices on the menu are selected
                        Console.Clear();
                        Console.WriteLine("Error! Please enter a valid choice \nPlease enter any key to continue....");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
        }

        static void SummaryReport()
        {
            SummaryReport report = new SummaryReport();

             Activity[] activities = Activity.getActivitiesFile();
             CompleteActivities[] completed = CompleteActivities.getCompletedFile();

            Console.WriteLine("Please select which reporting style you would like to preview:");
            int choice = 0;
            while (choice != 6)
            {
                Console.WriteLine("1)	Trip Summary by Day");
                Console.WriteLine("2)	Rating");
                Console.WriteLine("3)	Incomplete");
                Console.WriteLine("4)	Category");
                Console.WriteLine("5)	Money Spent");
                Console.WriteLine("6)   Exit");
                choice = int.Parse(Console.ReadLine());

                 switch (choice)
                 {
                     case 1:
                        Console.Clear();
                         report.byDayCompleted(completed);
                         break;
                     case 2:
                         Console.Clear();
                        report.byRatings(completed);
                         break;
                     case 3:
                         Console.Clear();
                         report.byIncomplete(activities);
                         break;
                     case 4:
                         Console.Clear();
                         report.byCategoryAndPrice(activities, completed);
                         break;
                     case 5:
                        Console.Clear();
                      report.byMoneySpent(activities, completed);
                        break;
                    case 6:
                        return;
                        
                    default:        //if anything other than the choices on the menu are selected
                        Console.Clear();
                        Console.WriteLine("Error! Please enter a valid choice \nPlease enter any key to continue....");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }


                Console.WriteLine("Would you like to either: \n1)       Save this report \n2)       Return to the menu");
                choice = 0;
                if (choice == 1)
                {
                    //save report
                    break;
                }
                else Console.Clear();
            }
        }

        static int FindTarget(int target, Vacation[] vacations)
        {
            int temp = -2;

            for (int i = 0; i < Vacation.getVacationCount(); i++)
            {
                if (vacations[i].getVacationID() == target) temp = i;
            }

            return temp;
        }

        static int FindName(string target, Activity[] activities)
        {
            int temp = -2;

            for (int i = 0; i < Activity.getActivityCount(); i++)
            {
                if (activities[i].getName() == target) temp = i;
            }

            return temp;
        }

        static void EditVacation(Vacation vacation)
        {
            Console.Clear();
            Console.WriteLine("Please enter either Y (for Yes) or N (for No) if you would like to edit the information for each section of the vacation");
            char edit;

            Console.WriteLine("Edit the vacation ID?");
            edit = char.Parse(Console.ReadLine());

            if (edit == 'y' || edit == 'Y')
            {
                Console.WriteLine("Please enter the vacations ID number (must be higher than 0):\n");
                int id = int.Parse(Console.ReadLine());
                vacation.setVacationID(id);
            }

            Console.WriteLine("Edit the destination?");
            edit = char.Parse(Console.ReadLine());

            if (edit == 'y' || edit == 'Y')
            {
                Console.WriteLine("Please enter the vacations destination:\n");
                string dest = Console.ReadLine();
                vacation.setDestination(dest);
            }

            Console.WriteLine("Edit the start date?");
            edit = char.Parse(Console.ReadLine());

            if (edit == 'y' || edit == 'Y')
            {
                Console.WriteLine("Please enter the vacations start date (enter as MM/DD/YYYY):\n");
                string start = Console.ReadLine();
                vacation.setStartDate(start);
            }

            Console.WriteLine("Edit the end date?");
            edit = char.Parse(Console.ReadLine());

            if (edit == 'y' || edit == 'Y')
            {
                Console.WriteLine("Please enter the vacations end date (enter as MM/DD/YYYY):\n");
                string end = Console.ReadLine();
                vacation.setEndDate(end);
            }

            Console.WriteLine("Edit the budget?");
            edit = char.Parse(Console.ReadLine());

            if (edit == 'y' || edit == 'Y')
            {
                Console.WriteLine("Please enter the vacations budget:\n");
                double budget = double.Parse(Console.ReadLine());
                budget = Math.Round(budget, 2);
                vacation.setBudget(budget);
            }
        }

        static void EditActivity(Activity activity)
        {
            Console.Clear();
            Console.WriteLine("Please enter either Y (for Yes) or N (for No) if you would like to edit the information for each section of the vacation");
            char edit;

            Console.WriteLine("Edit the activity ID?");
            edit = char.Parse(Console.ReadLine());

            if (edit == 'y' || edit == 'Y')
            {
                Console.WriteLine("Please enter the activity ID number (must be higher than 0):\n");
                int id = int.Parse(Console.ReadLine());
                activity.setActivityID(id);
            }

            Console.WriteLine("Edit the name?");
            edit = char.Parse(Console.ReadLine());

            if (edit == 'y' || edit == 'Y')
            {
                Console.WriteLine("Please enter the activity name:\n");
                string name = Console.ReadLine();
                activity.setName(name);
            }

            Console.WriteLine("Edit the activity category?");
            edit = char.Parse(Console.ReadLine());

            if (edit == 'y' || edit == 'Y')
            {
                Console.WriteLine("Please enter the activity category:\n");
                string cat = Console.ReadLine();
                activity.setCategory(cat);
            }

            Console.WriteLine("Edit the price range?");
            edit = char.Parse(Console.ReadLine());

            if (edit == 'y' || edit == 'Y')
            {
                Console.WriteLine("Please enter the price range:\n");
                string price = Console.ReadLine();
                activity.setPrice(price);
            }

            Console.WriteLine("Edit the time required?");
            edit = char.Parse(Console.ReadLine());

            if (edit == 'y' || edit == 'Y')
            {
                Console.WriteLine("Please enter the time required (to the nearest whole hour, Ex: 3):\n");
                int time = int.Parse(Console.ReadLine());
                activity.setTime(time);
            }

            Console.WriteLine("Edit the ticket requirement?");
            edit = char.Parse(Console.ReadLine());

            if (edit == 'y' || edit == 'Y')
            {
                Console.WriteLine("Please enter 'Yes' or 'No' if the activity requires tickets:\n");
                string ticket = Console.ReadLine();
                activity.setTicketInfo(ticket);
            }
        }
    }
        }
    

