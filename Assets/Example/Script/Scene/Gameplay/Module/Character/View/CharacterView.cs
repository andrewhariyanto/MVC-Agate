using System.Collections;
using System.Collections.Generic;
using Agate.MVC.Base;
using UnityEngine;
using UnityEngine.Events;

namespace Example.Scene.Gameplay.Character
{
    public class CharacterView : ObjectView<ICharacterModel>
    {
        private UnityAction _onAsleep;
        private UnityAction _onStreaming;
        private UnityAction _onEating;
        private UnityAction _onBathroom;
        private UnityAction _onIdle;

        public void SetCallbacks(UnityAction onAsleep, UnityAction onStreaming, UnityAction onEating, UnityAction onBathroom, UnityAction onIdle)
        {
            _onAsleep = onAsleep;
            _onStreaming = onStreaming;
            _onEating = onEating;
            _onBathroom = onBathroom;
            _onIdle = onIdle;
        }

        protected override void InitRenderModel(ICharacterModel model)
        {
        }

        protected override void UpdateRenderModel(ICharacterModel model)
        {
        }

        private void OnTriggerStay(Collider other)
        {
            bool isAsleep = other.gameObject.CompareTag("Sleep");
            bool isStreaming = other.gameObject.CompareTag("Stream");
            bool isEating = other.gameObject.CompareTag("Eat");
            bool isBathroom = other.gameObject.CompareTag("Bathroom");

            if (isAsleep)
            {
                _onAsleep?.Invoke();
            }
            else if (isStreaming)
            {
                _onStreaming?.Invoke();
            }
            else if(isEating)
            {
                _onEating?.Invoke();
            }
            else if(isBathroom)
            {
                _onBathroom?.Invoke();
            }
        }

        private void Update(){
            _onIdle?.Invoke();
        }
    }
}