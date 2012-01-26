using System;

namespace fd.Base.Types
{
    /// <summary>Encapsulates a value of type <typeparamref name="T" /> with only a limited subset of valid values.</summary>
    /// <typeparam name="T">The type of the encapsulated value.</typeparam>
    public class Constrained<T>
    {
        private readonly Func<T, bool> _constraint;
        private T _value;

        /// <summary>Initializes a new instance of the <see cref="fd.Base.Types.Constrained`1" /> class.</summary>
        /// <param name="constraint">The constraint.</param>
        /// <param name="value">The value.</param>
        public Constrained(Func<T, bool> constraint, T value)
            : this(constraint)
        {
            Value = value;
        }

        /// <summary>Initializes a new instance of the <see cref="fd.Base.Types.Constrained`1" /> class.</summary>
        /// <param name="constraint">The constraint.</param>
        public Constrained(Func<T, bool> constraint)
        {
            _constraint = constraint;
        }

        /// <summary>Gets or sets the value.</summary>
        public T Value
        {
            get { return _value; }
            set
            {
                if (!_constraint(value))
                    throw new ArgumentException(string.Format("The value {0} doesn't match the constraints of this type.", value));
                _value = value;
            }
        }

        /// <summary>Performs an <see langword="implicit"/> conversion from <see cref="fd.Base.Types.Constrained<T>" /> to <see cref="T" /> .</summary>
        /// <param name="constrained">The constrained value.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator T(Constrained<T> constrained)
        {
            return constrained.Value;
        }

        /// <summary>Returns a <see cref="String" /> that represents this instance.</summary>
        /// <returns>A <see cref="String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
