namespace bloodbank;

public class Donor
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string BloodType { get; set; }
    public List<DonationRecord> DonationHistory { get; set; } = new();

    // The logic now looks at the very last item in the list
    public bool IsEligible 
    {
        get 
        {
            if (!DonationHistory.Any()) return true; // Never donated? They are eligible!
            var lastDonation = DonationHistory.Max(d => d.DonationDate);
            return (DateTime.Now - lastDonation).TotalDays >= 56;
        }
    }
}

public class DonationRecord
{
    public int ID { get; set; }
    public DateTime DonationDate { get; set; }
    public string LocationOfDonation { get; set; }
    public int DonorId { get; set; }


}