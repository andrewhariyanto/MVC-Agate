using System.Collections;
using System.Collections.Generic;
using Agate.MVC.Base;
using Example.Scene.Gameplay.Message;
using UnityEngine;

namespace Example.Scene.Gameplay.HUDStatus
{
    public class HUDStatusConnector : BaseConnector
    {
        private HUDStatusController _hud;
        protected override void Connect(){
            Subscribe<UpdateEnergyMessage>(_hud.OnUpdateEnergy);
            Subscribe<UpdateBladderMessage>(_hud.OnUpdateBladder);
            Subscribe<UpdateHungerMessage>(_hud.OnUpdateHunger);
        }

        protected override void Disconnect(){
            Unsubscribe<UpdateEnergyMessage>(_hud.OnUpdateEnergy);
            Unsubscribe<UpdateBladderMessage>(_hud.OnUpdateBladder);
            Unsubscribe<UpdateHungerMessage>(_hud.OnUpdateHunger);
        }
    }
}


