using System.Collections;
using Example.Boot;
using Agate.MVC.Base;
using Agate.MVC.Core;
using Example.Scene.Gameplay.HUDStatus;
using Example.Scene.Gameplay.Character;
using Example.Scene.Gameplay.Bed;
using Example.Scene.Gameplay.Shop;
using Example.Scene.Gameplay.GameOver;

namespace Example.Scene.Gameplay
{
    public class GameplayLauncher : SceneLauncher<GameplayLauncher, GameplayView>
    {
        public override string SceneName {  get { return "Gameplay"; } }
        private HUDStatusController _hudStatus;
        private CharacterController _character;
        private BedController _bed;
        private ShopController _shop;
        private GameOverController _gOver;

        protected override IConnector[] GetSceneConnectors()
        {
            return new IConnector[]{
                new HUDStatusConnector(),
                new CharacterConnector(),
                new ShopConnector(),
                new GameOverConnector()
            };
        }

        protected override IController[] GetSceneDependencies()
        {
            return new IController[]{
                new HUDStatusController(),
                new CharacterController(),
                new BedController(),
                new ShopController(),
                new GameOverController()
            };
        }

        protected override IEnumerator InitSceneObject()
        {
            _hudStatus.SetView(_view.HUDStatusView);
            _character.SetView(_view.characterView);
            _bed.SetView(_view.bedView);
            _shop.SetView(_view.shopView);
            _gOver.SetView(_view.gOverView);
            yield return null;
        }

        protected override IEnumerator LaunchScene()
        {
            yield return null;
        }
    }
}

