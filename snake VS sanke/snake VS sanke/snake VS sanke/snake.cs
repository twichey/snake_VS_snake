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

        public snake(Texture2D square, Keys up, Keys down, Keys left, Keys right)
        {
            this.square = square;
            this.direction = Direction.UP;

            this.up = up;
            this.down = down;
            this.left = left;
            this.right = right;

            segments = new List<Vector2>();

            // Add the head
            segments.Add(new Vector2(5, 5));

            Grow();
            Grow();
            Grow();
        }

        public void Grow()
        {
            segments.Add(segments[0]);
        }

        public void Update(GameTime gameTime)
        {
            // Make the snake move to it's new spot after 30ms
            SnakeTimer += gameTime.ElapsedGameTime.TotalMilliseconds;

            if (SnakeTimer > 150)
            {
                SnakeTimer = 0;

                // Update the head to its new location
                switch (direction)
                {
                    case Direction.UP: segments[0] = new Vector2(segments[0].X, segments[0].Y - 1); break;
                    case Direction.DOWN: segments[0] = new Vector2(segments[0].X, segments[0].Y + 1); break;
                    case Direction.LEFT: segments[0] = new Vector2(segments[0].X - 1, segments[0].Y ); break;
                    case Direction.RIGHT: segments[0] = new Vector2(segments[0].X + 1, segments[0].Y ); break;
                }

                // Now update the rest of the body
                for (int i = segments.Count - 1; i > 0; i--)
                {
                    segments[i] = segments[i - 1];
                }
            }

            KeyboardState kb = Keyboard.GetState();

            if (kb.IsKeyDown(up))
            {
                direction = Direction.UP;
            }
            else if (kb.IsKeyDown(down))
            {
                direction = Direction.DOWN;
            }
            else if (kb.IsKeyDown(left))
            {
                direction = Direction.LEFT;
            }
            else if (kb.IsKeyDown(right))
            {
                direction = Direction.RIGHT;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < segments.Count; i++)
            {
                spriteBatch.Draw(square, segments[i] * 15, Color.Black);
            }
        }

    }
}
