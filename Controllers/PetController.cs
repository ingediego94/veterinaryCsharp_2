using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using practicaUno.Data;
using practicaUno.Models;

namespace practicaUno.Controllers;

public class PetController : Controller
{
    private readonly AppDbContext _context;
    
    public PetController(AppDbContext context)
    {
        _context = context;
    }
    
    // ----------------------------------------------
    
    // Read
    public async Task<IActionResult> Index()
    {
        var pets = await _context.pets_tb.ToListAsync();
        return View(pets);
    }
    
    
    //Create
    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Specie,Breed,Name,Age,Gender,AnimalCondition")]Pet pet)
    {
        if (ModelState.IsValid)
        {
            await _context.pets_tb.AddAsync(pet);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        return View(pet);
    }
    
}