using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace RottenApples.Shared.Entities.Animation
{
    public class Frame
    {
        public Rectangle SourceRectangle { get; set; }
        public TimeSpan FrameTime { get; set; }
    }
}
