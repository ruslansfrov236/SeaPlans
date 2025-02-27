using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;
using seaplan.entity.Entities.Common;

namespace seaplan.entity.Entities;

public class About : BaseEntity
{
    public string Title { get; set; }
    public string Descripition { get; set; }

    public string BgImage { get; set; }

    [NotMapped] public IFormFile FormFile { get; set; }
}