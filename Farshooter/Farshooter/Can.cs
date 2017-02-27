using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Factories;
using FarseerPhysics.Collision.Shapes;

namespace Farshooter
{
    class Can
    {
        //Variables
        private Body hitbox;
        private Texture2D texture;

        //Properties
        public Vector2 Position
        {
            get { return hitbox.Position; }
            set { hitbox.Position = value; }
        }
        public Body Hitbox
        {
            get { return hitbox; }
        }
        public Texture2D Texture
        {
            get { return texture; }
        }

        //Constructor
        public Can(Texture2D sprite, World world, Random rng)
        {
            texture = sprite;
            hitbox = BodyFactory.CreateRectangle(world, texture.Width, texture.Height, 1f);
            hitbox.BodyType = BodyType.Dynamic;
            hitbox.Position = new Vector2(rng.Next(0, GraphicsDevice.Viewport.Width), rng.Next(0, GraphicsDevice.Viewport.Height));
            FixtureFactory.AttachRectangle(texture.Width, texture.Height, 1, hitbox.Position, hitbox);
        }
        public Can(Texture2D sprite, World world, Vector2 position)
        {
            texture = sprite;
            hitbox = BodyFactory.CreateRectangle(world, texture.Width, texture.Height, 1f);
            hitbox.BodyType = BodyType.Dynamic;
            hitbox.Position = position;
        }
        public Can(Texture2D sprite, Body mask)
        {
            texture = sprite;
            hitbox = mask;
        }
    }
}
