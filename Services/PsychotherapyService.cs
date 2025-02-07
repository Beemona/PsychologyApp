// Services/PsychotherapyService.cs
using Microsoft.EntityFrameworkCore;
using PsychologyApp.Controllers;
using PsychologyApp.Models;

public class PsychotherapyService
{
    private readonly PsychologyAppContext _context;

    public PsychotherapyService(PsychologyAppContext context)
    {
        _context = context;
    }

    public async Task<List<PsychotherapyType>> GetAllPsychotherapyTypesAsync()
    {
        return await _context.PsychotherapyTypes
            .Include(pt => pt.MentalDisorders)
            .ToListAsync();
    }

    public async Task<PsychotherapyType> GetPsychotherapyTypeByIdAsync(int id)
    {
        return await _context.PsychotherapyTypes
            .Include(pt => pt.MentalDisorders)
            .FirstOrDefaultAsync(pt => pt.Id == id);
    }
}
