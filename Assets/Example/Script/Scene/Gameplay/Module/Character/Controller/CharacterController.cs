using System.Collections;
using System.Collections.Generic;
using Agate.MVC.Base;
using Example.Scene.Gameplay.Message;
using UnityEngine;

namespace Example.Scene.Gameplay.Character
{
    public class CharacterController : ObjectController<CharacterController, CharacterModel, ICharacterModel, CharacterView>
    {
        
        public override void SetView(CharacterView view)
        {
            base.SetView(view);
            view.SetCallbacks(OnAsleep, OnStreaming, OnEating, OnBathroom, OnIdle);
        }

        public void OnAsleep()
        {
            float tempEnergy = _model.Energy + (0.05f * Time.deltaTime);
            if (tempEnergy > 1)
                _model.SetEnergy(1);
            else
                _model.SetEnergy(tempEnergy);
            Publish<UpdateEnergyMessage>(new UpdateEnergyMessage(_model.Energy));
        }

        public void OnBathroom()
        {
            float tempBladder = _model.Bladder + (0.3f * Time.deltaTime);
            if (tempBladder > 1)
                _model.SetBladder(1);
            else
                _model.SetBladder(tempBladder);
            Publish<UpdateBladderMessage>(new UpdateBladderMessage(_model.Bladder));
        }

        public void OnStreaming()
        {
            float tempEnergy = _model.Energy - (0.1f * Time.deltaTime);
            if (tempEnergy > 1)
                _model.SetEnergy(1);
            else
                _model.SetEnergy(tempEnergy);
            Publish<UpdateEnergyMessage>(new UpdateEnergyMessage(_model.Energy));
        }

        public void OnEating()
        {
            float tempHunger = _model.Hunger + (0.3f * Time.deltaTime);
            if(tempHunger > 1)
                _model.SetEnergy(1);
            else
                _model.SetHunger(tempHunger);
            Publish<UpdateHungerMessage>(new UpdateHungerMessage(_model.Hunger));
        }

        public void OnIdle()
        {
            float tempEnergy = _model.Energy - (0.025f * Time.deltaTime);
            float tempBladder = _model.Bladder - (0.01f * Time.deltaTime);
            float tempHunger = _model.Hunger - (0.01f * Time.deltaTime);

            if (tempEnergy < 0)
                _model.SetEnergy(0);
            else
                _model.SetEnergy(tempEnergy);
            
            if (tempBladder < 0)
                _model.SetBladder(0);
            else
                _model.SetBladder(tempBladder);

            if (tempHunger < 0)
                _model.SetHunger(0);
            else
                _model.SetHunger(tempHunger);
            Publish<UpdateEnergyMessage>(new UpdateEnergyMessage(_model.Energy));
            Publish<UpdateBladderMessage>(new UpdateBladderMessage(_model.Bladder));
            Publish<UpdateHungerMessage>(new UpdateHungerMessage(_model.Hunger));
        }
    }
}
