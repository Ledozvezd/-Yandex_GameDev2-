using Unity;
using UnityEngine;
using CoinRend;
using CoinModel;
using System.Net.Sockets;

namespace CompositeRoot
{
    public class CompositeRoot : MonoBehaviour
    {
        private bool affordable;
        private CoinModels _coinModel;
        private CoinRndr _render;

        public CoinModels CoinModels => _coinModel;
        private void Awake()
        {
            _coinModel = new CoinModels();
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag.Contains("Coin"))
                OnPickupCoin();
        }

        public void OnPickupCoin()
        {
            _coinModel.amount++;
            _render.CoinRender();
        }

        public bool TrDiscard(int price)
        {
            affordable = _coinModel.TryDiscard(price);
            if (affordable == false)
                return affordable;
            _render.CoinRender();
            return affordable;
        }

        
    }
}
