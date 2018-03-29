using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1{

    class Player{

        private Rectangle bb;
        private Color color;
        private Texture2D texture;
        private PlayerIndex playerIndex;
        private Bullet bullet;

        public Player(int x, int y, GraphicsDevice graphics, PlayerIndex pi){
            bb = new Rectangle(x, y, 100, 100);
            color = Color.White;
            texture = new Texture2D(graphics, 1, 1);
            texture.SetData(new Color[] { Color.White });
            playerIndex = pi;
            bullet = new Bullet(x+49, y+49, graphics, pi, this);
        }

        public int GetX()
        {
            return bb.X;
        }

        public int GetY()
        {
            return bb.Y;
        }

        public int RightStickDir(GamePadState controller)
        {
            if (controller.ThumbSticks.Right.X < 0)
            {
                return -1;
            }
            if (controller.ThumbSticks.Right.X > 0)
            {
                return 1;
            }
            if (controller.ThumbSticks.Right.Y > 0)
            {
                return -2;
            }
            if (controller.ThumbSticks.Right.Y < 0)
            {
                return 2;
            }
            return 0;
        }

        public void Update()
        {
            GamePadState controller = GamePad.GetState(playerIndex);
            if (controller.ThumbSticks.Left.X < 0)
            {
                bb.X -= 5;
            }
            if (controller.ThumbSticks.Left.X > 0)
            {
                bb.X +=5;
            }
            if (controller.ThumbSticks.Left.Y > 0)
            {
                bb.Y -= 5;
            }
            if (controller.ThumbSticks.Left.Y < 0)
            {
                bb.Y += 5;
            }
            bullet.Update();
        }

        public void Draw(SpriteBatch sb){
            sb.Draw(texture, bb, color);
            bullet.Draw(sb);
        }
    }
}
