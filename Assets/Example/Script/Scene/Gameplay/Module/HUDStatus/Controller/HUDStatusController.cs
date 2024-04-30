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
            view.SetCallbacks(OnClickSleep, OnClickBathroom, OnClickEat, OnClickStream);
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

        private void OnClickSleep(){
            Debug.Log("Testing");
        }
        private void OnClickBathroom(){}
        private void OnClickEat(){}
        private void OnClickStream(){}
    }
}
