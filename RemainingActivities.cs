using System;
using System.IO;

namespace mis221_pa5
{
    public class RemainingActivities
    {
        //this is for the remaining activities viewing section
        
        public void viewAll()
        {
            StreamReader inFile = new StreamReader("list.txt");
            string line = inFile.ReadLine();
            while(line != null)
            {
                string[] temp = line.Split('#');
                if(temp[6]=="false")
                {
                    Console.WriteLine(line);
                }
                line = inFile.ReadLine();
                
            }
            inFile.Close();
        }

        public void viewCategory()
        {
            StreamReader inFile = new StreamReader("list.txt");
            string line = inFile.ReadLine();
            while(line != null)
            {
                string[] temp = line.Split('#');
                if(temp[6]=="false")
                {
                    
                    Console.WriteLine(line);
                }
                line = inFile.ReadLine();
                
            }
            inFile.Close();
        }

        public void viewTimeNeeded()
        {
            StreamReader inFile = new StreamReader("list.txt");
            string line = inFile.ReadLine();
            while(line != null)
            {
                string[] temp = line.Split('#');
                int.Parse(line);
                
                if(temp[6]=="false")
                {
                    Console.WriteLine(line);
                }
                line = inFile.ReadLine();
                
            }
            inFile.Close();
        }

        public void viewPrice()
        {
            StreamReader inFile = new StreamReader("list.txt");
            string line = inFile.ReadLine();
            while(line != null)
            {
                string[] temp = line.Split('#');
                
                if(temp[6]=="false")
                {
                    Console.WriteLine(line);
                }
                line = inFile.ReadLine();
                
            }
            inFile.Close();
        }

        public void viewNeedTickets()
        {
            StreamReader inFile = new StreamReader("list.txt");
            string line = inFile.ReadLine();
            while(line != null)
            {
                string[] temp = line.Split('#');
                
                if(temp[5]=="Yes" && temp[6] == "false")
                {
                    Console.WriteLine(line);
                }
                line = inFile.ReadLine();
                
            }
            inFile.Close();
        }

        
    }
}