namespace Singleton
{
    public sealed class NotificationSingletonExample
    {
        private List<string> NotificationsList { get; }   
        private NotificationSingletonExample() 
        {
            NotificationsList = new List<string>();
        }

        private static NotificationSingletonExample _notification;

        public static NotificationSingletonExample GetNotification()
        {
            if(_notification == null) 
                _notification = new NotificationSingletonExample();
            return _notification;
        }

        public void AddNotification(string notification)
        {
            this.NotificationsList.Add(notification);
        }

        public List<string> GetNotificationsList()
        {
            return this.NotificationsList;
        }

        public string GetNotifications()
        {
            return string.Join(",", this.NotificationsList);
        }
    }

    public class ExecuteSingleton
    {
        public void Main()
        {
            var notifications = NotificationSingletonExample.GetNotification();
            Console.WriteLine("First Notification list - Write a notification:");
            var newNotification = Console.ReadLine();
            notifications.AddNotification(newNotification ?? "");
            var notification2 = NotificationSingletonExample.GetNotification();
            Console.WriteLine("Second Notification list - Write a other notificat0ion:");
            newNotification = Console.ReadLine();
            notification2.AddNotification(newNotification ?? "");
            if(notification2.GetNotificationsList().Count > 1)
            {
                Console.WriteLine("Wow! The both notification list is a same thing! See that:");
                Console.WriteLine(notifications.GetNotifications());
            }
            else
            {
                Console.WriteLine("Ops! Then create other notification list, something is wrong.");
            }
        }
    }
}