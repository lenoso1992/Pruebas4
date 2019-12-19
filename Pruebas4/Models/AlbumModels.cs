using System;
using System.ComponentModel.DataAnnotations;

public class Album
{
    public virtual int AlbumId { get; set; }
    public virtual int GenreId { get; set; }
    public virtual int ArtistId { get; set; }
    [Display(Name = "Título")]
    public virtual string Title { get; set; }
    [Display(Name = "Precio")]
    public virtual decimal Price { get; set; }
    [Display(Name = "URL Album arte")]
    public virtual string AlbumArtUrl { get; set; }
    [Display(Name = "Género")]
    public virtual Genre Genre { get; set; }
    [Display(Name = "Artista")]
    public virtual Artist Artist { get; set; }
    [Display(Name = "Fecha lanzamiento")]
    public virtual DateTime? FechaLanzamiento { get; set; }
}