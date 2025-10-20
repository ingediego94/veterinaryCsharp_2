using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using practicaUno.Data;
using practicaUno.Models;

namespace practicaUno.Controllers;

public class BranchController : Controller
{
    private readonly AppDbContext _context;

    public BranchController(AppDbContext context)
    {
        _context = context;
    }
    
    // -----------------------------------------
    
    //Read
    public async Task<IActionResult> Index()
    {
        var branches = await _context.branches_tb.ToListAsync();
        return View(branches);
    }
    
    
    // Create 
    public async Task<IActionResult> Create([Bind("BranchName,Address,Phone")]Branch branch)
    {
        if (ModelState.IsValid)
        {
            await _context.branches_tb.AddAsync(branch);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        return View(branch);
    }

}
