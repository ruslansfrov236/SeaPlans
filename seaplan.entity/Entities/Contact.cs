using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;
using seaplan.entity.Entities.Common;

namespace seaplan.entity.Entities;

public class Contact : BaseEntity
{
    public string Title { get; set; }

    public string Description { get; set; }
    public string Photo { get; set; }

    [NotMapped] public IFormFile FormFile { get; set; }
}