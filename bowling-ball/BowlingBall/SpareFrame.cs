namespace BowlingBall
{
    public sealed class SpareFrame : Frame
    {
        public SpareFrame(int role1, int role2) : base(role1, role2)
        { }
        public override int GetScore() => TEN;
    }

}

