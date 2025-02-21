using Microsoft.EntityFrameworkCore;

namespace OTA_P01.Data;

public class ApplicationDbContext : DbContext
{
    private DbSet<Flight> flights;

    public DbSet<Flight> GetFlights()
    {
        return flights;
    }

    public void SetFlights(DbSet<Flight> value) => flights = value;
}

public class Flight
{
    public int Id { get; set; }
    public string FlightNumber { get; set; }
    public string Destination { get; set; }
}
