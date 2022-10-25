using Microsoft.AspNetCore.Mvc;
using LabManager_MVC_EF.Models;

namespace LabManager_MVC_EF.Controllers;

public class LabController : Controller
{
    private readonly LabManagerContext _context;

    public LabController(LabManagerContext context)
    {
        _context = context;
    }

    public IActionResult Index() => View(_context.Labs); 

    public IActionResult Show(int id) 
    {
        Lab? lab = _context.Labs.Find(id);
        
        if(lab == null)
        {
            return NotFound(); // RedirectToAction("Index"); 
        }
    
        return View(lab);
    }

    public IActionResult CreateForm()
    {
        return View();
    }

    public IActionResult Create([FromForm] Lab lab)
    {
        _context.Labs.Add(lab);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult Delete(int id)
    {
        Lab? lab = _context.Labs.Find(id);

        if(lab == null)
        {
            return NotFound(); // RedirectToAction("Index"); 
        }

        _context.Labs.Remove(lab);
        _context.SaveChanges();

        return RedirectToAction("Index");
    }

    public IActionResult UpdateForm()
    {
        
        return View();
    }

    public IActionResult Update([FromForm] Lab lab)
    {
        Lab? labEncontrado = _context.Labs.Find(lab.Id);

        if(labEncontrado == null)
        {
            return NotFound();
        }
        
        labEncontrado.Number = lab.Number;
        labEncontrado.Name = lab.Name;
        labEncontrado.Block = lab.Block;

        _context.Labs.Update(labEncontrado);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
}