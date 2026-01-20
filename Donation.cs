namespace BloodBank.Models;

public class DonationRecord
{
    public int Id { get; set; }
    public DateTime DonationDate { get; set; }
    public int Milliliters { get; set; }
    public int DonorId { get; set; }
}