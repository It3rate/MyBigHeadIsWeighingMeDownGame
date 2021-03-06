﻿using System;
using System.Collections.Generic;
using DDW.Display;
using DDW.V2D;
using V2DRuntime.Attributes;
using V2DRuntime.V2D;
using DDW.Input;
using Microsoft.Xna.Framework.Input;

using Microsoft.Xna.Framework.Graphics;
using HeadGame.Components;
using Microsoft.Xna.Framework;
using Box2D.XNA;
using V2DRuntime.Enums;
using V2DRuntime.Particles;
using HeadGame.Particles;

namespace HeadGame.Screens
{
    [V2DScreenAttribute(backgroundColor = 0x000000, gravityX = 0, gravityY = 50, debugDraw = true)]
    public class Level0Screen : BaseScreen
    {
        [SpriteAttribute(depthGroup = 1000)]
        public Laser[] laser;

        public Level0Screen(V2DContent v2dContent) : base(v2dContent)
        {
        }
        public Level0Screen(SymbolImport si) : base(si)
        {
            SymbolImport = si;
        }

        public override void Initialize()
        {
            base.Initialize();
            maxScore = 3000;
            bkgScreenIndex = 0;
            maxPoints = 10;
        }
        public override void Activate()
        {
            base.Activate();
            ClearBoundsBody(EdgeName.Top);
        }
        protected override void OnAddToStageComplete()
        {
            base.OnAddToStageComplete();
        }

        protected override void UpdatePlayer(int playerIndex, GameTime gameTime)
        {
            if (headPlayer[playerIndex].TargetContactIndex > -1)
            {
                headPlayer[playerIndex].Points += gameTime.ElapsedGameTime.Milliseconds;
                
                int pts = headPlayer[playerIndex].Points;
                Game1.Hud.scoreMeter[playerIndex].SetScoreByRatio((float)(pts / (float)maxScore));
            }
        }

        private float angle = 0;
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            angle += .008f;
            laser[0].Angle = angle;
        }

        public override void Draw(SpriteBatch batch)
        {
            base.Draw(batch);
        }
    }
}
