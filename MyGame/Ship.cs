using GameEngine;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Diagnostics.Metrics;

namespace MyGame
{
    class Ship : GameObject
    {
        private const float Speed = 0.3f;
        private const int FireDelay = 200;
        private int _fireTimer;

        private readonly Sprite _sprite = new Sprite();
        // Creates our ship.
        public Ship()
        {
            _sprite.Texture = Game.GetTexture("Resources/ship.png");
            _sprite.Position = new Vector2f(100, 100);
        }
        // functions overridden from GameObject:
        public override void Draw()
        {
            Game.RenderWindow.Draw(_sprite);
        }
        public override void Update(Time elapsed)
        {
            Vector2f pos = _sprite.Position; // had to add something
            float x = pos.X;
            float y = pos.Y;

            int msElapsed = elapsed.AsMilliseconds();
            if (Keyboard.IsKeyPressed(Keyboard.Key.Up)) { y -= Speed * msElapsed; }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Down)) { y += Speed * msElapsed; }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Left)) { x -= Speed * msElapsed; }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Right)) { x += Speed * msElapsed; }
            if (x > 800) { x = -100; }
            if (x < -100) { x = 800; }
            if (y > 600) { y = -100; }
            if (y < -100) { y = 600; }

            _sprite.Position = new Vector2f(x, y);

            if (_fireTimer > 0) { _fireTimer -= msElapsed; }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Space) && _fireTimer <= 0)
            {
                    _fireTimer = FireDelay;
                    FloatRect bounds = _sprite.GetGlobalBounds();
                    float laserX = x + bounds.Width;
                    float laserY = y + bounds.Height / 2.0f;
                  
                    Laser laser = new Laser(new Vector2f(laserX, laserY));
                    Game.CurrentScene.AddGameObject(laser);

                //}
                _fireTimer = FireDelay;
                float laserX2 = x + bounds.Width -10;
                float laserY2 = y + bounds.Height / 2.0f + 50;
                Laser laser2 = new Laser(new Vector2f(laserX2, laserY2));
                Game.CurrentScene.AddGameObject(laser2);

                _fireTimer = FireDelay;
                float laserX3 = x + bounds.Width -10;
                float laserY3 = y + bounds.Height / 2.0f - 50;
                Laser laser3 = new Laser(new Vector2f(laserX3, laserY3));
                Game.CurrentScene.AddGameObject(laser3);
            }
        }
    }
}
