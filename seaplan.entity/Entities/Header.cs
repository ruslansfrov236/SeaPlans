using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;
using seaplan.entity.Entities.Common;

namespace seaplan.entity.Entities;

public class Header : BaseEntity
{
    public string? Title { get; set; }
    public string? Description { get; set; }

    public int ContentValue { get; set; }
    public string? Photo { get; set; }

    [NotMapped] public IFormFile? FileCollection { get; set; }
}