using System.Collections;
using System.Collections.Generic;
using Agate.MVC.Base;
using Example.Scene.Gameplay.Message;
using UnityEngine;

namespace Example.Scene.Gameplay.Shop
{
    public class ShopConnector : BaseConnector
    {
        private ShopController _shopController;
        protected override void Connect()
        {
            Subscribe<ShowShopMessage>(_shopController.OnShowShop);
        }

        protected override void Disconnect()
        {
            Unsubscribe<ShowShopMessage>(_shopController.OnShowShop);
        }
    }
}