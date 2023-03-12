using CoinModel;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace CoinRend
{
    public class CoinRndr : MonoBehaviour
    {
        [Inject] private CoinModels _coin;

        [Inject(Id = "CoinsText")] private Text _render;
        [SerializeField] private Animator _animator;

        private bool affordable;

        public void CoinRender()
        {
            _render.text = $"Coins: {_coin.amount}";
            _animator.SetTrigger("OnPickupCoin");
            PlayerPrefs.SetInt("Coins", _coin.amount);
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag.Contains("Coin"))
                OnPickupCoin();
        }
        public void OnPickupCoin()
        {
            _coin.OnPickupCoin();
            CoinRender();
        }
        public bool TrDiscard(int price)
        {
            affordable = _coin.TryDiscard(price);
            if (affordable == false)
                return affordable;
            CoinRender();
            return affordable;
        }
    }
}