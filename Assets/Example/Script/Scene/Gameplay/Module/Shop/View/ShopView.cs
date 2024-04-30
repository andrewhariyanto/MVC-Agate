using System.Collections;
using System.Collections.Generic;
using Agate.MVC.Base;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Example.Scene.Gameplay.Shop
{
    public class ShopView : BaseView{

        [SerializeField]
        private Button _backButton;
        [SerializeField]
        private GameObject _shopScreen;

        // Shows shop pop up
        public void Show(){
            _shopScreen.SetActive(true);
        }

        public void SetCallbacks(){
            _backButton.onClick.RemoveAllListeners();
            _backButton.onClick.AddListener(OnBackPressed);
        }

        // Handles when back is pressed
        private void OnBackPressed(){
            _shopScreen.SetActive(false);
        }
    }
}
