using System.Reflection.Metadata.Ecma335;
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
    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("BranchCode,BranchName,Address,Phone")]Branch branch)
    {
        if (ModelState.IsValid)
        {
            try
            {
                var branchCodeExists = await _context.branches_tb.AnyAsync(p => p.BranchCode == branch.BranchCode);

                if (branchCodeExists)
                {
                    TempData["ErrorMessage"] =
                        $"The code for this branch ({branch.BranchCode}) already exists. Try another one.";
                    return RedirectToAction(nameof(Index));
                }
                
                await _context.branches_tb.AddAsync(branch);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = $"Register created successfuly.";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"It has presented an error. Error: {ex.Message}";
                return RedirectToAction(nameof(Index));
            }
        }

        return View(branch);
    }

    
    // Delete
    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        var branchToDelete = await _context.branches_tb.FindAsync(id);
        
        if (branchToDelete != null)
        {
            try
            {
                _context.branches_tb.Remove(branchToDelete);
                TempData["SuccessMessage"] = $"Register delete successfully";
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error deleting. Error:{ex.Message}";
                return RedirectToAction(nameof(Index));
            }
        }

        return RedirectToAction(nameof(Index));
    }
    
    
    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var branch = await _context.branches_tb.FindAsync(id);
        
        if (branch == null)
            return NotFound();
            
        return View(branch);
    }

    
    // Edit
    [HttpPost, ValidateAntiForgeryToken, ActionName("Edit")]
    public async Task<IActionResult> EditPost(int id)
    {
        var branchToUpdate = await _context.branches_tb.FindAsync(id);

        if (branchToUpdate == null) return NotFound();
        
        try
        {

            if (await TryUpdateModelAsync<Branch>(
                branchToUpdate,
                "",
                b => b.BranchCode,
                b => b.BranchName,
                b => b.Address,
                b => b.Phone
                )
                )
            {
                try
                {
                    TempData["SuccessMessage"] = $"Editing successfully.";
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    TempData["ErrorMessage"] = $"Error editing. Error: {ex.Message}";
                    return RedirectToAction(nameof(Index));
                    
                }
            }
        }
        catch (Exception e)
        {
            
        }

        return View(branchToUpdate);
    }
    
    
    
}
