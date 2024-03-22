using System.ComponentModel.DataAnnotations;

namespace GameStore_API.Entities;

public class Game
{
    public int Id { get; set; }

    [Required, StringLength(100)]
    public required string Name { get; set; } //required --> has to specify 

    [Required, StringLength(100)]
    public required string Genre { get; set; }

    [Range(1, 1000)]
    public decimal Price { get; set; }
    public DateTime ReleaseDate { get; set; }

    [Url, StringLength(100)]
    public required string ImageUri { get; set; }
}