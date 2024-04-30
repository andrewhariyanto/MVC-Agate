using System.Collections;
using System.Collections.Generic;
using Agate.MVC.Base;
using Agate.MVC.Core;
using UnityEngine;

namespace Example.Scene.Gameplay.HUDStatus
{
    public class HUDStatusModel : BaseModel, IHUDStatusModel
    {
        public float Energy {get; private set; } = 1;

        public float Bladder {get; private set; } = 1;

        public float Hunger {get; private set; } = 1;

        public int Money {get; private set; }

        public void SetEnergy(float energy){
            Energy = energy;
            SetDataAsDirty();
        }

        public void SetBladder(float bladder){
            Bladder = bladder;
            SetDataAsDirty();
        }

        public void SetHunger(float hunger){
            Hunger = hunger;
            SetDataAsDirty();
        }

        public void SetMoney(int money){
            Money = money;
            SetDataAsDirty();
        }
    }
}
