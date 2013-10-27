
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MsTestEx
{
    public class TestClassExExecution : TestExtensionExecution
    {
        /// <summary>
        /// Before execution starts, this method is called to enable subscription to the Unit Test Events.
        /// </summary>
        /// <param name="execution">The <see cref="T:Microsoft.VisualStudio.TestTools.UnitTesting.TestExecution"/>.</param>
        public override void Initialize(TestExecution execution)
        {
        }

        /// <summary>
        /// Returns the object that will be used to invoke the test method
        /// </summary>
        /// <param name="invokerContext">Contains information about the run and the test being executed</param>
        /// <returns>Invoker object</returns>
        public override ITestMethodInvoker CreateTestMethodInvoker(TestMethodInvokerContext invokerContext)
        {
            return new TestClassExInvoker(invokerContext);
        }

        /// <summary>
        /// Releases all resources used by the <see cref="T:Microsoft.VisualStudio.TestTools.UnitTesting.TestExtensionExecution"/>.
        /// </summary>
        public override void Dispose()
        {
        }
    }
}
