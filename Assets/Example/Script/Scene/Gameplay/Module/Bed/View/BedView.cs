using System.Collections;
using System.Collections.Generic;
using Agate.MVC.Base;
using UnityEngine;

namespace Example.Scene.Gameplay.Bed
{
    // This class does not need a controller, but the API doesn't tell me how to register a sub view only
    public class BedView : BaseView
    {
        [SerializeField]
        private Transform _sleepingPlayer;

        // Show the sleeping player when the player reaches the bed
        private void OnTriggerEnter(Collider other){
            if(other.gameObject.CompareTag("Player")){
                _sleepingPlayer.gameObject.GetComponent<MeshRenderer>().enabled = true;
            }
        }

        // Hide the sleeping player when the player reaches the bed
        private void OnTriggerExit(Collider other){
            if(other.gameObject.CompareTag("Player")){
                _sleepingPlayer.gameObject.GetComponent<MeshRenderer>().enabled = false;
            }
        }
    }
}
