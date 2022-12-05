using System.ComponentModel.DataAnnotations.Schema;

namespace yatb_sharp.Database.Models;

[Table("countries")]
public class Country
{
    public Guid Uid { get; init; }
    public required string Name { get; set; }
}