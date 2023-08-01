using System;
using UnityEngine;

namespace MyFlyBird
{
    public class NotificationManager : MonoBehaviour
    {
        private INotificationWrapper _wrapper;

        [SerializeField]
        private string[] channels = { "default" };

        private void Awake()
        {
            if (Application.platform == RuntimePlatform.IPhonePlayer)
            {
                //_wrapper = new iOSNotificationWrapper();
            }
            else 
            {
                _wrapper = new AndroidNotificationWrapper(channels);
            }

            _wrapper.ClearNotification();

            DontDestroyOnLoad(this.gameObject);

            _wrapper.RequestAuthorization();
        }

        private void OnApplicationPause(bool pause)
        {
            if (pause == true)
            {
                RegisterNotifications();
            }
            else 
            {
                _wrapper.ClearNotification();
            }
        }

        private void RegisterNotifications()
        {
            _wrapper.RegisterNotification("title", "body", DateTime.Now.AddDays(1), channels[0]);
        }
    }
}
