using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MsTestEx
{
    public class TestClassExInvoker: ITestMethodInvoker
    {
        /// <summary>
        /// Test Context member
        /// </summary>
        private readonly TestMethodInvokerContext _invokerContext;

        /// <summary>
        /// Invoker constructor.  Allows you to save off the context
        /// </summary>
        /// <param name="invokerContext">context of the test/run</param>
        public TestClassExInvoker(TestMethodInvokerContext invokerContext)
        {
            _invokerContext = invokerContext;
        }

        /// <summary>
        /// The method that gets called when a test is executed
        /// </summary>
        /// <param name="args">arguments that are passed from the test signature</param>
        /// <returns></returns>
        public TestMethodInvokerResult Invoke(params object[] args)
        {
            // Our helper results class to aggregate our test results
            var results = new TestClassExResults();

            // Gets the custom attribute off the method
            var rows = _invokerContext.TestMethodInfo.GetCustomAttributes(typeof(TestCaseAttribute), false);
            if (rows.Length == 0)
            {
                // If there is no rows, just execute the code
                return _invokerContext.InnerInvoker.Invoke(null);
            }
            else
            {
                // If we find rows, loop through them and invoke the test case with each iteraiton
                foreach (TestCaseAttribute attr in _invokerContext.TestMethodInfo.GetCustomAttributes(typeof(TestCaseAttribute), false))
                {
                    // Add results to our aggregator
                    results.AddTestResult(_invokerContext.InnerInvoker.Invoke(attr.RowValues), attr.RowValues);
                }
                // Return the aggregated results and output them to test explorer
                _invokerContext.TestContext.WriteLine(results.GetAllResults().ExtensionResult.ToString());
                return results.GetAllResults();
            }
        }
    }
}
