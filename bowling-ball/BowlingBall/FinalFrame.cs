namespace BowlingBall
{
    public sealed class FinalFrame : Frame
    {
        public int? Role3 { get; set; } // extra roll allowed in final frame
        public override bool IsCompleted => Role3.HasValue || (Role2.HasValue && (Role1 + Role2) < 10);
        public override int GetScore() => (int)(Role1 + Role2 + (Role3 ?? 0));
        public override Frame Roll(int pins)
        {
            // one spare or two strikes possible in final frame hence >= 10
            if (Role1.HasValue && Role2.HasValue && (Role1 + Role2) >= 10) 
                Role3 = pins;
            else
                AddRole(pins);

            return this;
        }
    }

}

