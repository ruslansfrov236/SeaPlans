using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace seaplan.business.ViewsModels.About;

public class CreateAboutVM
{
    [Required] public string? Title { get; set; }

    [Required] public string? Descripition { get; set; }

    public string? BgImage { get; set; }

    [Required] [NotMapped] public IFormFile? FormFile { get; set; }
}