using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Agate.MVC.Base;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace Example.Scene.Gameplay.Character
{
    public class CharacterModel : BaseModel, ICharacterModel
    {
        public float Energy {get; private set;} = 1;

        public float Bladder {get; private set;} = 1;

        public float Hunger {get; private set;} = 1;

        public float Money {get; private set;} = 0;

        public Vector3 Position {get; private set;} = new Vector3(0,1,0);

        public bool IsWalking {get; private set;} = false;

        public Vector3 Destination {get; private set;} = Vector3.zero;

        public void SetEnergy(float energy)
        {
            Energy = energy;
            SetDataAsDirty();
        }

        public void SetBladder(float bladder)
        {
            Bladder = bladder;
            SetDataAsDirty();
        }

        public void SetHunger(float hunger)
        {
            Hunger = hunger;
            SetDataAsDirty();
        }

        public void SetMoney(float money)
        {
            Money = money;
            SetDataAsDirty();
        }
    
        public void SetPosition(Vector3 pos)
        {
            Position = pos;
            SetDataAsDirty();
        }

        public void SetIsWalking(bool isWalking)
        {
            IsWalking = isWalking;
            SetDataAsDirty();
        }

        public void SetDestination(Vector3 destination){
            Destination = destination;
            SetDataAsDirty();
        }
    }
}
