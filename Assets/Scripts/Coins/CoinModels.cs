using UnityEngine;
using UnityEngine.UI;

namespace CoinModel
{
    public class CoinModels
    {
        public int amount { private set; get; }

        public void OnPickupCoin() => amount++;
        public bool TryDiscard(int price)
        {
            if (amount > price)
                return false;
            amount -= price;
            return true;
        }
        private void Awake()
        {
            amount = PlayerPrefs.GetInt("Coins", 0);
        }
    }
}