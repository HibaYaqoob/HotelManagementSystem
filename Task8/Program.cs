using System;
using System.Collections.Generic;
using System.Linq;
namespace Task8
{
    // --------------------------------------------------------------
    // Room Class
    // --------------------------------------------------------------
    public class Room
    {
        public int roomNumber;
        public string roomType;
        public double pricePerNight;
        public bool isAvailable;

        // Constructor
        public Room(int number, string type, double price, bool available)
        {
            roomNumber = number;
            roomType = type;
            pricePerNight = price;
            isAvailable = available;
        }

        // Display room details
        public void displayRoom()
        {
            Console.WriteLine("Room Number: " + roomNumber);
            Console.WriteLine("Room Type: " + roomType);
            Console.WriteLine("Price Per Night: " + pricePerNight);
            Console.WriteLine("Available: " + isAvailable);
        }
    }

    // --------------------------------------------------------------
    // Guest Class
    // --------------------------------------------------------------
    public class Guest
    {
        public string guestId;
        public string guestName;
        public int roomNumber;
        public string checkInDate;
        public int totalNights;
        public double pricePerNight;

        // Constructor
        public Guest(string id, string name, int room, string date, int nights, double price)
        {
            guestId = id;
            guestName = name;
            roomNumber = room;
            checkInDate = date;
            totalNights = nights;
            pricePerNight = price;
        }

        // Display guest details
        public void displayGuest()
        {
            Console.WriteLine("Guest ID: " + guestId);
            Console.WriteLine("Guest Name: " + guestName);
            Console.WriteLine("Room Number: " + roomNumber);
            Console.WriteLine("Check In Date: " + checkInDate);
            Console.WriteLine("Total Nights: " + totalNights);
            Console.WriteLine("Total Cost: " + calculateTotalCost());
        }

        // Calculate total cost
        public double calculateTotalCost()
        {
            return totalNights * pricePerNight;
        }
    }

    // --------------------------------------------------------------
    // Program Class
    // --------------------------------------------------------------
    internal class Program
    {
        static List<Room> rooms = new List<Room>();
        static List<Guest> guests = new List<Guest>();

        static void Main(string[] args)
        {
            LoadRooms();

            int choice;

            do
            {
                Console.WriteLine("\n==============================");
                Console.WriteLine(" GRAND VISTA HOTEL SYSTEM");
                Console.WriteLine("==============================");
                Console.WriteLine("1. Add New Room");
                Console.WriteLine("2. Register New Guest");
                Console.WriteLine("3. Book a Room");
                Console.WriteLine("4. View All Rooms");
                Console.WriteLine("5. View All Guests");
                Console.WriteLine("0. Exit");

                Console.Write("Choice: ");

                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        AddRoom();
                        break;

                    case 2:
                         AddGuest();
                        break;

                    case 3:
                        BookRoom();
                        break;

                    case 4:
                        ViewRooms();
                        break;

                    case 5:
                        ViewGuests();
                        break;

                    case 0:
                        Console.WriteLine("Goodbye!");
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }

            } while (choice != 0);
        }

        // --------------------------------------------------------------
        // Load Sample Rooms
        // --------------------------------------------------------------
        static void LoadRooms()
        {
            rooms.Add(new Room(101, "Single", 20, true));
            rooms.Add(new Room(102, "Double", 35, true));
            rooms.Add(new Room(103, "Suite", 80, true));
            rooms.Add(new Room(104, "Single", 25, true));
            rooms.Add(new Room(105, "Double", 45, true));
            rooms.Add(new Room(106, "Suite", 100, true));
        }

        // --------------------------------------------------------------
        //Case 1: Add New Room
        // --------------------------------------------------------------
        static void AddRoom()
        {
            Console.WriteLine("\n----- Add New Room -----");

            int roomNumber;
            double price;

            // Validate Room Number
            while (true)
            {
                Console.Write("Enter room number: ");

                if (int.TryParse(Console.ReadLine(), out roomNumber) && roomNumber > 0)
                {
                    break;
                }

                Console.WriteLine("Invalid room number. Must be a positive number.");
            }


            // Check duplicate room number using LINQ Any()
            bool exists = rooms.Any(r => r.roomNumber == roomNumber);

            if (exists)
            {
                Console.WriteLine("Error: Room number already exists.");
                return;
            }


            // Enter Room Type
            Console.Write("Enter room type (Single / Double / Suite): ");
            string roomType = Console.ReadLine();


            // Validate Price
            while (true)
            {
                Console.Write("Enter price per night: ");

                if (double.TryParse(Console.ReadLine(), out price) && price > 0)
                {
                    break;
                }

                Console.WriteLine("Invalid price. Must be a positive number.");
            }


            // Create new Room object
            Room newRoom = new Room(
                roomNumber,
                roomType,
                price,
                true
            );


            // Add room to list
            rooms.Add(newRoom);


            // Success message
            Console.WriteLine("\nRoom added successfully!");
            Console.WriteLine("------------------------");
            Console.WriteLine("Room Number: " + newRoom.roomNumber);
            Console.WriteLine("Room Type: " + newRoom.roomType);
            Console.WriteLine("Price Per Night: " + newRoom.pricePerNight);
            Console.WriteLine("Available: " + newRoom.isAvailable);
            Console.WriteLine("Total Rooms: " + rooms.Count);
        }

