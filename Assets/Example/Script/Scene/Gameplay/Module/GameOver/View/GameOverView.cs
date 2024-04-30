using System.Collections;
using System.Collections.Generic;
using Agate.MVC.Base;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Example.Scene.Gameplay.GameOver
{
    public class GameOverView : BaseView{
        [SerializeField]
        private GameObject _gameOverPopUp;
        [SerializeField]
        private Button _restartButton;
        [SerializeField]
        private Button _mainMenuButton;

        public void SetCallbacks(UnityAction onRestartPressed, UnityAction onMainMenuPressed){
            _restartButton.onClick.RemoveAllListeners();
            _mainMenuButton.onClick.RemoveAllListeners();
            _restartButton.onClick.AddListener(onRestartPressed);
            _mainMenuButton.onClick.AddListener(onMainMenuPressed);
        }

        // Shows the pop up
        public void Show(){
            _gameOverPopUp.SetActive(true);
        }
    }
}
