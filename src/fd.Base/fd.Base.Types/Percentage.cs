namespace fd.Base.Types
{
    /// <summary>
    /// Represents a percentage value in the narrow sense: 0% to 100%.
    /// </summary>
    public class Percentage : Constrained<int>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Percentage"/> class.
        /// </summary>
        public Percentage()
            : base(Constraint)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Percentage"/> class.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        public Percentage(int value)
            : base(Constraint, value)
        {
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="System.Int32"/> to <see cref="fd.Base.Types.Percentage"/>.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator Percentage(int value)
        {
            return new Percentage(value);
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return Value + "%";
        }

        /// <summary>
        /// Checks whether the specified value is a percentage in the narrow sense.
        /// </summary>
        /// <param name="v">
        /// The value to be checked.
        /// </param>
        /// <returns>
        /// <c>true</c> if the value represents one such narrow percentage; otherwise, <c>false</c>.
        /// </returns>
        private static bool Constraint(int v)
        {
            return v >= 0 && v <= 100;
        }
    }
}
