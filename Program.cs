using System;

internal class Program
{
    static void Main(string[] args)
    {
        int option = 1;
        string[] firstName = new string[50];
        string[] lastName = new string[50];
        int[] initialAccountValue = new int[50];
        int[] mineralQuantityD = new int[50];
        int[] mineralQuantityG = new int[50];
        int[] mineralQuantityP = new int[50];
        int[] mineralQuantityS = new int[50];
        int[] mineralQuantityC = new int[50];
        int name = 0;
        int last = 0;
        int deposit = 0;
        int userIndex = 0;
        int input = 0;
        int withdraw = 0;
        int mineral = 0;
        string userMineral = "";
        const int DIAMOND = 2000, GOLD = 1800, PLATINUM = 1200, SILVER = 30, COPPER = 5;

        int finalPriceMinerals = 0;
        int newBalance = 0;

        while (true)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n\tMY BANK APP");
            Console.WriteLine("\t------------------------");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("\t1. Enter one client data");
            Console.WriteLine("\t2. Show all the accounts");
            Console.WriteLine("\t3. Make a deposit");
            Console.WriteLine("\t4. Make a withdraw");
            Console.WriteLine("\t5. Purchasing Minerals");
            Console.WriteLine("\t6. Exit the application");
            Console.Write("\tEnter your choice: ");

            while (!int.TryParse(Console.ReadLine(), out option) || option < 1 || option > 6)
            {
                Console.WriteLine("\nPlease enter a number from 1-6.");
                Console.Write("Enter your choice: ");

            }

            switch (option)
            {
                case 1:
                    Console.WriteLine("\n1. Enter one client data");
                    Console.WriteLine("------------------------");
                    while (true)
                    {
                        while (string.IsNullOrEmpty(firstName[name]))
                        {
                            Console.Write("Please Enter Client's First Name: ");
                            firstName[name] = Console.ReadLine();
                        }
                        name++;

                        while (string.IsNullOrEmpty(lastName[last]))
                        {
                            Console.Write("Please Enter Client's Last Name : ");
                            lastName[last] = Console.ReadLine();
                        }
                        last++;

                        Console.Write("Initial amount of account: $");
                        while (!int.TryParse(Console.ReadLine(), out initialAccountValue[name - 1]))
                        {
                            Console.WriteLine("Must enter an Integer ");
                            Console.Write("Initial amount of account: ");
                        }
                        Console.WriteLine("Client Created!");
                        userIndex++;
                        break;
                    }
                    break;

                case 2:
                    Console.WriteLine("2. Show all the accounts");
                    Console.WriteLine("-------------------------------------");
                    Console.WriteLine("AccountIndex\tFirstName\tLastName\tAccountAmount\tDiamond\tGold\tPlatinum\tSilver\tCopper");
                    for (int indexValue = 0; indexValue < name; indexValue++)
                    {
                        Console.WriteLine($"{indexValue}\t\t{firstName[indexValue]}\t\t{lastName[indexValue]}\t\t{initialAccountValue[indexValue]}\t\t{mineralQuantityD[indexValue]}\t{mineralQuantityG[indexValue]}\t{mineralQuantityP[indexValue]}\t\t{mineralQuantityS[indexValue]}\t\t{mineralQuantityC[indexValue]}");
                    }
                    break;

                case 3:
                    Console.WriteLine("3. Make a deposit");
                    Console.WriteLine("------------------------");
                    Console.Write("Enter Account Index Value: ");
                    input = Convert.ToInt32(Console.ReadLine());

                    if (input >= userIndex || input < 0)
                    {
                        Console.WriteLine("Error: Invalid user index");
                    }
                    else
                    {
                        Console.Write("Enter How Much Money You Want to Deposit: ");
                        while (!int.TryParse(Console.ReadLine(), out deposit))
                        {
                            Console.WriteLine("Please enter an integer");
                        }

                        newBalance = deposit + initialAccountValue[input];
                        initialAccountValue[input] = newBalance;

                        Console.WriteLine("Deposited money was a success!");
                        Console.WriteLine("Your new balance: " + newBalance);
                    }
                    break;

                case 4:
                    Console.WriteLine("4. Make a withdraw");
                    Console.WriteLine("------------------------");
                    Console.Write("Enter Account Index Value: ");
                    input = Convert.ToInt32(Console.ReadLine());

                    if (input >= userIndex || input < 0)
                    {
                        Console.WriteLine("Error: Invalid user index");
                    }
                    else
                    {
                        Console.Write("Enter How Much Money You Want to Withdraw: ");
                        while (!int.TryParse(Console.ReadLine(), out withdraw))
                        {
                            Console.WriteLine("Please enter an integer ");
                        }

                        newBalance = initialAccountValue[input] - withdraw;
                        initialAccountValue[input] = newBalance;

                        Console.WriteLine("Withdrawn money was a success!");
                        Console.WriteLine("Your new balance: " + newBalance);
                    }
                    break;

                case 5:
                    newBalance = initialAccountValue[input];
                    try
                    {
                        Console.Write("\nDiamond:$2000/oz\tGold:$1800/oz\nPlatinum:$1200/oz\tSilver:$30/oz\nCopper:$5/oz\n--------------------------------------\nWhat mineral will you be purchasing: ");
                        userMineral = Console.ReadLine();
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid input. Please enter a valid mineral.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("An error occurred: " + ex.Message);
                    }

                    if (userMineral.ToLower() == "diamond")
                    {
                        Console.Write("Quantity: ");
                        while (!int.TryParse(Console.ReadLine(), out mineral))
                        {
                            Console.WriteLine("Please Enter an Integer");
                        }

                        finalPriceMinerals = mineral * DIAMOND;
                        mineralQuantityD[input] += mineral;

                        if (finalPriceMinerals > newBalance)
                        {
                            Console.Write("Sorry for the inconvenience, but it appears you are missing money for your purchase");
                        }
                        else
                        {
                            Console.WriteLine($"Congratulations! You just purchased {mineral} oz {userMineral}");
                            Console.WriteLine($"Your New Balance is: {newBalance - finalPriceMinerals}");
                        }
                    }
                    else if (userMineral.ToLower() == "platinum")
                    {
                        Console.Write("Quantity: ");
                        while (!int.TryParse(Console.ReadLine(), out mineral))
                        {
                            Console.WriteLine("Please Enter an Integer");
                        }

                        finalPriceMinerals = mineral * PLATINUM;
                        mineralQuantityP[input] += mineral;

                        if (finalPriceMinerals > newBalance)
                        {
                            Console.Write("Sorry for the inconvenience, but it appears you are missing money for your purchase");
                        }
                        else
                        {
                            Console.WriteLine($"Congratulations! You just purchased {mineral} oz {userMineral}");
                            Console.WriteLine($"Your New Balance is: {newBalance - finalPriceMinerals}");
                        }
                    }
                    else if (userMineral.ToLower() == "silver")
                    {
                        Console.Write("Quantity: ");
                        while (!int.TryParse(Console.ReadLine(), out mineral))
                        {
                            Console.WriteLine("Please Enter an Integer");
                        }

                        finalPriceMinerals = mineral * SILVER;
                        mineralQuantityS[input] += mineral;

                        if (finalPriceMinerals > newBalance)
                        {
                            Console.Write("Sorry for the inconvenience, but it appears you are missing money for your purchase");
                        }
                        else
                        {
                            Console.WriteLine($"Congratulations! You just purchased {mineral} oz {userMineral}");
                            Console.WriteLine($"Your New Balance is: {newBalance - finalPriceMinerals}");
                        }
                    }
                    else if (userMineral.ToLower() == "copper")
                    {
                        Console.Write("Quantity: ");
                        while (!int.TryParse(Console.ReadLine(), out mineral))
                        {
                            Console.WriteLine("Please Enter an Integer");
                        }

                        finalPriceMinerals = mineral * COPPER;
                        mineralQuantityC[input] += mineral;

                        if (finalPriceMinerals > newBalance)
                        {
                            Console.Write("Sorry for the inconvenience, but it appears you are missing money for your purchase");
                        }
                        else
                        {
                            Console.WriteLine($"Congratulations! You just purchased {mineral} oz {userMineral}");
                            Console.WriteLine($"Your New Balance is: {newBalance - finalPriceMinerals}");
                        }
                    }
                    else if (userMineral.ToLower() == "gold")
                    {
                        Console.Write("Quantity: ");
                        while (!int.TryParse(Console.ReadLine(), out mineral))
                        {
                            Console.WriteLine("Please Enter an Integer");
                        }

                        finalPriceMinerals = mineral * GOLD;
                        mineralQuantityG[input] += mineral;

                        if (finalPriceMinerals > newBalance)
                        {
                            Console.Write("Sorry for the inconvenience, but it appears you are missing money for your purchase");
                        }
                        else
                        {
                            Console.WriteLine($"Congratulations! You just purchased {mineral} oz {userMineral}");
                            Console.WriteLine($"Your New Balance is: {newBalance - finalPriceMinerals}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Inputted Wrong Mineral");
                    }

                    break;

                case 6:
                    Console.WriteLine("Thank you for stopping by at Bank Of Esteria, we hope to see you again!");
                    Environment.Exit(0);
                    break;
            }

            Console.WriteLine();
            Console.Write("Press any key");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
