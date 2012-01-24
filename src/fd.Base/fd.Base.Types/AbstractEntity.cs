namespace fd.Base.Types
{
    /// <summary>
    ///   The abstract entity.
    /// </summary>
    /// <typeparam name="TIdentity"> The type of the identiy property. </typeparam>
    public abstract class AbstractEntity<TIdentity>
    {
        private int? _requestedHashCode;

        /// <summary>
        ///   Gets or sets the id.
        /// </summary>
        public virtual TIdentity Id { get; protected set; }

        /// <summary>
        ///   Compare equality through Id.
        /// </summary>
        /// <param name="other"> Entity to compare. </param>
        /// <returns> True is are equals. </returns>
        /// <remarks>
        ///   Two entities are equals if they are of the same hierarcy tree/sub-tree and has same id.
        /// </remarks>
        public virtual bool Equals(AbstractEntity<TIdentity> other)
        {
            if (null == other)
                return false;
            if (ReferenceEquals(this, other))
                return true;

            // TODO: Check - add TEntity
            if (!GetType().IsInstanceOfType(other) && !GetType().BaseType.IsAssignableFrom(other.GetType().BaseType)
                && !GetType().IsAssignableFrom(other.GetType().BaseType) && !GetType().BaseType.IsAssignableFrom(other.GetType()))
                return false;

            var otherIsTransient = Equals(other.Id, default(TIdentity));
            var thisIsTransient = IsTransient();
            if (otherIsTransient && thisIsTransient)
                return ReferenceEquals(other, this);

            return other.Id.Equals(Id);
        }

        /// <summary>
        ///   Determines whether the specified <see cref="System.Object" /> is equal to this instance.
        /// </summary>
        /// <param name="obj"> The <see cref="System.Object" /> to compare with this instance. </param>
        /// <returns> <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c> . </returns>
        public override bool Equals(object obj)
        {
            var that = obj as AbstractEntity<TIdentity>;
            return Equals(that);
        }

        /// <summary>
        ///   Returns a hash code for this instance.
        /// </summary>
        /// <returns> A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. </returns>
        public override int GetHashCode()
        {
            if (!_requestedHashCode.HasValue)
                _requestedHashCode = IsTransient() ? base.GetHashCode() : Id.GetHashCode();
            return _requestedHashCode.Value;
        }

        /// <summary>
        ///   Determines whether this instance is transient.
        /// </summary>
        /// <returns> <c>true</c> if this instance is transient; otherwise, <c>false</c> . </returns>
        protected bool IsTransient()
        {
            return Equals(Id, default(TIdentity));
        }
    }
}