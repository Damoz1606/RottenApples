using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RottenApples.Shared.Entities.Animation
{
    public class Animator
    {
        private List<Frame> frames;
        private TimeSpan time;
        public Animator()
        {
            frames = new List<Frame>();
        }
        public TimeSpan Duration
        {
            get
            {
                double totalSeconds = 0;
                foreach(var frame in frames)
                {
                    totalSeconds += frame.FrameTime.TotalSeconds;
                }
                return TimeSpan.FromSeconds(totalSeconds);
            }
        }
        public Rectangle CurrentFrame
        {
            get
            {
                Frame currentFrame = null;
                TimeSpan accumulatedTime = new TimeSpan();
                foreach (var frame in frames)
                {
                    if ((accumulatedTime + frame.FrameTime) >= time)
                    {
                        currentFrame = frame;
                        break;
                    } else
                    {
                        accumulatedTime += frame.FrameTime;
                    }
                }
                if (currentFrame == null)
                {
                    currentFrame = frames.LastOrDefault();
                }
                if (currentFrame != null)
                {
                    return currentFrame.SourceRectangle;
                } else
                {
                    return Rectangle.Empty;
                }
            }
        }
        public void AddFrame(int numberFrames, int column, int row, int width, int height, TimeSpan time)
        {
            for (int index = 0; index < numberFrames; index++)
            {
                Frame newFrame = new Frame
                {
                    SourceRectangle = new Rectangle(column + index, row, width, height),
                    FrameTime = time
                };
                frames.Add(newFrame);
            }
        }
        public void Update(GameTime gameTime)
        {
            double seconds = this.time.TotalSeconds + gameTime.ElapsedGameTime.TotalSeconds;
            double remainder = seconds % Duration.TotalSeconds;
            this.time = TimeSpan.FromSeconds(remainder);
        }
    }
}
