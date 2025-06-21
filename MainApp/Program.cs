using System;
using DataDomain;

class Program
{
    static void Main()
    {
        string connectionString = "Server=DESKTOP-KGIM8M1\\SQLEXPRESS;Database=CrudAppDb;Trusted_Connection=True;TrustServerCertificate=True;";
        var service = new DatabaseService(connectionString);

        while (true)
        {
            Console.WriteLine("\n=== USER MENU ===");
            Console.WriteLine("1. Create user");
            Console.WriteLine("2. Read user");
            Console.WriteLine("3. Update user");
            Console.WriteLine("4. Delete user");
            Console.WriteLine("0. Exit");
            Console.Write("Choose an option: ");
            string? choice = Console.ReadLine();

            try
            {
                switch (choice)
                {
                    case "1":
                        Console.Write("Enter user name: ");
                        string? name = Console.ReadLine();
                        service.CreateUser(new User { Name = name ?? string.Empty });
                        Console.WriteLine("User created.");
                        break;

                    case "2":
                        Console.Write("Enter user ID: ");
                        if (int.TryParse(Console.ReadLine(), out int readId))
                        {
                            var user = service.GetUser(readId);
                            Console.WriteLine(user != null ? $"ID: {user.Id}, Name: {user.Name}" : "User not found.");
                        }
                        break;

                    case "3":
                        Console.Write("Enter user ID to update: ");
                        if (int.TryParse(Console.ReadLine(), out int updateId))
                        {
                            Console.Write("Enter new name: ");
                            string? newName = Console.ReadLine();
                            service.UpdateUser(new User { Id = updateId, Name = newName ?? string.Empty });
                            Console.WriteLine("User updated.");
                        }
                        break;

                    case "4":
                        Console.Write("Enter user ID to delete: ");
                        if (int.TryParse(Console.ReadLine(), out int deleteId))
                        {
                            service.DeleteUser(deleteId);
                            Console.WriteLine("User deleted.");
                        }
                        break;

                    case "0":
                        Console.WriteLine("Exiting application.");
                        return;

                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
