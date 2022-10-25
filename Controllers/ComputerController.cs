using Microsoft.AspNetCore.Mvc;
using LabManager_MVC_EF.Models;

namespace LabManager_MVC_EF.Controllers;

public class ComputerController : Controller
{
    // coloca underline "_" quando o atributo é private 
    private readonly LabManagerContext _context;

    public ComputerController(LabManagerContext context)
    {
        _context = context;
    }

    public IActionResult Index() => View(_context.Computers); // Computers é o DbSet configurado

    public IActionResult Show(int id) 
    {
        Computer? computer = _context.Computers.Find(id);

        if(computer == null)
        {
            return NotFound(); // RedirectToAction("Index"); 
        }
    
        return View(computer);
    }

    public IActionResult CreateForm()
    {
        return View();
    }

    public IActionResult Create([FromForm] Computer computer)
    {
        _context.Computers.Add(computer);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult UpdateForm(int id)
    {
        Computer computer = _context.Computers.Find(id);
        return View(computer);
    }

    public IActionResult Update([FromForm] Computer computer)
    {
        Computer? computadorEncontrado = _context.Computers.Find(computer.Id);

        if(computadorEncontrado == null)
        {
            return NotFound();
        }
        
        computadorEncontrado.Id = computer.Id;
        computadorEncontrado.Processor = computer.Processor;
        computadorEncontrado.Ram = computer.Ram;

        _context.Computers.Update(computadorEncontrado);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult Delete(int id)
    {
        Computer? computer = _context.Computers.Find(id);

        if(computer == null)
        {
            return NotFound(); // RedirectToAction("Index"); 
        }

        _context.Computers.Remove(computer);
        _context.SaveChanges();

        return RedirectToAction("Index");
    }
    
}