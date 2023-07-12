namespace AdoDotNet_StoredProcedures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source = SANJANA; Database = OrderManagementSystem; Integrated Security = true";

            StoreProcedureOperations storeProcedureOperations = new StoreProcedureOperations(connectionString);

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("******************MENU:******************");
                Console.WriteLine("=> To Add Data Using Non Transaction Stored Procedure: PRESS 1");
                Console.WriteLine("=> To Add Data Using Transaction Stored Procedure: PRESS 2");
                Console.WriteLine("=> To Display all Orders: PRESS 3");
                Console.WriteLine("=> To EXIT: PRESS 4");

                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            Console.WriteLine("Enter the details to Add an Order: ");

                            Console.Write("Enter First Name: ");
                            string firstName = Console.ReadLine();

                            Console.Write("Enter Last Name: ");
                            string lastName = Console.ReadLine();

                            Console.Write("Enter Email: ");
                            string email = Console.ReadLine();

                            Console.Write("Enter Order Date: ");
                            DateTime orderDate = Convert.ToDateTime(Console.ReadLine());

                            Console.Write("Enter Order Total: ");
                            string orderTotal = Console.ReadLine();

                            storeProcedureOperations.AddUsingNonTransactionStoredProcedure(firstName, lastName, email, orderDate, orderTotal);
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Enter the details to Add an Order: ");

                            Console.Write("Enter First Name: ");
                            string firstName = Console.ReadLine();

                            Console.Write("Enter Last Name: ");
                            string lastName = Console.ReadLine();

                            Console.Write("Enter Email: ");
                            string email = Console.ReadLine();

                            Console.Write("Enter Order Date: ");
                            DateTime orderDate = Convert.ToDateTime(Console.ReadLine());

                            Console.Write("Enter Order Total: ");
                            string orderTotal = Console.ReadLine();

                            storeProcedureOperations.AddUsingTransactionStoredProcedure(firstName, lastName, email, orderDate, orderTotal);
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Displaying all the Orders: ");
                            storeProcedureOperations.Display();
                            break;
                        }
                    case 4:
                        {
                            Environment.Exit(0);
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Invalid Choice!!!");
                            break;
                        }
                }
            }
        }
    }
}