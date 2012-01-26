namespace fd.Base.UnitTestHelpers
{
    /// <summary>Represents a factory that creates a system under test (SUT) instance.</summary>
    /// <typeparam name="TSut">The type of the SUT.</typeparam>
    public interface ISutFactory<out TSut>
    {
        /// <summary>Creates an SUT instance.</summary>
        /// <returns>An instance of the SUT.</returns>
        TSut CreateSut();
    }
}
