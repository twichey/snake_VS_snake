using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace snake_VS_sanke
{
    enum Direction { UP, DOWN, LEFT, RIGHT }

    class snake
    {
        Keys up;
        Keys down;
        Keys left;
        Keys right;

        Texture2D square;

        List<Vector2> segments;
        Direction direction;

        double SnakeTimer = 0f;

        public snake(Texture2D square)
        {
            this.square = square;
            this.direction = Direction.UP;

            up = Keys.Up;
            down = Keys.Down;
            left = Keys.Left;
            right = Keys.Right;

            segments = new List<Vector2>();

            // Add the head
            segments.Add(new Vector2(5, 5));
        }


        public void Update(GameTime gameTime)
        {
            // Make the snake move to it's new spot after 30ms
            SnakeTimer += gameTime.ElapsedGameTime.TotalMilliseconds;

            if (SnakeTimer > 30)
            {
                SnakeTimer = 0;

                // Update the head to its new location
                switch (direction)
                {
                    case Direction.UP: segments[0] = new Vector2(segments[0].X, segments[0].Y - 1); break;
                    case Direction.DOWN: break;
                    case Direction.LEFT: break;
                    case Direction.RIGHT: break;
                }

                // Now update the rest of the body
                
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < segments.Count; i++)
            {
                spriteBatch.Draw(square, segments[i] * 15, Color.White);
            }
        }

    }
}
