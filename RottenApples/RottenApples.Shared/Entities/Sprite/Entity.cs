using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace RottenApples.Shared.Entities.Sprite
{
    public class Entity
    {
        private Texture2D character;
        private float x;
        private float y;
        private float dx;
        private float dy;
        private float maxVelocity;
        public Entity(ContentManager content, string path, float x, float y)
        {
            Character = content.Load<Texture2D>(path);
            this.X = x;
            this.Y = y;
        }
        public float X { get => x; set => x = value; }
        public float Y { get => y; set => y = value; }
        public float Dx { get => dx; set => dx = value; }
        public float Dy { get => dy; set => dy = value; }
        public float MaxVelocity { get => maxVelocity; set => maxVelocity = value; }
        public Texture2D Character { get => character; set => character = value; }

        public void Update(GameTime gameTime)
        {
            return;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.Character, new Vector2(X, Y), Color.White);
        }
    }
}
