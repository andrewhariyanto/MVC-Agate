using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Agate.MVC.Base;
using Example.Scene.Gameplay.Message;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace Example.Scene.Gameplay.Character
{
    public class CharacterController : ObjectController<CharacterController, CharacterModel, ICharacterModel, CharacterView>
    {
        private Vector3 _bedLocation = new Vector3(2.69f,1,2.84f);
        private Vector3 _deskLocation = new Vector3(-2.51f,1f,2.93f);
        private Vector3 _doorLocation = new Vector3(-0.12f,1f,4.51f);
        private Vector3 _tableLocation = new Vector3(0,1,-1);
        
        public override void SetView(CharacterView view)
        {
            base.SetView(view);
            view.SetCallbacks(OnAsleep, OnStreaming, OnEating, OnBathroom, OnIdle, OnMovePosition);
        }

        // Triggers event for moving to the bed
        public void OnSleepClicked(SleepClickedMessage message){
            _model.SetIsWalking(true);
            _model.SetDestination(_bedLocation);
        }

        // Triggers event for moving to the computer
        public void OnStreamClicked(StreamClickedMessage message){
            _model.SetIsWalking(true);
            _model.SetDestination(_deskLocation);
        }

        // Triggers event for moving to the door
        public void OnBathroomClicked(BathroomClickedMessage message){
            _model.SetIsWalking(true);
            _model.SetDestination(_doorLocation);
        }

        // Triggers event for moving to the dining table
        public void OnEatClicked(EatClickedMessage message){
            _model.SetIsWalking(true);
            _model.SetDestination(_tableLocation);
        }

        // Handles the movement towards destination
        private void OnMovePosition(){
            if(!_model.IsWalking){
                return;
            }

            if ((_model.Destination - _model.Position).magnitude > 0.05f){
                Vector3 tempPos = _model.Position + (_model.Destination - _model.Position).normalized * Time.deltaTime;
                _model.SetPosition(tempPos);
            }
            else{
                _model.SetIsWalking(false);
            }
        }

        // Player is asleep and regenerating energy
        public void OnAsleep()
        {
            float tempEnergy = _model.Energy + (0.05f * Time.deltaTime);
            if (tempEnergy > 1)
                _model.SetEnergy(1);
            else
                _model.SetEnergy(tempEnergy);
            Publish<UpdateEnergyMessage>(new UpdateEnergyMessage(_model.Energy));
        }

        // Player is outside the door in the bathroom to regenerate bladder
        public void OnBathroom()
        {
            float tempBladder = _model.Bladder + (0.1f * Time.deltaTime);
            if (tempBladder > 1)
                _model.SetBladder(1);
            else
                _model.SetBladder(tempBladder);
            Publish<UpdateBladderMessage>(new UpdateBladderMessage(_model.Bladder));
        }

        // PLayer is at the screen to stream and earn money
        public void OnStreaming()
        {
            float tempEnergy = _model.Energy - (0.05f * Time.deltaTime);
            _model.SetEnergy(tempEnergy);

            // Money earned decreases with energy
            float tempMoney = _model.Money + (5 * tempEnergy * Time.deltaTime);
            _model.SetMoney(tempMoney);
            Publish<UpdateEnergyMessage>(new UpdateEnergyMessage(_model.Energy));
            Publish<UpdateMoneyMessage>(new UpdateMoneyMessage(_model.Money));
        }

        // Player is at the table and eating
        public void OnEating()
        {
            float tempHunger = _model.Hunger + (0.1f * Time.deltaTime);
            if(tempHunger > 1)
                _model.SetHunger(1);
            else
                _model.SetHunger(tempHunger);
            Publish<UpdateHungerMessage>(new UpdateHungerMessage(_model.Hunger));
        }

        // Base player stats decreasing over time
        public void OnIdle()
        {
            float tempEnergy = _model.Energy - (0.01f * Time.deltaTime);
            float tempBladder = _model.Bladder - (0.01f * Time.deltaTime);
            float tempHunger = _model.Hunger - (0.01f * Time.deltaTime);

            if(tempEnergy < 0 || tempBladder < 0 || tempHunger < 0){
                _model.SetEnergy(0);
                _model.SetBladder(0);
                _model.SetHunger(0);

                Publish<GameOverMessage>(new GameOverMessage());
            }

            _model.SetEnergy(tempEnergy);
            _model.SetBladder(tempBladder);
            _model.SetHunger(tempHunger);
            Publish<UpdateEnergyMessage>(new UpdateEnergyMessage(_model.Energy));
            Publish<UpdateBladderMessage>(new UpdateBladderMessage(_model.Bladder));
            Publish<UpdateHungerMessage>(new UpdateHungerMessage(_model.Hunger));
        }
    }
}
