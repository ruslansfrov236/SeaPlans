using seaplan.business.ViewsModel.Auth;

namespace seaplan.business.Abstract;

public interface IVerificationCodeService
{
    Task SaveVerificationCodeAsync(string userId, string code);
    Task VerificationCodeAsync(CreateVerifaction model);
    Task Remove(string id);

    Task<bool> EmailConfiremed(string userId);
    string GenerateVerificationCode(int length = 6);
}