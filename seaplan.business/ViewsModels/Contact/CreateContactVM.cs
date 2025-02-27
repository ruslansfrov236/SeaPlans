using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace seaplan.business.ViewsModels.Contact;

public class CreateContactVM
{
    public string Title { get; set; }


    public string Description { get; set; }
    public string Photo { get; set; }

    [NotMapped] public IFormFile FormFile { get; set; }
}