using CoinModel;
using UnityEngine;
using UnityEngine.UI;

namespace CoinRend
{
    public class CoinRndr : MonoBehaviour
    {
        [SerializeField] private Text _render;
        [SerializeField] private Animator _animator;

        private CoinModels _coin;

        public CoinModels CoinModels => _coin;
        public void CoinRender()
        {
            _render.text = $"Coins: {_coin.amount}";
            _animator.SetTrigger("OnPickupCoin");
            PlayerPrefs.SetInt("Coins", _coin.amount);
        }
    }
}