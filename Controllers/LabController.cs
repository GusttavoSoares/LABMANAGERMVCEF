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

        if (lab == null)
        {
            return NotFound(); // RedirectToAction("Index"); 
        }

        return View(lab);
    }

    public IActionResult CreateForm()
    {
        return View();
    }

    [HttpPost]
    public IActionResult CreateForm([FromForm] Lab lab)
    {

        if (!ModelState.IsValid)
        {
            return View(lab);
        }

        _context.Labs.Add(lab);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult Delete(int id)
    {
        Lab? lab = _context.Labs.Find(id);

        if (lab == null)
        {
            return NotFound(); // RedirectToAction("Index"); 
        }

        _context.Labs.Remove(lab);
        _context.SaveChanges();

        return RedirectToAction("Index");
    }

    public IActionResult UpdateForm(int id)
    {
        Lab? lab = _context.Labs.Find(id);
        return View(lab);
    }


    [HttpPost]
    public IActionResult UpdateForm([FromForm] Lab lab)
    {

        if (!ModelState.IsValid)
        {
            return View(lab);
        }

        Lab? labEncontrado = _context.Labs.Find(lab.Id);

        if (labEncontrado == null)
        {
            return NotFound();
        }

        labEncontrado.Id = lab.Id;
        labEncontrado.Number = lab.Number;
        labEncontrado.Name = lab.Name;
        labEncontrado.Block = lab.Block;

        _context.Labs.Update(labEncontrado);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
}
