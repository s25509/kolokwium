using Kolos_Code_First.Context;
using Kolos_Code_First.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kolos_Code_First.Controllers;

[Route("/api/[controller]")]
[ApiController]
public class ClientController : ControllerBase
{
    private readonly AppDbContext _context;
    public ClientController(AppDbContext context)
    {
        _context = context;
    }
    
    [HttpGet("{idClient:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetClientWithAllDataAsync(int idClient)
    {
        var Client = await _context.Clients
            .Where(c => c.IdClient == idClient)
            .Include(c => c.IdSaleNavigation)
            .ThenInclude(sa => sa.IdSubscription)
            .Include(c => c.Prescriptions)
            .ThenInclude(cr => pr.PrescriptionMedicaments)
            .ThenInclude(cm => pm.IdMedicamentNavigation)
            .Select(c => new ClientDto
            {
                FirstName = c.FirstName,
                LastName = c.LastName,
                Email = c.Email,
                Prescriptions = c.Prescriptions
                    .OrderByDescending(cr => pr.DueDate)
                    .Select(cr => new SubscriptionDto
                    {
                        IdPrescription = pr.IdPrescription,
                        Date = pr.Date,
                        DueDate = pr.DueDate,
                        Doctor = new DoctorDto
                        {
                            IdDoctor = pr.IdDoctorNavigation.IdDoctor,
                            FirstName = pr.IdDoctorNavigation.FirstName,
                            LastName = pr.IdDoctorNavigation.LastName,
                            Email = pr.IdDoctorNavigation.Email
                        },
                        Medicaments = pr.PrescriptionMedicaments.Select(cm => new MedicamentDto
                            {
                                IdMedicament = pm.IdMedicamentNavigation.IdMedicament,
                                Name = pm.IdMedicamentNavigation.Name,
                                Description = pm.IdMedicamentNavigation.Description,
                                Type = pm.IdMedicamentNavigation.Type
                            }
                        ).ToList()
                    }
                ).ToList()
            })
            .FirstOrDefaultAsync();

        if (Client is null) return NotFound($"Client with ID: {idClient} not found");

        return Ok(Client);
    }
}