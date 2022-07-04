namespace BowlingBall
{
    public sealed class StrikeFrame : Frame
    {
        public StrikeFrame(int role1) : base(role1)
        { }
        public override bool IsCompleted => Role1.HasValue;
        public override int GetScore() => TEN;

    }

}

