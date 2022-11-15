using System.ComponentModel.DataAnnotations;

namespace LabManager_MVC_EF.Models;

public class Computer
{
    [Range(1, 999)]
    public int Id { get; set; }

    [Required]
    [StringLength(5)]
    public string Ram { get; set; }

    [Required]
    [StringLength(20)]
    public string Processor { get; set; }

    public Computer() { }

    public Computer(int id, string ram, string processor)
    {
        Id = id;
        Ram = ram;
        Processor = processor;
    }
}
