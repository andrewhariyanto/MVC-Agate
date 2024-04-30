using System.Collections;
using System.Collections.Generic;
using Agate.MVC.Base;
using Example.Scene.Gameplay.Message;
using UnityEngine;

namespace Example.Scene.Gameplay.Shop
{
    public class ShopController : ObjectController<ShopController, ShopView>{
        public override void SetView(ShopView view)
        {
            base.SetView(view);
            view.SetCallbacks();
        }

        // Handles shop pop up event
        public void OnShowShop(ShowShopMessage message){
            _view.Show();
        }

    }
}
