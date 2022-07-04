namespace BowlingBall
{
    public sealed class StanderdFrame : Frame
    {
        public override int GetScore() => (int)(Role1 + Role2);

        public override Frame Roll(int pins)
        {
            base.Roll(pins);

            // Standerd frame can become Strike or Spare frame based on ball rolling (state design pattern)
            if (Role1 == TEN)
                return new StrikeFrame(Role1.Value);
            else if (Role1 + (Role2 ?? 0) == TEN)
                return new SpareFrame(Role1.Value, Role2.Value);
            else
                return this; // this is Standerd frame by default i.e frame type unchanged

        }
    }

}

