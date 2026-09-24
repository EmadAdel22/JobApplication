namespace jobApplication.Application.Services
{
    public class NotificationService
    {
        public void SendApplicationNotification(int applicationId)
        {
            Console.WriteLine(
                $"Application {applicationId} submitted successfully.");
        }
    }
}