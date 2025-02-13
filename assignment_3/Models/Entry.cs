using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace assignment_3.Models;

public class Entry
{
    public Entry(){}

    public Entry(string message, string name, string title)
    {
        Message = message;
        Name = name;
        Title = title;
    }
    public int Id { get; set; }
    
    [Required]
    [StringLength(100)]
    [DisplayName("Name")]
    public string Name { get; set; }

    [Required]
    [MinLength(5)]
    [StringLength(50)]
    [DisplayName("Title")]
    public string Title { get; set; }
    
    [Required]
    [MinLength(20)]
    [StringLength(200)]
    [DisplayName("Message")]
    public string Message { get; set; }
    
    
}