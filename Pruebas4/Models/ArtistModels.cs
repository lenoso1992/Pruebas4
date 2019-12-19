using System.ComponentModel.DataAnnotations;

public class Artist { 
    public virtual int ArtistId { get; set; }
    [Display(Name = "Nombre Artista")]
    public virtual string Name { get; set; } 
}