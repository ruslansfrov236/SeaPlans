namespace seaplan.business.Concrete;

public class MessageService : IMessageService
{
    private readonly IEmailService _emailService;
    private readonly IMessagesReadRepository _messagesReadRepository;
    private readonly IMessagesWriteRepository _messagesWriteRepository;

    public MessageService(IMessagesReadRepository messagesReadRepository,
        IMessagesWriteRepository messagesWriteRepository, IEmailService emailService)
    {
        _messagesReadRepository = messagesReadRepository;
        _messagesWriteRepository = messagesWriteRepository;
        _emailService = emailService;
    }

    public async Task<List<Messages>> GetAll()
    {
        return await _messagesReadRepository.GetAll().ToListAsync();
    }

    public async Task<Messages> GetById(string id)
    {
        if (!Guid.TryParse(id, out var guid))
            throw new BadRequestException("Invalid ID format. Please provide a valid GUID.");

        var messages = await _messagesReadRepository.GetById(guid.ToString()) ?? throw new NotFoundException();

        return messages;
    }

    public async Task<bool> Create(CreateMessagesVM model)
    {
        var messages = new Messages
        {
            FullName = model.FullName,
            Email = model.Email,
            Comment = model.Comment
        };
        await _messagesWriteRepository.AddAsync(messages);
        await _messagesWriteRepository.SaveAsync();
        return true;
    }

    public async Task<bool> Update(UpdateMessagesVM model)
    {
        if (!Guid.TryParse(model.id, out var guid))
            throw new BadRequestException("Invalid ID format. Please provide a valid GUID.");

        var existingMessage = await _messagesReadRepository.GetById(guid.ToString())
                              ?? throw new NotFoundException();


        var responseMessage = new Messages
        {
            FullName = existingMessage.FullName,
            Email = existingMessage.Email,
            Comment = model.Comment
        };


        await _messagesWriteRepository.AddAsync(responseMessage);
        await _messagesWriteRepository.SaveAsync();


        _emailService.SendResponse(existingMessage.Email, model.Comment);

        return true;
    }


    public Task<bool> Delete(string id)
    {
        throw new NotImplementedException();
    }
}