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

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Donor>>> GetDonors()
    {
        return await _db.Donors.ToListAsync();
    }
    [HttpPost]
    public async Task<ActionResult<Donor>> CreateDonor(Donor donor)
    {
        _db.Donors.Add(donor);
        await _db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetDonors), new { id = donor.Id }, donor);
    }
}