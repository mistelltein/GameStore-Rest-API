using System.ComponentModel.DataAnnotations;

namespace GameStore_API.Dtos;


/* public class GameDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Genre { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public DateTime ReleaseDate { get; set; }
    public string ImageUri { get; set; } = string.Empty;
} */
public record GameDto(
    int Id,
    string Name,
    string Genre,
    decimal Price,
    DateTime ReleaseDate,
    string ImageUri
);

public record CreateGameDto(
    [Required, StringLength(100)]
    string Name,

    [Required, StringLength(100)]
    string Genre,

    [Range(1, 1000)]
    decimal Price,

    DateTime ReleaseDate,

    [Url, StringLength(100)]
    string ImageUri
);

public record UpdateGameDto(
    [Required, StringLength(100)]
    string Name,

    [Required, StringLength(100)]
    string Genre,

    [Range(1, 1000)]
    decimal Price,

    DateTime ReleaseDate,

    [Url, StringLength(100)]
    string ImageUri
);