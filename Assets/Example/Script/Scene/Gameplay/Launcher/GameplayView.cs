using System.Collections;
using Example.Boot;
using Agate.MVC.Base;
using Agate.MVC.Core;
using UnityEngine;
using Example.Scene.Gameplay.HUDStatus;
using Example.Scene.Gameplay.Character;

namespace Example.Scene.Gameplay
{
    public class GameplayView : BaseSceneView
    {
        [SerializeField]
        public HUDStatusView HUDStatusView;
        [SerializeField]
        public CharacterView characterView;
    }
}
