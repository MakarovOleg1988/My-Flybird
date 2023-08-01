using System;
using System.Collections;

namespace MyFlyBird
{
    public interface INotificationWrapper
    {
        void RegisterNotification(string title, string body, DateTime fireTime, string channel);

        void ClearNotification();

        public IEnumerator RequestAuthorization();
    }
} 