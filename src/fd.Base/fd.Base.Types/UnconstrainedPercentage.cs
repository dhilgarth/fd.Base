namespace fd.Base.Types
{
    /// <summary>
    /// Represents a percentage value in the wider sense. 100% = 1.0.
    /// </summary>
    public class UnconstrainedPercentage : Constrained<double>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnconstrainedPercentage"/> class. 
        /// </summary>
        public UnconstrainedPercentage()
            : base(x => true)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnconstrainedPercentage"/> class.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        public UnconstrainedPercentage(double value)
            : base(x => true, value)
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
        public static implicit operator UnconstrainedPercentage(double value)
        {
            return new UnconstrainedPercentage(value);
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