using Root.UI.Scripts;
using UnityEngine;

namespace Root.Player.Scripts
{
    public class PlayerBodySystem : MonoBehaviour,ICanTakeDamage
    {
        public void ApplyDamage()
        {
            UIEvents.InvokeOnPlayerCollided();
        }
    }
}