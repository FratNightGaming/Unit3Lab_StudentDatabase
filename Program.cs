using System.Collections.Generic;

namespace StudentDataBase
{
    internal class Program
    {
        public static int studentID = 0;
        public static string userInput = string.Empty;

        public static string[] studentNames = new string[5] { "Joseph", "Kate", "Ally", "Simon", "John" };
        public static string[] studentHometowns = new string[5] { "Chicago", "Houston", "San Francisco", "Toronto", "Atlanta" };
        public static string[] studentFavoriteFoods = new string[5] { "Key Lime Pie", "Pizza", "Spaghetti", "Lobster", "Burrito" };


        static void Main(string[] args)
        {
            UserPrompt();
        }

        //Prompts user for userID. While loop used for exception handling. Option to view all students.
        public static void UserPrompt()
        {
            Console.WriteLine($"Welcome to the student information database! Which student would you like to know more about?\nPlease enter a number 0 - {studentNames.Length - 1} for more information.\nEnter -1 to display a list of all students.");
            userInput = Console.ReadLine();

            while (true)
            {
                if (!int.TryParse(userInput, out studentID))
                {
                    Console.WriteLine("Please enter a numerical value and try again.");
                    userInput = Console.ReadLine();
                    continue;
                }

                else if (!WithinRange(studentID, 0, studentNames.Length - 1) && studentID != -1)
                {
                    Console.WriteLine($"Your number is out of range. Please enter a number within the specified range: 0 - {studentNames.Length}. Enter \"-1\" to view list of students:");
                    userInput = Console.ReadLine();
                    continue;
                }

                else if (studentID == -1)
                {
                    Console.WriteLine();
                    DisplayNames(studentNames);
                    Console.WriteLine("\nPlease enter a student ID:");
                    userInput = Console.ReadLine();
                    continue;
                }

                else
                {
                    SelectionScreen();
                    break;
                }
            }
        }

        //Compare user input against lists of words. If there is a match, a corresponding function will be called to display the correct data. A while loop is used to ensure that user enters acceptable input.
        public static void SelectionScreen()
        {
            Console.WriteLine($"You have selected {studentNames[studentID]}. Would you like to know {studentNames[studentID]}'s hometown or favorite food? Press \"b\" to select previous screen.");

            List<string> hometownWords = new List<string>();
            List<string> foodWords = new List<string>();

            hometownWords.AddRange(new List<string> { "HOME", "TOWN", "HOMETOWN", "HOME TOWN" });
            foodWords.AddRange(new List<string> { "FAVORITE", "FOOD", "FAV", "FAVORITE FOOD", "FAVORITEFOOD" });

            while (true)
            {
                string selectedCategory = Console.ReadLine().ToUpper().Trim();

                if (hometownWords.Contains(selectedCategory))
                {
                    DisplayHomeTown(studentID);
                    break;
                }

                else if (foodWords.Contains(selectedCategory))
                {
                    DisplayFavoriteFood(studentID);
                    break;
                }

                else if (selectedCategory == "B")
                {
                    UserPrompt();
                    break;
                }

                else
                {
                    Console.WriteLine($"{selectedCategory} is not a category. Please try again.\nEnter \"Hometown\" or \"favorite food\", or press \"b\" to go back:");
                }
            }

            Console.WriteLine("\nWould you like to try again?\n" +
                "Enter \"Y\" to start again. " +
                "Enter \"N\" to exit. ");
            
            Continue();
        }

        //prompt user to continue or exit program
        public static void Continue()
        {
            string userContinue = Console.ReadLine().ToUpper();

            if (userContinue == "Y" || userContinue == "YES")
            {
                Console.WriteLine();
                UserPrompt();
            }

            else
            {
                Console.WriteLine("\nExiting program. Goodbye!");
            }
        }

        /*public static bool GoAgain()//why cant I call this? if (GoAgain) does not work!
        {
            string userContinue = Console.ReadLine().ToUpper();

            return userContinue == "Y" || userContinue == "YES";
        }*/

        //more concise code commented out but I wanted to practice for loops
        public static void DisplayHomeTown(int index)
        {
            for (int i = 0; i < studentNames.Length; i++)
            {
                if (index == i)
                {
                    Console.WriteLine($"{studentNames[i]}'s hometown is {studentHometowns[i]}.");
                }

                //Console.WriteLine($"{studentNames[index]}'s hometown is {studentHometowns[index]}");
            }
        }

        //more concise code commented out but I wanted to practice for loops

        public static void DisplayFavoriteFood(int index)
        {
            for (int i = 0; i < studentNames.Length; i++)
            {
                if (index == i)
                {
                    Console.WriteLine($"{studentNames[i]}'s favorite food is {studentFavoriteFoods[i]}.");
                }

                //Console.WriteLine($"{studentNames[index]}'s hometown is {studentFavoriteFoods[index]}");
            }
        }
       
        //displays all user ID with corresponding name
        public static void DisplayNames(string[] names)
        {
            for (int i = 0; i < names.Length; i++)
            {
                Console.WriteLine($"{i} \t {names[i]}");
            }
            Console.WriteLine();
            Console.WriteLine();
        }
        
        //determines if number is within specified range
        public static bool WithinRange(int userNumber, int minRange, int maxRange)
        {
            return userNumber >= minRange && userNumber <= maxRange;
        }
    }
}
/*
 * Task: Write a program that will recognize invalid inputs when the user requests information about students in a class.

What will the application do?
2 Points: Create 3 arrays and fill them with student information—one with name, one with hometown, one with favorite food
1 Point: Prompt the user to ask about a particular student by number. Convert the input to an integer. Use the integer as the index for the arrays. Print the student’s name.
1 Point: Ask the user which category to display: Hometown or Favorite food. Then display the relevant information.
1 Point: Ask the user if they would like to learn about another student.

Build Specifications:
1 Point: Validate user number: Use an if statement to check if the number is out of range, i.e. either less than 1 or greater than the length of the arrays. If so, display a friendly message and let the user try again.
1 Point: Validate category: Ask the user what information category to display: "Hometown" or "Favorite Food". Use an if statement to check that they entered either category name correctly. If they entered an incorrect category, display a friendly message and re-ask the question. (See hints below!)
1 Point: Array Length: Use the first array’s Length property in your code instead of hardcoding it.

Hints:
Make sure the arrays are the same size.
Let the user enter a number from 1 up to and including the length of the array. To get the index, subtract 1 from the number they entered.
For the valid category: You might create a separate program to test out some code that uses a while loop and asks for either “Hometown” or “Favorite Food.” And only finishes the loop if either of these two is entered. Once you have it working, copy the code over to your “real” code.
Make it easy for the user – tell them what information is available

Extra Challenges:
1 Point: Provide an option where the user can see a list of all students.
2 Points: Allow the user to search by student name (Good challenge but difficult!)
1 Point: Category names: Allow uppercase and lowercase; allow portion of word such as "Food" instead of "Favorite Food"
*/