using UnityEngine;

namespace MyFlyBird
{
    public class TriggerManager : MonoBehaviour, IEventAssistant
    {
        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.GetComponent<PlayerController>())
            {
                IEventAssistant.SendSetDamage();
            }
        }
    }
}
