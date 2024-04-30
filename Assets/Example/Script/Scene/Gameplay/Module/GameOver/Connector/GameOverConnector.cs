using System.Collections;
using System.Collections.Generic;
using Agate.MVC.Base;
using Example.Scene.Gameplay.Message;
using UnityEngine;

namespace Example.Scene.Gameplay.GameOver
{
    public class GameOverConnector : BaseConnector
    {
        private GameOverController _gameOverController;
        protected override void Connect()
        {
            Subscribe<GameOverMessage>(_gameOverController.OnShowGameOver);
        }

        protected override void Disconnect()
        {
            Unsubscribe<GameOverMessage>(_gameOverController.OnShowGameOver);
        }
    }
}