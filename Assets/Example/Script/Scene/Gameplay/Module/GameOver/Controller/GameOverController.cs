using System.Collections;
using System.Collections.Generic;
using Agate.MVC.Base;
using Example.Boot;
using Example.Scene.Gameplay.Message;
using UnityEngine;

namespace Example.Scene.Gameplay.GameOver
{
    public class GameOverController : ObjectController<GameOverController, GameOverView>
    {
        public override void SetView(GameOverView view)
        {
            base.SetView(view);
            view.SetCallbacks(OnRestartPressed, OnMainMenuPressed);
        }

        // Show pop up
        public void OnShowGameOver(GameOverMessage message){
            _view.Show();
        }

        // Handles when restart is pressed
        public void OnRestartPressed(){
            SceneLoader.Instance.LoadScene("Gameplay");
        }

        // Handles when main menu is pressed
        public void OnMainMenuPressed(){
            SceneLoader.Instance.LoadScene("Home");
        }
    }
}