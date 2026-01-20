using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BloodBank.Models;
using BloodBank;

namespace BloodBank.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DonorsController : ControllerBase
{
    private readonly BloodBankContext _db;
    public DonorsController(BloodBankContext db) => _db = db;
    //Donor Related Endpoints
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Donor>>> GetDonors()
    {
        return await _db.Donors.Include(d => d.DonationHistory).ToListAsync();
    }
    [HttpPost]
    public async Task<ActionResult<Donor>> CreateDonor(Donor donor)
    {
        _db.Donors.Add(donor);
        await _db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetDonors), new { id = donor.Id }, donor);
    }
    //Donation Related Endpoints
    [HttpPost("/api/donors/donations")]
    public async Task<ActionResult<DonationRecord>> PostDonation(DonationRecord donation)
    {
        var donor = await _db.Donors.Include(d => d.DonationHistory)
                                    .FirstOrDefaultAsync(d => d.Id == donation.DonorId);
        if (donor == null) return NotFound("Donor not found.");
        if (!donor.IsEligible) return BadRequest("Donor is not eligible to donate at this time.");

        _db.Donations.Add(donation);
        await _db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetDonors), new { id = donation.Id }, donation);
    }
    [HttpGet("donations")]
    public async Task<ActionResult<IEnumerable<DonationRecord>>> GetAllDonations()
    {
        return await _db.Donations.ToListAsync();
    }
}