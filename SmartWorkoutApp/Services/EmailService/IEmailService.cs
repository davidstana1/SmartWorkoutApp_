using DataAccess.Entities;

namespace SmartWorkoutApp.Services.EmailService;

public interface IEmailService
{
    Task SendInvitationAsync(string toEmail, string invitationLink, Trainer trainer, string email);
}