using System.Collections;
using System.Collections.Generic;
using Agate.MVC.Base;
using Example.Scene.Gameplay.Message;
using UnityEngine;

namespace Example.Scene.Gameplay.Character
{
    public class CharacterConnector : BaseConnector
    {
        private CharacterController _character;
        protected override void Connect()
        {
            Subscribe<SleepClickedMessage>(_character.OnSleepClicked);
            Subscribe<StreamClickedMessage>(_character.OnStreamClicked);
            Subscribe<EatClickedMessage>(_character.OnEatClicked);
            Subscribe<BathroomClickedMessage>(_character.OnBathroomClicked);
        }

        protected override void Disconnect()
        {
            Unsubscribe<SleepClickedMessage>(_character.OnSleepClicked);
            Unsubscribe<StreamClickedMessage>(_character.OnStreamClicked);
            Unsubscribe<EatClickedMessage>(_character.OnEatClicked);
            Unsubscribe<BathroomClickedMessage>(_character.OnBathroomClicked);
        }
    }
}