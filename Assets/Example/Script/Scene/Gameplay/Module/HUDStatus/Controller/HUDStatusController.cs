using System.Collections;
using System.Collections.Generic;
using Agate.MVC.Base;
using Example.Scene.Gameplay.Message;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Example.Scene.Gameplay.HUDStatus
{
    public class HUDStatusController : ObjectController<HUDStatusController,HUDStatusModel, IHUDStatusModel, HUDStatusView>
    {
        public override void SetView(HUDStatusView view)
        {
            base.SetView(view);
            view.SetCallbacks(OnClickSleep, OnClickBathroom, OnClickEat, OnClickStream, OnClickShop);
        }

        public void OnUpdateEnergy(UpdateEnergyMessage message){
            _model.SetEnergy(message.Energy);
        }

        public void OnUpdateBladder(UpdateBladderMessage message){
            _model.SetBladder(message.Bladder);
        }

        public void OnUpdateHunger(UpdateHungerMessage message){
            _model.SetHunger(message.Hunger);
        }

        public void OnUpdateMoney(UpdateMoneyMessage message){
            _model.SetMoney(Mathf.FloorToInt(message.Money));
        }

        private void OnClickSleep(){
            Publish<SleepClickedMessage>(new SleepClickedMessage());
        }
        private void OnClickBathroom(){
            Publish<BathroomClickedMessage>(new BathroomClickedMessage());
        }
        private void OnClickEat(){
            Publish<EatClickedMessage>(new EatClickedMessage());
        }
        private void OnClickStream(){
            Publish<StreamClickedMessage>(new StreamClickedMessage());
        }

        private void OnClickShop(){
            Publish<ShowShopMessage>(new ShowShopMessage());
        }
    }
}
