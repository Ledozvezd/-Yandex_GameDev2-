using UnityEngine;
using UnityEngine.UI;

namespace Pockets
{
    public class Pocket : MonoBehaviour
    {
        public int amount;

        private void Awake()
        {
            amount = PlayerPrefs.GetInt("Coins", 0);
        }

        public bool TryDiscard(int price)
        {
            if (amount > price)
                return false;
            amount -= price;
            return true;
        }
    }
}