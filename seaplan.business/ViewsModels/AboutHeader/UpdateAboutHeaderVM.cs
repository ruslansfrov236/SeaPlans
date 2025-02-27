using System.ComponentModel.DataAnnotations;

namespace seaplan.business.ViewsModels.AboutHeader;

public class UpdateAboutHeaderVM
{
    public string id { get; set; }

    [Required] public string? Title { get; set; }

    [Required]
    [MinLength(2)]
    [MaxLength(100)]
    public string? Description { get; set; }

    [Required] public string? ButtonValues { get; set; }
}