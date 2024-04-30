using System.Collections;
using System.Collections.Generic;
using Agate.MVC.Base;
using UnityEngine;

namespace Example.Scene.Gameplay.Character
{
    public interface ICharacterModel : IBaseModel
    {
        public float Energy {get ;}
        public float Bladder {get ;}
        public float Hunger { get;}
        public int Money { get;}
        public Vector3 Position {get;}
        public bool IsWalking {get;}
    }
}

