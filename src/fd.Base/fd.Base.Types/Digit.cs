namespace fd.Base.Types
{
    /// <summary>
    /// Represents a digit.
    /// </summary>
    public class Digit : Constrained<int>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Digit"/> class.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        public Digit(int value)
            : base(Constraint, value)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Digit"/> class.
        /// </summary>
        public Digit()
            : base(Constraint)
        {
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="System.Int32"/> to <see cref="fd.Base.Types.Digit"/>.
        /// </summary>
        /// <param name="value">
        /// The value representing the digit.
        /// </param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator Digit(int value)
        {
            return new Digit(value);
        }

        /// <summary>
        /// Checks whether the specified value represents a valid digit.
        /// </summary>
        /// <param name="value">
        /// The value to be checked against the constraint.
        /// </param>
        /// <returns>
        /// <c>true</c> if the supplied value represents a valid digit; otherwise, <c>false</c>.
        /// </returns>
        private static bool Constraint(int value)
        {
            return value >= 0 && value <= 9;
        }
    }
}
