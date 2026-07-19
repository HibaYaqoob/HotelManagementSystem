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
                Console.WriteLine("6. Search & Filter Rooms");
                Console.WriteLine("7. Guest & Booking Statistics");
                Console.WriteLine("8. Update Room Price");
                Console.WriteLine("9. Guest Lookup by Name");
                Console.WriteLine("10. Room Type Breakdown Report");
                Console.WriteLine("11. Check Out a Guest");
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

                    case 6:
                        SearchRooms();
                        break;
                    case 7:
                        GuestBookingStatistics();
                        break;
                    case 8:
                        UpdateRoomPrice();
                        break;
                    case 9:
                        GuestLookupByName();
                        break;
                    case 10:
                        RoomTypeBreakdownReport();
                        break;
                    case 11:
                        CheckOutGuest();
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

        // -----------------------------------------------------------------
        // Case 6: Search & Filter Rooms:
        // -----------------------------------------------------------------

        static void SearchRooms()
        {
            int option;

            do
            {
                Console.WriteLine("\n===== SEARCH & FILTER ROOMS =====");
                Console.WriteLine("1. Show All Available Rooms");
                Console.WriteLine("2. Filter by Room Type");
                Console.WriteLine("3. Filter by Maximum Price");
                Console.WriteLine("4. Room Price Statistics");
                Console.WriteLine("0. Back to Main Menu");

                Console.Write("Choose an option: ");

                while (!int.TryParse(Console.ReadLine(), out option))
                {
                    Console.Write("Invalid input. Please enter a number: ");
                }

                switch (option)
                {
                    case 1:
                        ShowAvailableRooms();
                        break;

                    case 2:
                        FilterByRoomType();
                        break;

                    case 3:
                        FilterByPrice();
                        break;

                    case 4:
                        RoomStatistics();
                        break;

                    case 0:
                        Console.WriteLine("Returning to Main Menu...");
                        break;

                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }

            } while (option != 0);
        }

        /// /////////////////////////////////////////////////////////////////////


        // Option 1 (Where + OrderBy)

        static void ShowAvailableRooms()
        {
            var availableRooms = rooms
                .Where(r => r.isAvailable)
                .OrderBy(r => r.pricePerNight);

            if (!availableRooms.Any())
            {
                Console.WriteLine("No rooms found for the selected criteria.");
                return;
            }

            Console.WriteLine("\nAvailable Rooms");
            Console.WriteLine("Count: " + availableRooms.Count());

            foreach (Room room in availableRooms)
            {
                room.displayRoom();
                Console.WriteLine("-----------------------");
            }
        }
        
        /// /////////////////////////////////////////////////////////////////////
       

        // Option 2: Filter By Type
        static void FilterByRoomType()
        {
            Console.Write("Enter room type (Single/Double/Suite): ");
            string type = Console.ReadLine();

            var filteredRooms = rooms
                .Where(r => r.roomType.Equals(type, StringComparison.OrdinalIgnoreCase));

            if (!filteredRooms.Any())
            {
                Console.WriteLine("No rooms found for the selected criteria.");
                return;
            }

            Console.WriteLine("\nMatching Rooms");
            Console.WriteLine("Count: " + filteredRooms.Count());

            foreach (Room room in filteredRooms)
            {
                room.displayRoom();
                Console.WriteLine("-----------------------");
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////


        // Option 3: Filter By Price
        static void FilterByPrice()
        {
            Console.Write("Enter maximum price: ");

            double maxPrice;

            if (!double.TryParse(Console.ReadLine(), out maxPrice))
            {
                Console.WriteLine("Invalid price.");
                return;
            }

            var filteredRooms = rooms
                .Where(r => r.isAvailable && r.pricePerNight <= maxPrice)
                .OrderBy(r => r.pricePerNight);

            if (!filteredRooms.Any())
            {
                Console.WriteLine("No rooms found for the selected criteria.");
                return;
            }

            Console.WriteLine("\nMatching Rooms");
            Console.WriteLine("Count: " + filteredRooms.Count());

            foreach (Room room in filteredRooms)
            {
                room.displayRoom();
                Console.WriteLine("-----------------------");
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////


        // Option 4: Room Price Statistics
        static void RoomStatistics()
        {
            Console.WriteLine("\nRoom Statistics");
            Console.WriteLine("-----------------------");

            Console.WriteLine("Total Rooms: " + rooms.Count());

            Console.WriteLine("Available Rooms: "
                + rooms.Count(r => r.isAvailable));

            Console.WriteLine("Average Price: "
                + rooms.Average(r => r.pricePerNight).ToString("F2"));

            Console.WriteLine("Cheapest Price: "
                + rooms.Min(r => r.pricePerNight).ToString("F2"));

            Console.WriteLine("Most Expensive Price: "
                + rooms.Max(r => r.pricePerNight).ToString("F2"));
        }

        // -----------------------------------------------------------------
        // Case 7: Guest Booking Statistics
        // -----------------------------------------------------------------
        static void GuestBookingStatistics()
        {
            Console.WriteLine("\n===== GUEST & BOOKING STATISTICS =====");

            // Total guests
            Console.WriteLine("Total Registered Guests: " + guests.Count());

            // Guests with active bookings
            Console.WriteLine("Guests With Bookings: "
                + guests.Count(g => g.roomNumber != 0));

            // Total rooms
            Console.WriteLine("Total Rooms: " + rooms.Count());

            // Booked rooms
            Console.WriteLine("Booked Rooms: "
                + rooms.Count(r => !r.isAvailable));

            // Check if there are active bookings
            if (!guests.Any(g => g.roomNumber != 0))
            {
                Console.WriteLine("\nNo active bookings recorded.");
                return;
            }

            // Average nights
            double averageNights = guests
                .Where(g => g.roomNumber != 0)
                .Average(g => g.totalNights);

            Console.WriteLine("Average Nights: "
                + averageNights.ToString("F2"));

            // Top 3 highest spending guests
            Console.WriteLine("\nTop 3 Highest Spending Guests");

            var topGuests = guests
                .Where(g => g.roomNumber != 0)
                .OrderByDescending(g => g.calculateTotalCost())
                .Take(3);

            foreach (Guest guest in topGuests)
            {
                Console.WriteLine(
                    guest.guestName
                    + " | Room "
                    + guest.roomNumber
                    + " | OMR "
                    + guest.calculateTotalCost().ToString("F2"));
            }

            // Guest Summary
            Console.WriteLine("\nGuest Booking Summary");

            var summaries = guests
                .Where(g => g.roomNumber != 0)
                .Select(g =>
                    g.guestName
                    + " - Room "
                    + g.roomNumber
                    + " - "
                    + g.totalNights
                    + " nights - OMR "
                    + g.calculateTotalCost().ToString("F2"));

            foreach (string summary in summaries)
            {
                Console.WriteLine(summary);
            }
        }

        // -----------------------------------------------------------------
        // Case 8: Update Room Price
        // -----------------------------------------------------------------

        static void UpdateRoomPrice()
        {
            Console.WriteLine("\n===== UPDATE ROOM PRICE =====");

            Console.Write("Enter room number: ");

            int roomNumber;

            if (!int.TryParse(Console.ReadLine(), out roomNumber))
            {
                Console.WriteLine("Invalid room number.");
                return;
            }

            Room room = rooms.FirstOrDefault(r => r.roomNumber == roomNumber);

            if (room == null)
            {
                Console.WriteLine("Room not found.");
                return;
            }

            Console.Write("Enter new price per night: ");

            double newPrice;

            if (!double.TryParse(Console.ReadLine(), out newPrice) || newPrice <= 0)
            {
                Console.WriteLine("Invalid price.");
                return;
            }

            double oldPrice = room.pricePerNight;

            room.pricePerNight = newPrice;

            Console.WriteLine("\nRoom price updated successfully.");
            Console.WriteLine("Room Number: " + room.roomNumber);
            Console.WriteLine("Old Price: OMR " + oldPrice.ToString("F2"));
            Console.WriteLine("New Price: OMR " + room.pricePerNight.ToString("F2"));
        }

        // -------------------------------------------------------------------------------
        // Case 9: Guest Lookup by Name
        // -------------------------------------------------------------------------------
        static void GuestLookupByName()
        {
            Console.WriteLine("\n===== GUEST LOOKUP BY NAME =====");

            Console.Write("Enter guest name or part of the name: ");
            string searchText = Console.ReadLine();

            var matchingGuests = guests.Where(g =>
                g.guestName.Contains(searchText, StringComparison.OrdinalIgnoreCase));

            if (matchingGuests.Count() == 0)
            {
                Console.WriteLine("No guests matched that search.");
                return;
            }

            Console.WriteLine("\nNumber of matches: " + matchingGuests.Count());

            foreach (Guest guest in matchingGuests)
            {
                Console.WriteLine("----------------------------");
                Console.WriteLine("Guest ID: " + guest.guestId);
                Console.WriteLine("Guest Name: " + guest.guestName);

                if (guest.roomNumber == 0)
                    Console.WriteLine("Room Number: Not Assigned");
                else
                    Console.WriteLine("Room Number: " + guest.roomNumber);
            }
        }

        // -------------------------------------------------------------------------------
        // Case 10: Room Type Breakdown Report
        // -------------------------------------------------------------------------------

        static void RoomTypeBreakdownReport()
        {
            Console.WriteLine("\n===== ROOM TYPE BREAKDOWN REPORT =====");

            // ---------- Single ----------
            int singleCount = rooms.Count(r => r.roomType == "Single");

            Console.WriteLine("\nSingle Rooms");
            Console.WriteLine("Count: " + singleCount);

            if (singleCount > 0)
            {
                Console.WriteLine("Average Price: OMR "
                    + rooms.Where(r => r.roomType == "Single")
                           .Average(r => r.pricePerNight)
                           .ToString("F2"));
            }
            else
            {
                Console.WriteLine("Average Price: N/A");
            }

            // ---------- Double ----------
            int doubleCount = rooms.Count(r => r.roomType == "Double");

            Console.WriteLine("\nDouble Rooms");
            Console.WriteLine("Count: " + doubleCount);

            if (doubleCount > 0)
            {
                Console.WriteLine("Average Price: OMR "
                    + rooms.Where(r => r.roomType == "Double")
                           .Average(r => r.pricePerNight)
                           .ToString("F2"));
            }
            else
            {
                Console.WriteLine("Average Price: N/A");
            }

            // ---------- Suite ----------
            int suiteCount = rooms.Count(r => r.roomType == "Suite");

            Console.WriteLine("\nSuite Rooms");
            Console.WriteLine("Count: " + suiteCount);

            if (suiteCount > 0)
            {
                Console.WriteLine("Average Price: OMR "
                    + rooms.Where(r => r.roomType == "Suite")
                           .Average(r => r.pricePerNight)
                           .ToString("F2"));
            }
            else
            {
                Console.WriteLine("Average Price: N/A");
            }

            // ---------- Overall Average ----------
            Console.WriteLine("\nOverall Average Price: OMR "
                + rooms.Average(r => r.pricePerNight).ToString("F2"));
        }


        // -------------------------------------------------------------------------------
        // Case 11: Check Out Guest
        // -------------------------------------------------------------------------------
       
        static void CheckOutGuest()
        {
            Console.WriteLine("\n===== CHECK OUT GUEST =====");

            // Ask for Guest ID
            Console.Write("Enter guest ID (Example: G001): ");
            string guestId = Console.ReadLine();


            // Find guest using FirstOrDefault()
            Guest guest = guests.FirstOrDefault(g => g.guestId == guestId);


            if (guest == null)
            {
                Console.WriteLine("Error: Guest not found.");
                return;
            }


            // Check active booking
            if (guest.roomNumber == 0)
            {
                Console.WriteLine("This guest has no active booking.");
                return;
            }


            // Find room using second FirstOrDefault()
            Room room = rooms.FirstOrDefault(r =>
                r.roomNumber == guest.roomNumber);


            if (room == null)
            {
                Console.WriteLine("Error: Room not found.");
                return;
            }


            // Display final bill
            Console.WriteLine("\n========== FINAL BILL ==========");
            Console.WriteLine("Guest Name: " + guest.guestName);
            Console.WriteLine("Room Number: " + room.roomNumber);
            Console.WriteLine("Room Type: " + room.roomType);
            Console.WriteLine("Check-in Date: " + guest.checkInDate);
            Console.WriteLine("Total Nights: " + guest.totalNights);
            Console.WriteLine("Price Per Night: OMR "
                + room.pricePerNight.ToString("F2"));
            Console.WriteLine("Total Cost: OMR "
                + guest.calculateTotalCost().ToString("F2"));
            Console.WriteLine("================================");


            // Confirmation
            Console.Write("\nConfirm checkout? (Y/N): ");
            string answer = Console.ReadLine();


            if (answer.ToUpper() != "Y")
            {
                Console.WriteLine("Checkout cancelled. No changes made.");
                return;
            }


            // Free the room first
            room.isAvailable = true;


            // Remove guest
            guests.Remove(guest);


            // Summary
            Console.WriteLine("\nCheckout completed successfully.");

            Console.WriteLine("Guest removed: " + guest.guestName);

            Console.WriteLine("Room " + room.roomNumber
                + " is now available.");


            // Confirm room availability using Any()
            bool roomAvailable = rooms.Any(r =>
                r.roomNumber == room.roomNumber &&
                r.isAvailable);


            Console.WriteLine("Room availability confirmed: "
                + roomAvailable);


            Console.WriteLine("\nUpdated Counts:");
            Console.WriteLine("Total Guests: " + guests.Count());
            Console.WriteLine("Total Rooms: " + rooms.Count());
        }
    }

}