using UnityEngine;

namespace MyFlyBird
{
    public class TriggerManager : MonoBehaviour, IEventAssistant
    {
        [SerializeField] private bool _isDamage;
        [SerializeField] private bool _isFruit;

        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.GetComponent<PlayerController>() == null) return;

            if (_isDamage) IEventAssistant.SendSetDamage();
            else if (_isFruit)
            {
                IEventAssistant.SendSetFruits();
                Destroy(this.gameObject);
            }
        }
    }
}
