using System.Collections;
using System.Collections.Generic;
using Agate.MVC.Base;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Example.Scene.Gameplay.HUDStatus
{
    public class HUDStatusView : ObjectView<IHUDStatusModel>
    {
        [SerializeField]
        private Slider _energyBar;
        [SerializeField]
        private Slider _bladderBar;
        [SerializeField]
        private Slider _hungerBar;
        [SerializeField]
        private Text _moneyText;

        [SerializeField]
        private Button _sleepButton;
        [SerializeField]
        private Button _bathroomButton;
        [SerializeField]
        private Button _eatButton;
        [SerializeField]
        private Button _streamButton;
        [SerializeField]
        private Button _shopButton;

        public void SetCallbacks(UnityAction onSleep, UnityAction onBathroom, UnityAction onEat, UnityAction onStream, UnityAction onShop)
        {
            _sleepButton.onClick.RemoveAllListeners();
            _bathroomButton.onClick.RemoveAllListeners();
            _eatButton.onClick.RemoveAllListeners();
            _streamButton.onClick.RemoveAllListeners();
            _shopButton.onClick.RemoveAllListeners();

            _sleepButton.onClick.AddListener(onSleep);
            _bathroomButton.onClick.AddListener(onBathroom);
            _eatButton.onClick.AddListener(onEat);
            _streamButton.onClick.AddListener(onStream);
            _shopButton.onClick.AddListener(onShop);
        }

        protected override void InitRenderModel(IHUDStatusModel model)
        {
            _energyBar.value = model.Energy;
            _bladderBar.value = model.Bladder;
            _hungerBar.value = model.Hunger;
            _moneyText.text = $"${model.Money}";
        }

        protected override void UpdateRenderModel(IHUDStatusModel model)
        {
            _energyBar.value = model.Energy;
            _bladderBar.value = model.Bladder;
            _hungerBar.value = model.Hunger;
            _moneyText.text = $"${model.Money}";
        }
    }
}