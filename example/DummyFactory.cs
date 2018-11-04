using PipServices3.Components.Build;
using PipServices3.Commons.Refer;

namespace PipServices3.Container
{
    public class DummyFactory : Factory
    {
        public static Descriptor Descriptor = new Descriptor("pip-services3-dummies", "factory", "default", "default", "1.0");
        public static Descriptor ControllerDescriptor = new Descriptor("pip-services3-dummies", "controller", "*", "*", "1.0");

        public DummyFactory()
        {
            RegisterAsType(ControllerDescriptor, typeof(DummyController));
	    }
    }
}
