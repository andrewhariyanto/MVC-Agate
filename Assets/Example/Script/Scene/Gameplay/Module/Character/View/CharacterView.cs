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
        private UnityAction _onMovePosition;

        public void SetCallbacks(UnityAction onAsleep, UnityAction onStreaming, UnityAction onEating, UnityAction onBathroom, UnityAction onIdle, UnityAction onMovePosition)
        {
            _onAsleep = onAsleep;
            _onStreaming = onStreaming;
            _onEating = onEating;
            _onBathroom = onBathroom;
            _onIdle = onIdle;
            _onMovePosition = onMovePosition;
        }

        protected override void InitRenderModel(ICharacterModel model)
        {
            transform.position = model.Position;
        }

        protected override void UpdateRenderModel(ICharacterModel model)
        {
            transform.position = model.Position;
        }

        // When player is in bathroom or bed, hide the mesh renderer
        private void OnTriggerEnter(Collider other){
            bool enteredBed = other.gameObject.CompareTag("Sleep");
            bool leaveRoom = other.gameObject.CompareTag("Bathroom");

            if(enteredBed){
                this.gameObject.GetComponent<MeshRenderer>().enabled = false;
            }
            else if(leaveRoom){
                this.gameObject.GetComponent<MeshRenderer>().enabled = false;
            }
        }

        // When player enters room and gets out of bed, show the mesh renderer
        private void OnTriggerExit(Collider other){
            bool enteredBed = other.gameObject.CompareTag("Sleep");
            bool leaveRoom = other.gameObject.CompareTag("Bathroom");

            if(enteredBed){
                this.gameObject.GetComponent<MeshRenderer>().enabled = true;
            }
            else if(leaveRoom){
                this.gameObject.GetComponent<MeshRenderer>().enabled = true;
            }
        }

    // When player is in any trigger situations
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
            _onMovePosition?.Invoke();
        }
    }
}