using PipServices3.Components.Log;
using PipServices3.Commons.Refer;
using Xunit;

namespace PipServices3.Container.Refer
{
    public class ManagedReferencesTest
    {
        [Fact]
        public void TestAutoCreateComponent()
        {
            var refs = new ManagedReferences();

            var factory = new DefaultLoggerFactory();
            refs.Put(null, factory);

            var logger = refs.GetOneRequired<ILogger>(new Descriptor("*", "logger", "*", "*", "*"));
            Assert.NotNull(logger);
        }

        [Fact]
        public void TestStringLocator()
        {
            var refs = new ManagedReferences();

            var factory = new DefaultLoggerFactory();
            refs.Put(null, factory);

            var component = refs.GetOneOptional("ABC");
            Assert.Null(component);
        }

        //[Fact]
        //public void TestNullLocator()
        //{
        //    var refs = new ManagedReferences();

        //    var factory = new DefaultLoggerFactory();
        //    // Todo: Allow to put null references
        //    refs.Put(null, factory);

        //    var component = refs.GetOneOptional(null);
        //    Assert.Null(component);
        //}
    }
}
