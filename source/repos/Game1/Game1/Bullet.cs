using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    class Bullet
    {
        private Rectangle bb;
        private Color color;
        private Texture2D texture;
        private PlayerIndex playerIndex;
        private Player user;
        private int velocityX, velocityY;

        public Bullet(int x, int y, GraphicsDevice graphics, PlayerIndex pi, Player p)
        {
            bb = new Rectangle(x, y, 5, 5);
            color = Color.Black;
            texture = new Texture2D(graphics, 1, 1);
            texture.SetData(new Color[] { Color.Black });
            playerIndex = pi;
            user = p;
        }

        public void Update()
        {
            GamePadState controller = GamePad.GetState(playerIndex);
            if (user.RightStickDir(controller) == 0)
            {
                velocityX = 0;
                velocityY = 0;
            }
            if (user.RightStickDir(controller) == 1)
            {
                velocityX = 10;
            }
            if (user.RightStickDir(controller) == -1)
            {
                velocityX = -10;
            }
            if (user.RightStickDir(controller) == 2)
            {
                velocityY = 10;
            }
            if (user.RightStickDir(controller) == -2)
            {
                velocityY = -10;
            }
            if (controller.Triggers.Right == 1)
            {
                bb.X += velocityX;
                bb.Y += velocityY;
            }
            else
            {
                bb.X = user.GetX() + 49;
                bb.Y = user.GetY() + 49;
            }
            if (bb.X < 0 || bb.X > 1000 || bb.Y < 0 || bb.Y > 600)
            {
                bb.X = user.GetX() + 49;
                bb.Y = user.GetY() + 49;
            }
            
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(texture, bb, color);
        }
    }
}
