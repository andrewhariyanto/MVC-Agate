using System.Collections;
using Example.Boot;
using Agate.MVC.Base;
using Agate.MVC.Core;
using Example.Scene.Gameplay.HUDStatus;
using Example.Scene.Gameplay.Character;

namespace Example.Scene.Gameplay
{
    public class GameplayLauncher : SceneLauncher<GameplayLauncher, GameplayView>
    {
        public override string SceneName {  get { return "Gameplay"; } }
        private HUDStatusController _hudStatus;
        private CharacterController _character;

        protected override IConnector[] GetSceneConnectors()
        {
            return new IConnector[]{
                new HUDStatusConnector()
            };
        }

        protected override IController[] GetSceneDependencies()
        {
            return new IController[]{
                new HUDStatusController(),
                new CharacterController()
            };
        }

        protected override IEnumerator InitSceneObject()
        {
            _hudStatus.SetView(_view.HUDStatusView);
            _character.SetView(_view.characterView);
            yield return null;
        }

        protected override IEnumerator LaunchScene()
        {
            yield return null;
        }
    }
}

