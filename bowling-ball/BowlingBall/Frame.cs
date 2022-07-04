namespace BowlingBall
{
    public abstract class Frame
    {
        public int? Role1 { get; set; }
        public int? Role2 { get; set; }
        
        protected const int TEN = 10;
        protected Frame(int? role1 = null, int? role2 = null)
        {
            Role1 = role1;
            Role2 = role2;
        }
        abstract public int GetScore();
        public virtual Frame Roll(int pins)
        {
            AddRole(pins);
            return this;
        }
        public virtual bool IsCompleted => Role1.HasValue && Role2.HasValue;
        protected void AddRole(int pin)
        {
            if (!Role1.HasValue)
                Role1 = pin;
            else
                Role2 = pin;
        }        
    }

}

