using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MsTestEx
{
    [Serializable]
    public class TestClassExAttribute : TestClassExtensionAttribute
    {
        /// <summary>
        /// Id of this extention attribute
        /// </summary>
        private static readonly Uri Uri = new Uri("urn:TestClassExAttribute");
        
        /// <summary>
        /// Unique extension id to identify this extension attribute
        /// </summary>
        public override Uri ExtensionId
        {
            get { return Uri; }
        }

        /// <summary>
        /// Gets the execution object for this extension object.  This object will contain 
        /// interfaces for our execution code
        /// </summary>
        /// <returns>Execution Extension object</returns>
        public override TestExtensionExecution GetExecution()
        {
            return new TestClassExExecution();
        }
    }
}
