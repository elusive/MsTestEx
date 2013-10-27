using System;
using System.Text;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MsTestEx
{
    public class TestClassExResults
    {
        /// <summary>
        /// Member variables
        /// </summary>
        private int _rowCount;
        /// <summary>
        /// Lets us know if there is a failure somewhere in the list of results
        /// </summary>
        private bool _hasTestFailures;
        /// <summary>
        /// Will be used when we provide the results for the results detail
        /// </summary>
        private readonly StringBuilder _resultStringBuilder = new StringBuilder();

        /// <summary>
        /// Adds a result to the list of results we have
        /// </summary>
        /// <param name="result">The result of the iteraiton</param>
        /// <param name="rowValues">Row Values that were used for the iteraiton</param>
        public void AddTestResult(TestMethodInvokerResult result, object[] rowValues)
        {
            _rowCount++;
            WriteResultHeader(rowValues);
            WriteTestOutcome(result);
        }


        /// <summary>
        /// Gets the full run results to return to the client
        /// </summary>
        /// <returns>TestMethodInvokerResult to return to client</returns>
        public TestMethodInvokerResult GetAllResults()
        {

            var sb = new StringBuilder();
            sb.AppendFormat("Tested {0} rows \n\n", _rowCount);
            sb.AppendLine();
            sb.Append(_resultStringBuilder);

            var tmir = new TestMethodInvokerResult { ExtensionResult = sb.ToString() };

            if (_hasTestFailures)
                tmir.Exception = new Exception("see test details");

            return tmir;
        }

        /// <summary>
        /// Writes failure information if iteration failed
        /// </summary>
        /// <param name="result">failed result incl any exceptionh</param>
        private void WriteFailureMessage(TestMethodInvokerResult result)
        {
            _resultStringBuilder.AppendLine("failed");
            Exception ex = result.Exception;
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
            }
            _resultStringBuilder.AppendLine(ex.Message);
        }

        /// <summary>
        /// Writes the result of the iteration to the results string builder
        /// </summary>
        /// <param name="result">The result for this iteration</param>
        private void WriteTestOutcome(TestMethodInvokerResult result)
        {
            _resultStringBuilder.Append("Outcome: ");

            if (result.Exception != null)
            {
                _hasTestFailures = true;
                WriteFailureMessage(result);
            }
            else
            {
                _resultStringBuilder.AppendLine("passed");
            }
            _resultStringBuilder.AppendLine("--------------------------");
            _resultStringBuilder.AppendLine();
            return;
        }

        /// <summary>
        /// writes header information to our results string builder
        /// </summary>
        /// <param name="rowValues">Row values that were used when executing the test</param>
        private void WriteResultHeader(object[] rowValues)
        {
            _resultStringBuilder.AppendFormat("Row {0} execution \n", _rowCount);
            _resultStringBuilder.Append("Row input values: ");
            foreach (var o in rowValues)
                _resultStringBuilder.AppendFormat(o.ToString() + " ");

            _resultStringBuilder.AppendLine();
        }
    }
}
