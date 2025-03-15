using Microsoft.AspNetCore.Mvc;
using seaplan.business.Abstract;
using seaplan.business.ViewsModels.Messages;

namespace seaplan.webapi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MessagesController : ControllerBase
{
    public readonly IMessageService _messageService;

    public MessagesController(IMessageService messageService)
    {
        _messageService = messageService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var messages = await _messageService.GetAll();

        return Ok(messages);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Index(string id)
    {
        var messages = await _messageService.GetById(id);
        return Ok(messages);
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] UpdateMessagesVM model)
    {
        var messages = await _messageService.Update(model);
        return Ok(messages);
    }
}