using System.Collections;
using System.Collections.Generic;
using Agate.MVC.Base;
using UnityEngine;

namespace Example.Scene.Gameplay.HUDStatus
{
    public interface IHUDStatusModel : IBaseModel
    {
        public float Energy {get ;}
        public float Bladder {get ;}
        public float Hunger { get;}
        public int Money { get;}
    }
}