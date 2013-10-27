using System;

namespace MsTestEx
{
    /// <summary>
    /// TestCase attribute used to define a row test instance and pass parameters
    /// </summary>
    [global::System.AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = true)]
    public sealed class TestCaseAttribute : Attribute
    {
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="rowValues">The values we plan to hold for each iteration of the method</param>
        public TestCaseAttribute(params object[] rowValues)
        {
            RowValues = rowValues;
        }

        /// <summary>
        /// The stored values
        /// </summary>
        public object[] RowValues { get; private set; }
    }
}
