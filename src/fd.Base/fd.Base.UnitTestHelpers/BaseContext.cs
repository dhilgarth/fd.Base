using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoNSubstitute;

namespace fd.Base.UnitTestHelpers
{
    /// <summary>The base class of all test contexts.</summary>
    public abstract class BaseContext
    {
        private readonly IFixture _fixture;

        /// <summary>Initializes a new instance of the <see cref="BaseContext" /> class.</summary>
        protected BaseContext()
        {
            _fixture = new Fixture().Customize(new AutoNSubstituteCustomization()).Customize(new StableFiniteSequenceCustomization());
        }

        /// <summary>Gets the fixture.</summary>
        public IFixture Fixture
        {
            get { return _fixture; }
        }
    }
}
