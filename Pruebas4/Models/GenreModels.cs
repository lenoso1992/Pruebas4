using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Genre { 
    public virtual int GenreId { get; set; }
    [Display(Name = "Nombre género")]
    public virtual string Name { get; set; } 
    public virtual string Description { get; set; } 
    public virtual List<Album> Albums { get; set; }
}