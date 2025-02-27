namespace seaplan.business.Abstract;

public interface IMessageService
{
    Task<List<Messages>> GetAll();
    Task<Messages> GetById(string id);
    Task<bool> Create(CreateMessagesVM model);
    Task<bool> Update(UpdateMessagesVM model);
    Task<bool> Delete(string id);
}