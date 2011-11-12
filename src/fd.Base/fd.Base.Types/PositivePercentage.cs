namespace fd.Base.Types
{
    /// <summary>
    /// Represents a positive percentage value in the wider sense. 100% = 1.0.
    /// </summary>
    public class PositivePercentage : Constrained<double>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PositivePercentage"/> class.
        /// </summary>
        public PositivePercentage()
            : base(x => x >= 0)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PositivePercentage"/> class.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        public PositivePercentage(double value)
            : base(x => x >= 0, value)
        {
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="System.Int32"/> to <see cref="fd.Base.Types.UnconstrainedPercentage"/>.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator PositivePercentage(double value)
        {
            return new PositivePercentage(value);
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return (Value * 100) + "%";
        }
    }
}
