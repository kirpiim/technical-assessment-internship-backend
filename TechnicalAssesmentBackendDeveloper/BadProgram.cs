namespace TechnicalAssesmentBackendDeveloper;

class Booking
{
    public string? GuestName { get; private set; }
    public string? RoomNumber { get; private set; }
    public DateTime CheckInDate { get; private set; }
    public DateTime CheckOutDate { get; private set; }
    public int TotalDays { get; private set; }
    public double RatePerDay { get; private set; }
    public double Discount { get; private set; }
    public double TotalAmount { get; private set; }


    public async Task BookRoom(string name, string room, DateTime checkin, DateTime checkout, double rate, double discountRate)
    {
        GuestName = name;
        RoomNumber = room;
        CheckInDate = checkin;
        CheckOutDate = checkout;
        RatePerDay = rate;
        Discount = discountRate;

        TotalDays = (checkout - checkin).Days;
        TotalAmount = TotalDays * RatePerDay;
        TotalAmount -= TotalAmount * Discount / 100;

        await LogBookingDetailsAsync();

        Console.WriteLine($"Room Booked for {GuestName}");
        Console.WriteLine($"Room No: {RoomNumber}");
        Console.WriteLine($"Check-In: {CheckInDate}");
        Console.WriteLine($"Check-Out: {CheckOutDate}");
        Console.WriteLine($"Total Days: {TotalDays}");
        Console.WriteLine($"Amount: {TotalAmount}");
    }


    public async Task LogBookingDetailsAsync()
    {
        // Simulate writing to a log file or remote system
        await Task.Delay(1000);
        Console.WriteLine("Booking log saved.");
    }

    public void Cancel()
    {
        GuestName = null;
        RoomNumber = null;
        CheckInDate = DateTime.MinValue;
        CheckOutDate = DateTime.MinValue;
        RatePerDay = 0;
        Discount = 0;
        TotalAmount = 0;

        Console.WriteLine("Booking cancelled");
    }
}

public static class AppHost
{
    public static async Task Run(string[] args)
    {
        Booking b = new Booking();
        await b.BookRoom("Alice", "101", DateTime.Now, DateTime.Now.AddDays(3), 150.5, 10);
        b.Cancel();
    }
}
