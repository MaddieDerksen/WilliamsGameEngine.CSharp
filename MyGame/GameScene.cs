using GameEngine;
using SFML.Graphics;
using SFML.System;
using System;
using System.Diagnostics.Metrics;
using System.Security.Cryptography.X509Certificates;

namespace MyGame
{
    class GameScene : Scene
    {
        private int _lives = 3;
        private int _score;
       
        public GameScene()
        {
           

            Ship ship = new Ship();
            
            AddGameObject(ship);

            MeteorSpawner meteorSpawner = new MeteorSpawner();
            AddGameObject(meteorSpawner);

            Score score = new Score(new Vector2f(10.0f, 10.0f));
            AddGameObject(score);

            Lives lives = new Lives(new Vector2f(10.0f, 50.0f));
            AddGameObject(lives);
            
        }
        // Get the current score
        public int GetScore()
        {
            return _score;
        }
        // Increase the score
        public void IncreaseScore()
        {
            ++_score;

        }
        // Get the number of lives
        public int GetLives()
        {
            return _lives;
        }
        // Decrease the number of lives
        public void DecreaseLives()
        {
            --_lives;
            if (_lives == 0)
            {
                GameOverScene gameOverScene = new GameOverScene(_score);
                Game.SetScene(gameOverScene);
            }
        }

    }
}
