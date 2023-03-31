using System;

namespace MyFlyBird
{
    public interface IEventAssistant
    {
        public static event Action _onSetDamage;
        public static event Action _onSetButton;
        public static event Action _onSetHoldOut;

        public static void SendSetDamage()
        {
            _onSetDamage?.Invoke();
        }

        public static void SendHoldOut()
        {
            _onSetHoldOut?.Invoke();
        }

        public static void SendSetButton()
        {
            _onSetButton?.Invoke();
        }
    }
}
