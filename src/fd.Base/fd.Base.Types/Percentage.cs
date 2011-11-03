namespace fd.Base.Types
{
    public class Percentage : Constrained<int>
    {
        public Percentage() : base(Constraint) {}
        public Percentage(int value) : base(Constraint, value) {}

        private static bool Constraint(int v)
        {
            return v >= 0 && v <= 100;
        }

        public static implicit operator Percentage(int value)
        {
            return new Percentage(value);
        }

        public override string ToString()
        {
            return Value + "%";
        }
    }
}
