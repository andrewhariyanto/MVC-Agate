using System.Collections;
using Example.Boot;
using Agate.MVC.Base;
using Agate.MVC.Core;
using UnityEngine;
using Example.Scene.Gameplay.HUDStatus;
using Example.Scene.Gameplay.Character;
using Example.Scene.Gameplay.Bed;
using Example.Scene.Gameplay.Shop;
using Example.Scene.Gameplay.GameOver;

namespace Example.Scene.Gameplay
{
    public class GameplayView : BaseSceneView
    {
        [SerializeField]
        public HUDStatusView HUDStatusView;
        [SerializeField]
        public CharacterView characterView;
        [SerializeField]
        public BedView bedView;
        [SerializeField]
        public ShopView shopView;
        [SerializeField]
        public GameOverView gOverView;
    }
}
