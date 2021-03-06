﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

using FarseerPhysics.Dynamics;
using FarseerPhysics.Factories;
using FarseerPhysics.DebugViews;
namespace WindowsGame3
{
    class CircleObject : GameObject
    {
        KeyboardState previousKeyboardState;
        KeyboardState aKeyboardState;

        public override void LoadContent(FarseerPhysics.Dynamics.World aWorld, Microsoft.Xna.Framework.Graphics.Texture2D aTexture)
        {
            theBody = BodyFactory.CreateCircle(aWorld, (float)ConvertUnits.ToSimUnits((aTexture.Width / 2) - 2), 1.0f);
            objectTexture = aTexture;
            theBody.BodyType = BodyType.Dynamic;
            theBody.Restitution = 0.5f;
        }
        public override void Update()
        {
            aKeyboardState = Keyboard.GetState();
            if ((aKeyboardState != previousKeyboardState) && aKeyboardState.IsKeyDown(Keys.Space))
            {
                MouseState ms = Mouse.GetState();
                Vector2 pos = theBody.Position;
                theBody.LinearVelocity = new Vector2((ms.X - ConvertUnits.ToDisplayUnits(pos.X))/35.0f, (ms.Y - ConvertUnits.ToDisplayUnits(pos.Y)) / 35.0f);
                Console.WriteLine(ms.X + " x " + ms.Y);
                Console.WriteLine(ConvertUnits.ToDisplayUnits(pos.X) + " x " + ConvertUnits.ToDisplayUnits(pos.Y));
            }
            else if ((aKeyboardState != previousKeyboardState) && aKeyboardState.IsKeyDown(Keys.Enter))
            {
                theBody.Position = new Vector2(0, 0.5f);
                theBody.LinearVelocity = Vector2.Zero;
            }
            previousKeyboardState = aKeyboardState;
        }


        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch aSpriteBatch, GraphicsDeviceManager aGraphicsDevice)
        {
            aSpriteBatch.Draw(objectTexture, ConvertUnits.ToDisplayUnits(theBody.Position), null, Color.White, theBody.Rotation, new Vector2(objectTexture.Width / 2.0f, objectTexture.Height / 2.0f), 1f, SpriteEffects.None, 0f);
        }

        void moveCircle()
        {

        }
    }
}
