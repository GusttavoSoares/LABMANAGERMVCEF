using System.ComponentModel.DataAnnotations;

namespace LabManager_MVC_EF.Models;

public class Lab 
{
    [Range(1, 999)]
    [Required]
    public int Id { get; set; } 

    [Required]
    [Range(1, 9999)]
    public int Number { get; set; } 

    [Required]
    [StringLength(20)]
    public string Name { get; set; }

    [Required]
    [StringLength(20)]
    public string Block { get; set; }


    public Lab(int id, int number, string name, string block)
    {
        Id = id;
        Number = number;
        Name = name;
        Block = block;
    }

    public Lab(){ }
}