        // --------------------------------------------------------------
        // Case 2: Register New Guest
        // --------------------------------------------------------------
        static void AddGuest()
        {
            Console.WriteLine("\n----- Register New Guest -----");


            // Auto generate Guest ID
            string guestId = "G" + (guests.Count() + 1).ToString("D3");


            // Guest Name
            Console.Write("Enter guest name: ");
            string guestName = Console.ReadLine();


            // Check-in Date
            Console.Write("Enter check-in date (Example: 19/07/2026): ");
            string checkInDate = Console.ReadLine();


            // Validate number of nights
            int totalNights;

            while (true)
            {
                Console.Write("Enter number of nights: ");

                if (int.TryParse(Console.ReadLine(), out totalNights)
                    && totalNights > 0)
                {
                    break;
                }

                Console.WriteLine("Invalid number of nights. Must be positive.");
            }


            // Room not assigned yet
            int roomNumber = 0;


            // Create Guest object
            Guest newGuest = new Guest(
                guestId,
                guestName,
                roomNumber,
                checkInDate,
                totalNights,
                0
            );


            // Add guest to list
            guests.Add(newGuest);


            // Confirmation
            Console.WriteLine("\nGuest registered successfully!");
            Console.WriteLine("-----------------------------");
            Console.WriteLine("Guest ID: " + newGuest.guestId);
            Console.WriteLine("Guest Name: " + newGuest.guestName);
            Console.WriteLine("Check-in Date: " + newGuest.checkInDate);
            Console.WriteLine("Total Nights: " + newGuest.totalNights);
            Console.WriteLine("Room Number: Not Assigned");
            Console.WriteLine("Total Guests: " + guests.Count());
        }

        // --------------------------------------------------------------
        // Case 3: Book Room for Guest
        // --------------------------------------------------------------
        static void BookRoom()
        {
            Console.WriteLine("\n----- Book Room -----");


            // Enter Guest ID
            Console.Write("Enter guest ID (Example: G001): ");
            string guestId = Console.ReadLine();


            // Enter Room Number
            Console.Write("Enter room number: ");
            int roomNumber;

            if (!int.TryParse(Console.ReadLine(), out roomNumber))
            {
                Console.WriteLine("Invalid room number.");
                return;
            }


            // Find guest using LINQ FirstOrDefault()
            Guest guest = guests.FirstOrDefault(g => g.guestId == guestId);


            if (guest == null)
            {
                Console.WriteLine("Error: Guest not found.");
                return;
            }


            // Find room using LINQ FirstOrDefault()
            Room room = rooms.FirstOrDefault(r => r.roomNumber == roomNumber);


            if (room == null)
            {
                Console.WriteLine("Error: Room not found.");
                return;
            }


            // Check room availability
            if (!room.isAvailable)
            {
                Console.WriteLine("Room is already booked.");
                return;
            }


            // Update objects in the lists
            guest.roomNumber = room.roomNumber;
            guest.pricePerNight = room.pricePerNight;

            room.isAvailable = false;


            // Booking confirmation
            Console.WriteLine("\nBooking successful!");
            Console.WriteLine("----------------------");
            Console.WriteLine("Guest Name: " + guest.guestName);
            Console.WriteLine("Room Number: " + room.roomNumber);
            Console.WriteLine("Room Type: " + room.roomType);
            Console.WriteLine("Price Per Night: " + room.pricePerNight);
            Console.WriteLine("Total Nights: " + guest.totalNights);
            Console.WriteLine("Total Cost: " + guest.calculateTotalCost());
        }

        // --------------------------------------------------------------
        // Case 4: View All Rooms
        // --------------------------------------------------------------
        static void ViewRooms()
        {
            Console.WriteLine("\n----- Rooms -----");

            foreach (Room room in rooms)
            {
                room.displayRoom();
                Console.WriteLine("---------------------------");
            }
        }

        // --------------------------------------------------------------
        //Case 5: View All Guests
        // --------------------------------------------------------------
        static void ViewGuests()
        {
            Console.WriteLine("\n----- Guests -----");

            if (guests.Count == 0)
            {
                Console.WriteLine("No guests registered.");
                return;
            }

            foreach (Guest guest in guests)
            {
                guest.displayGuest();
                Console.WriteLine("---------------------------");
            }
        }


    
    
    
    
    
    
    }

}