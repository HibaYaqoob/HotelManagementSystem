using System;
using System.Collections.Generic;

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
        public int guestId;
        public string guestName;
        public int roomNumber;
        public string checkInDate;
        public int totalNights;
        public double pricePerNight;

        // Constructor
        public Guest(int id, string name, int room, string date, int nights, double price)
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
                        // AddRoom();
                        Console.WriteLine("Add Room feature coming soon.");
                        break;

                    case 2:
                        // AddGuest();
                        Console.WriteLine("Register Guest feature coming soon.");
                        break;

                    case 3:
                        Console.WriteLine("Book Room feature coming soon.");
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
        // View All Rooms
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
        // View All Guests
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