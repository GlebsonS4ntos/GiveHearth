namespace GiveHearth.Interfaces
{
    public interface IServiceEmail
    {
        Task SendEmailAsync(string email, DateTime dateRegister);
    }
}
