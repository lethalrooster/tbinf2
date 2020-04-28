using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace tbMonoGameRotateImage
{
    class RouletteWheel
    {
        Texture2D texture;
        Vector2 position;
        Vector2 pivot;
        float rotation; 
        float scale;
        float speed;

        public RouletteWheel(Texture2D texture, Vector2 position, float scale)
        {
            this.texture = texture;
            this.position = position;
            this.scale = scale;

            rotation = 0.0f;
            pivot = new Vector2(texture.Width / 2, texture.Height / 2);

            speed = 0.01f;
        }

        public void Update()
        {
            RotateWheel();
        }

        public void RotateWheel()
        {
            rotation = rotation + speed;
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(texture, position, null, Color.White, rotation, pivot, scale, SpriteEffects.None, 0.0f);
        }
    }
}
