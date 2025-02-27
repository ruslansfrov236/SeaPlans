using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace seaplan.business.ViewsModels.About;

public class UpdateAboutVM
{
    public string id { get; set; }

    [Required] public string? Title { get; set; }

    [Required] public string? Descripition { get; set; }

    public string? BgImage { get; set; }

    [NotMapped] public IFormFile? FormFile { get; set; }
}