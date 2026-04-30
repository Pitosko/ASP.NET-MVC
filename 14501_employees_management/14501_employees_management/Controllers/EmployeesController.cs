using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeesManagement.Data;
using EmployeesManagement.Models;
namespace EmployeesManagement.Controllers;
public class EmployeesController : Controller {
    private readonly ApplicationDbContext _c;
    public EmployeesController(ApplicationDbContext c){_c=c;}
    public async Task<IActionResult> Index() => View(await _c.Employees.ToListAsync());
    public async Task<IActionResult> Details(int? id){if(id==null)return NotFound();var e=await _c.Employees.FirstOrDefaultAsync(m=>m.Id==id);return e==null?NotFound():View(e);}
    public IActionResult Create() => View();
    [HttpPost,ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Employee employee){
        employee.CreatedById="Macro Code"; employee.CreatedOn=DateTime.Now;
        employee.ModifiedById="Macro Code"; employee.ModifiedOn=DateTime.Now;
        if(ModelState.IsValid){_c.Add(employee);await _c.SaveChangesAsync();return RedirectToAction(nameof(Index));}
        return View(employee);
    }
    public async Task<IActionResult> Edit(int? id){if(id==null)return NotFound();var e=await _c.Employees.FindAsync(id);return e==null?NotFound():View(e);}
    [HttpPost,ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Employee employee){
        if(id!=employee.Id)return NotFound();
        if(ModelState.IsValid){try{employee.ModifiedById="Macro Code";employee.ModifiedOn=DateTime.Now;_c.Update(employee);await _c.SaveChangesAsync();}catch(DbUpdateConcurrencyException){if(!_c.Employees.Any(e=>e.Id==id))return NotFound();throw;}return RedirectToAction(nameof(Index));}
        return View(employee);
    }
    public async Task<IActionResult> Delete(int? id){if(id==null)return NotFound();var e=await _c.Employees.FirstOrDefaultAsync(m=>m.Id==id);return e==null?NotFound():View(e);}
    [HttpPost,ActionName("Delete"),ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id){var e=await _c.Employees.FindAsync(id);if(e!=null)_c.Employees.Remove(e);await _c.SaveChangesAsync();return RedirectToAction(nameof(Index));}
}
