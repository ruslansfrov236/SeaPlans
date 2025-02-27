using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace task.Webui.ViewsModels.Slider;

public class UpdateSliderVM
{
    public string Id { get; set; }

    public string? Title { get; set; }


    public string? Descriptions { get; set; }

    public string? Photo { get; set; }

    [NotMapped] public IFormFile FormFile { get; set; }
}