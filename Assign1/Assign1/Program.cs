/***************************************************************
* Name: Zubaidah Alqaisi                                       *
* ZID: Z1786977                                                * 
* Course: CSCI 473 Section 2 Spring 2018                       *
* Assignment: assign1                                          *
* Due Date: Friday, Feb. 2.                                    *
* Program goal: Practice using some features of C# using Visual* 
*               Studio IDE.                                    *
***************************************************************/

using System;                           
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assign1
{
    static class Program
    {
        //declaring an array of string type value
        public static Person[] otherPerson = new Person[20];
        public static int InUse = 0;

/**************************************************************
 * Funcion: main()                                            *
 * Purpose: The main function will call a method to display   *
 *          the main menu for the user, reads user choice,    *
 *          and perform functions based on the user's choice. *
 * Arguments: none                                            *
 * Return: none (void)                                        *
 * ***********************************************************/

        static void Main()
        {
            string userChoice;
            ReadFile();

            // a loop to display the menu for the user every time the user select a choice except h or H
            do
            {

                userChoice = DisplayMenu();

                switch (userChoice)                 // switch statement to select among user choices 
                {
                    case "a":
                        DisplayList();
                        break;

                    case "A":
                        DisplayList();
                        break;

                    case "b":
                        AddEntry();
                        break;

                    case "B":
                        AddEntry();
                        break;

                    case "c":
                        SearchName();
                        break;

                    case "C":
                        SearchName();
                        break;

                    case "d":
                        SearchOfficeNum();
                        break;

                    case "D":
                        SearchOfficeNum();
                        break;

                    case "e":
                        SearchTeleNumber();
                        break;

                    case "E":
                        SearchTeleNumber();
                        break;

                    case "f":
                        ChangeOfficeNum();
                        break;

                    case "F":
                        ChangeOfficeNum();
                        break;

                    case "g":
                        SortName();
                        break;

                    case "G":
                        SortName();
                        break;

                    case "h":
                        break;

                    case "H":
                        break;

                    default:
                        Console.WriteLine("Please enter a valid choice: ");
                        break;
                }

            } while (userChoice != "h" && userChoice != "H");

            Console.WriteLine("\nPress Enter to exit");
            Console.ReadLine();

        } // end of main function

/***************************************************************** 
 * Function: ReadFile()                                          * 
 * Purpose: This function reads inputs from the file 'data1';    *
 * It contains three lines for each person lines with one string *
 * per line (name followed by office number followed by telephone*
 * number).                                                      *
 * Arguments: none                                               *
 * Return: none (void)                                           *
 *****************************************************************/ 

        private static void ReadFile()
        {
            using (StreamReader SR = new StreamReader("data1.txt"))
            {
                //declaring variables
                String name;
                String officeNum;
                String teleNum;

                //first read
                name = SR.ReadLine();
                officeNum = SR.ReadLine();
                teleNum = SR.ReadLine();
                
                //looping through the file and read the inputs 
                while (name != null)
                {
                    otherPerson[InUse] = new Person(name, officeNum, teleNum);
                    //second read
                    name = SR.ReadLine();
                    officeNum = SR.ReadLine();
                    teleNum = SR.ReadLine();
                    InUse++;
                }
            }

        } // end of ReadFile() function

 /**************************************************************
  * Function: DisplayMenue()                                   *
  * Purpose: This function displays options for the user,      *
  *          prompts the user to select an option, and gets the*
  *         user's choice and save it in a variable 'userInput'*
  * Arguments: none                                            *
  * Return: none (void)                                        *
  *************************************************************/

        public static string DisplayMenu()
        {
            string userInput;
            Console.WriteLine("Select one of the options below: \n");

            Console.WriteLine("a. Print the list");
            Console.WriteLine("b. Add an entry");
            Console.WriteLine("c. Search for a name");
            Console.WriteLine("d. Search for an office number");
            Console.WriteLine("e. Search for a telephone number");
            Console.WriteLine("f. Change an office number");
            Console.WriteLine("g. Sort the list (by name)");
            Console.WriteLine("h. Quit\n");
            userInput = Console.ReadLine();

            return userInput;

        } // end of DisplayMenu() function 

/**************************************************************
 * Function: DisplayList()                                    *
 * Purpose: This function loops through 'otherPerson' array   *
 *          and display a list of names, office numbers, and  *
 *          telephone numbers for the user.                   *
 * Arguments: none                                            *
 * Return: none (void)                                        *
 * ***********************************************************/

        private static void DisplayList()
        {
            //display columns header 
            Console.Write("Name".PadRight(20));
            Console.Write("Office Number".PadRight(20));
            Console.WriteLine("Telephone Number");

            for (int i = 0; i < InUse; i++)
            {
                //display recoreds or entries in the array
                Console.Write(otherPerson[i].Name.PadRight(20));
                Console.Write(otherPerson[i].OfficeNum.PadRight(20));
                Console.WriteLine(otherPerson[i].TeleNum);
            }
        } // end of DisplayList() function

 /***************************************************************
  * Function: AddEntry()                                        *
  * Purpose: This function prompts the user to enter a new entry*
  *          to this list of entries. The user must enter a name*
  *          an office number, and a Telephone number in order  *
  *          to be added to the existing list of entries.       *
  * Arguments: none                                             *
  * Return: none (void)                                         *
  * ************************************************************/

        private static void AddEntry()
        {
            string personName;
            string personOfficeNum;
            string personTeleNum;
            int i = 0;

            // prompt the user to enter some info
            Console.WriteLine("Enter the person's Name: ");
            personName = Console.ReadLine();
            Console.WriteLine("Enter the persons's office Number: ");
            personOfficeNum = Console.ReadLine();
            Console.WriteLine("Enter the person's Telephone Number: ");
            personTeleNum = Console.ReadLine();

            // lopping through the array to find the name entered by the user 
            for (; i < InUse; i++)
            {      //string Equal method to compare two strings values 
                if (String.Equals(personName, otherPerson[0].Name))
                {
                    Console.WriteLine("The name already exits");
                    break;
                }

            } 
            // if the info added by the user does not exist, add it to the list
            if (i == InUse)
            {
                otherPerson[InUse] = new Person(personName, personOfficeNum, personTeleNum);
                InUse++;
                Console.WriteLine("The information has been added to the list");
            }
        } // end of AddEntry() function 

/****************************************************************
 * Function: SearchName()                                       *
 * Purpose: This function searchs the array for a name based on *
 *          the user's input name. Once it finds it, it prints  *
 *          out the name and the info associated with it to the *
 *          screen.                                             *
 * Arguments: none                                              *
 * Return: none (void)                                          *
 * **************************************************************/

        private static void SearchName()
        {
            string someName;
            bool foundName = false;
            //prompt the user to enter a name 
            Console.WriteLine("Enter the name you wish to search for: ");
            someName = Console.ReadLine();             // get user's input and stores it in a variable 

            for (int i = 0; i < InUse; i++)
            {
                    // String Equal() method to compare two string values 
                if (String.Equals(someName.ToLower(), otherPerson[i].Name.ToLower()))
                {  
                    //if found, print the name and it's info to the screen
                    Console.Write(otherPerson[i].Name.PadRight(20));
                    Console.Write(otherPerson[i].OfficeNum.PadRight(20));
                    Console.WriteLine(otherPerson[i].TeleNum);
                    foundName = true;
                    break;
                }

            }
            // if the name entered by the user not found display a message
            if (!foundName)
                Console.WriteLine("The name {0} was not found ", someName);

        } // end of SearchName() function

/***************************************************************
 * Function: SearchOfficeNum()                                 *
 * Purpose: This function prompts the user to enter the office *                                                           *
 *          number wished to search for. Then it will loop     *
 *          through the array to find a match. Once it finds it*
 *          it will prints out the info associated with that   *
 *          office number.                                     *
 * Arguments: none                                             *
 * Return: none (void)                                         *
 * ************************************************************/

        private static void SearchOfficeNum()
        {
            //declaring variables 
            string someNum;
            bool foundNum = false;   //flag
            //prompt the user to enter the info needed 
            Console.WriteLine("Enter the office number you wish to search for: ");
            someNum = Console.ReadLine();

            for (int i = 0; i < InUse; i++)
            {       //comparing two strings to find a match 
                if (String.Equals(someNum, otherPerson[i].OfficeNum))
                {   // if found, write it to output
                    Console.Write(otherPerson[i].Name.PadRight(20));
                    Console.Write(otherPerson[i].OfficeNum.PadRight(20));
                    Console.WriteLine(otherPerson[i].TeleNum);
                    foundNum = true;
                }

            }
            // if not found, print a message let the user know
            if (!foundNum)
                Console.WriteLine("The office number {0} was not found ", someNum);

        } // end of SearchOfficeNum() function

/****************************************************************
 * Function: SearchTeleNumber()                                 *
 * Purpose:This function prompts the user to enter the telephone*
 *         number would like to search for and will search the  *
 *         array to find it. Once it finds it, it will print    *
 *         out the information of the person associated with    *
 *         that number.                                         *
 * Arguments: none                                              *
 * Return: none (void)                                          *
 * *************************************************************/

        private static void SearchTeleNumber()
        {
            string someTelephone;
            bool foundTele = false;
            // ask the user to enter a telephone number would like to search for
            Console.WriteLine("Enter the telephone number you wish to search for: ");
            someTelephone = Console.ReadLine();      // get the user value and stores it in a variabl

            for (int i = 0; i < InUse; i++)
            {
                    //String Equal method for comparing tow string values 
                if (String.Equals(someTelephone, otherPerson[i].TeleNum))
                {
                    Console.Write(otherPerson[i].Name.PadRight(20));
                    Console.Write(otherPerson[i].OfficeNum.PadRight(20));
                    Console.WriteLine(otherPerson[i].TeleNum);
                    foundTele = true;
                    break;
                }

            }
            // if the telephone number is not found print a message to the user 
            if (!foundTele)
                Console.WriteLine("The telephone number {0} was not found ", someTelephone);

        } // end of SearchTeleNumber() function

/*********************************************************************
 * Function: SortName()                                              *
 * Purpose: This function sort the entries in the array by name in   *
 *          alphabatical order then prints the new list to the screen*
 * Arguments: none                                                   *
 * Return: none (void)                                               *
 * *******************************************************************/

        private static void SortName()
        {
            Array.Sort(otherPerson, 0, InUse);
            Console.WriteLine("The list is sorted successfully");

        } // end of SortName() function

/****************************************************************
 * Function: ChangeOfficeNum()                                  *
 * Purpose: This function prompts the users to enter the office *
 *          number they would like an existing person to move to*
 *          the it reads the user input and display a messaege  *
 *          tells the user if the proccess is successfully      *
 *          done.                                               *
 * Arguments: none                                              *         
 * Return:none (void)                                           * 
 * *************************************************************/

        private static void ChangeOfficeNum()
        {
            string name;
            string newOfficeNum;
            bool found = false;
            Console.WriteLine("Enter the name associated with the office number you would like to replace: ");
            name = Console.ReadLine();

            Console.WriteLine("Enter the office number you would like the person to move to: ");
            newOfficeNum = Console.ReadLine();

            for (int i = 0; i < InUse; i++)
            { 
                if (String.Equals(name.ToLower(), otherPerson[i].Name.ToLower()))
                {
                    otherPerson[i].OfficeNum = newOfficeNum;
                    Console.WriteLine("The person you chose has been moved to {0} office number", newOfficeNum);
                    found = true;
                    break;  
                }

            }

            if (!found)
            {
                Console.WriteLine("The name you entered was not found.");
            }   
        }

    } // end of ChangeOfficeNum() function

/*******************************************************************
 * Class: Person                                                   *
 *                                                                 *
 * Access Modifier Type: Public                                    *
 *                                                                 *
 * Public Methods: String name, String officeNum, String TeleNum   *
 *                 CompareTo                                       *
 * Private Members: name, officeNum, teleNum                       *                                                              
 * ****************************************************************/

        public class Person : IComparable
        {
            //private members 
            private string name;
            private string officeNum;
            private string teleNum;

            //constructor to initialize Person to three strings values 
            public Person(string name, string officeNum, string teleNum)
            {
                this.name = name;
                this.officeNum = officeNum;
                this.teleNum = teleNum;
            }

/************************************************************
 * Function: Name                                           *
 * Purpose: This function has the get and set properties    *
 *          that will allow access to the private member of *
 *          the Person class 'name'. The get property will  *
 *          reads the private member and the set will set   *
 *          the private member to a value.                  *
 * *********************************************************/

            public string Name
            {
                get
                {
                    return this.name;
                }
                set
                {
                    this.name = value;
                }
            }

/**************************************************************
 * Function: OfficeNum                                        *
 * Purpose: It allows access to the private instant variable  * 
 *          OfficeNum and set it to a value and return a      * 
 *          string.                                           *
 *************************************************************/

            public string OfficeNum
            {
                get
                {
                    return this.officeNum;
                }
                set
                {
                    this.officeNum = value;
                }
            }

/**************************************************************
 * Function: TeleNum                                          *
 * Purpose: It allows access to the private instant variable  * 
 *          TeleNum and set it to a value and return a        * 
 *          string.                                           *
 *************************************************************/

            public string TeleNum
            {
                get
                {
                    return this.teleNum;
                }
                set
                {
                    this.teleNum = value;
                }
            }

        /**************************************************************
         * Function: CompareTo                                        *
         * Purpose: Compares the current instance with another object *
         *          of the same type and returns an integer that      *
         *          indicates whether the current instance precedes,  * 
         *          follows, or occurs in the same position in the    *
         *          sort order as the other object.                   *
         * Arguments: object OBJ                                      *
         * Return: integer                                            *
         *************************************************************/

        public int CompareTo(object OBJ)
            {
                Person NewPerson = (Person)OBJ;

                return String.Compare(this.name, NewPerson.Name);
                
            } // end of IComparable interface 

        }  // end of puplic class person  

} //end of namespace Assign1


