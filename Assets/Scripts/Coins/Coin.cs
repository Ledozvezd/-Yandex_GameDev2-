using UnityEngine;
using UnityEngine.UI;
using Pockets;

namespace Coin
{
    public class Coin : MonoBehaviour
    {
        [SerializeField] private Text _render;
        [SerializeField] private Animator _animator;

        private Pocket _pocket;
        private bool affordable;

        public Pocket Pocket => _pocket;

        private void Awake()
        {
            _pocket = new Pocket();
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag.Contains("Coin"))
                OnPickupCoin();
        }

        public void OnPickupCoin()
        {
            _pocket.amount++;
            CoinRender();
        }

        public bool TrDiscard(int price)
        {
            affordable = _pocket.TryDiscard(price);
            if (affordable == false)
                return affordable;
            CoinRender();
            return affordable;
        }

        private void CoinRender()
        {
            _render.text = $"Coins: {_pocket.amount}";
            _animator.SetTrigger("OnPickupCoin");
            PlayerPrefs.SetInt("Coins", _pocket.amount);
        }
    }
}