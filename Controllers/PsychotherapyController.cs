// Controllers/PsychotherapyController.cs
using Microsoft.AspNetCore.Mvc;
using PsychologyApp.Models;



public class PsychotherapyController : Controller
{
    private readonly PsychotherapyService _service;

    public PsychotherapyController(PsychotherapyService service)
    {
        _service = service;
    }

    public async Task<IActionResult> Index()
    {
        var types = await _service.GetAllPsychotherapyTypesAsync();
        return View(types);
    }

    public async Task<IActionResult> Details(int id)
    {
        var type = await _service.GetPsychotherapyTypeByIdAsync(id);
        if (type == null)
        {
            return NotFound();
        }
        return View(type);
    }
}
