using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeesManagement.Data;
using EmployeesManagement.Models;
namespace EmployeesManagement.Controllers;
public class InstrumentsController : Controller {
    private readonly ApplicationDbContext _c;
    public InstrumentsController(ApplicationDbContext c){_c=c;}
    public async Task<IActionResult> Index() => View(await _c.Instruments.ToListAsync());
    public async Task<IActionResult> Details(int? id){if(id==null)return NotFound();var e=await _c.Instruments.FirstOrDefaultAsync(m=>m.Id==id);return e==null?NotFound():View(e);}
    public IActionResult Create() => View();
    [HttpPost,ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Instrument instrument){
        instrument.CreatedById="Macro Code"; instrument.CreatedOn=DateTime.Now;
        instrument.ModifiedById="Macro Code"; instrument.ModifiedOn=DateTime.Now;
        if(ModelState.IsValid){_c.Add(instrument);await _c.SaveChangesAsync();return RedirectToAction(nameof(Index));}
        return View(instrument);
    }
    public async Task<IActionResult> Edit(int? id){if(id==null)return NotFound();var e=await _c.Instruments.FindAsync(id);return e==null?NotFound():View(e);}
    [HttpPost,ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Instrument instrument){
        if(id!=instrument.Id)return NotFound();
        if(ModelState.IsValid){try{instrument.ModifiedById="Macro Code";instrument.ModifiedOn=DateTime.Now;_c.Update(instrument);await _c.SaveChangesAsync();}catch(DbUpdateConcurrencyException){if(!_c.Instruments.Any(e=>e.Id==id))return NotFound();throw;}return RedirectToAction(nameof(Index));}
        return View(instrument);
    }
    public async Task<IActionResult> Delete(int? id){if(id==null)return NotFound();var e=await _c.Instruments.FirstOrDefaultAsync(m=>m.Id==id);return e==null?NotFound():View(e);}
    [HttpPost,ActionName("Delete"),ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id){var e=await _c.Instruments.FindAsync(id);if(e!=null)_c.Instruments.Remove(e);await _c.SaveChangesAsync();return RedirectToAction(nameof(Index));}
}