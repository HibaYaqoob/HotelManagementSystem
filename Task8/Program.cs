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

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
