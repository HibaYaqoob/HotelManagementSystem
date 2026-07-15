namespace Task8
{
    internal class Program
    {
        // --------------------------------------------------------------
                                  // Room Class:
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

            // Method to display room details
            public void displayRoom()
            {
                Console.WriteLine("Room Number: " + roomNumber);
                Console.WriteLine("Room Type: " + roomType);
                Console.WriteLine("Price Per Night: " + pricePerNight);
                Console.WriteLine("Available: " + isAvailable);
            }
        }

        // --------------------------------------------------------------
        // Guest Class:
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


            // Method to display guest details
            public void displayGuest()
            {
                Console.WriteLine("Guest ID: " + guestId);
                Console.WriteLine("Guest Name: " + guestName);
                Console.WriteLine("Room Number: " + roomNumber);
                Console.WriteLine("Check In Date: " + checkInDate);
                Console.WriteLine("Total Nights: " + totalNights);
            }


            // Method to calculate total cost
            public double calculateTotalCost()
            {
                return totalNights * pricePerNight;
            }
        }





        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
