using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace seaplan.business.ViewsModels.Header;

public class UpdateHeaderVM
{
    public string Id { get; set; }

    public string? Title { get; set; }
 
    public string? Description { get; set; }
    
    public int  ContentValue { get; set; }
    public string  Photo { get; set; }
  
    [NotMapped]
    public IFormFile FileCollection { get; set; }
}