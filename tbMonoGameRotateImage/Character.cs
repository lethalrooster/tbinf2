using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace tbMonoGameRotateImage
{
    class Character
    {
        Texture2D texture;
        Vector2 position;
        Rectangle current_part_in_image;
        int x, y;

        public Character(Texture2D texture, Vector2 position)
        {
            this.texture = texture;
            this.position = position;

            x = y = 0;

            current_part_in_image = new Rectangle(x, y, 30, 38);
        }

        public void Update(GameTime gameTime)
        {
            if (gameTime.TotalGameTime.Ticks % 60 == 0)
                x = x + 30;
            current_part_in_image = new Rectangle(x, y, 30, 38);
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(texture, position, current_part_in_image, Color.White);
        }
    }
}
