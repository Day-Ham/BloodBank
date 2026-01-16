using Microsoft.EntityFrameworkCore;
using BloodBank.Models;

namespace BloodBank;

public class BloodBankContext : DbContext
{
    public BloodBankContext(DbContextOptions<BloodBankContext> options) : base(options) { }

    public DbSet<Donor> Donors { get; set; }
    public DbSet<DonationRecord> Donations { get; set; }
}