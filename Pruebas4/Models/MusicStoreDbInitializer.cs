using Pruebas4.Data.Models;

public class MusicStoreDbInitializer : System.Data.Entity.DropCreateDatabaseAlways<MusicStoreDB>
{
    protected override void Seed(MusicStoreDB context)
    {
        context.Artists.Add(new Artist { Name = "Al Di Meola" });
        context.Genres.Add(new Genre { Name = "Jazz" ,Description = "Jazz suave"});
        context.Albums.Add(new Album { Artist = new Artist { Name = "Rush" }, Genre = new Genre { Name = "Rock" ,Description = "Rock duro"}, Price = 9.99m, Title = "Caravan", FechaLanzamiento = new System.DateTime(2019,01,10)});
        context.Albums.Add(new Album { Artist = new Artist { Name = "Freedy" }, Genre = new Genre { Name = "Pop" }, Price = 9.99m, Title = "Pecara", FechaLanzamiento = new System.DateTime(2012,12,15), AlbumArtUrl = "pecara.com"});
        base.Seed(context);
    }
}