using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace seaplan.business.ViewsModels.Contact;

public class UpdateContactVM
{
    public string id { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }
    public string? Photo { get; set; }

    [NotMapped] public IFormFile? FormFile { get; set; }
}