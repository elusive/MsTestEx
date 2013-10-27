# MsTestEx
## MSTest Extensions 
### for Visual Studio 2012 (x64)

This project is a set of (only one currently) extensions for MSTest.  Specifically this library enables
the `[TestCase]` attribute in ms test classes, for performing parameterized test methods just like in NUnit. There is also a new test class attribute as that is the only way to exentend ms test currently.  You cannot 
directly extend the existing TestClass, but rather you have to add a new class level attribute.  For this 
project that new attribute is `[TestClassEx]`.

So in order to utilize the new extensions you must decorate your test class with this new attribute.

Here is an example of the usage, including a regular TestMethod and including the new TestCase row test method:

````cs
namespace ApplicationServices.Tests
{
    [TestClassEx]
    public class ChecklistServiceTests
    {
        [TestMethod]
        public void TestRegular()
        {
            Assert.IsTrue(true);
        }

        [TestMethod]                                           
        [TestCase(DaysOfTheWeek.Tuesday, "0Y23456")]          
        [TestCase(DaysOfTheWeek.Thursday, "012Y456")]         
        [TestCase(DaysOfTheWeek.Friday, "0123Y56")]
        [TestCase(DaysOfTheWeek.Saturday, "01234Y6")]         
        [TestCase(DaysOfTheWeek.Sunday, "012345Y")]
        public void TestDayOfWeekTechnique(DaysOfTheWeek day, string exp)
        {
            // arrange
            var testDay = day;
            var testString = "0123456";

            // act
            var idx = (int)testDay;
            var actual = testString.Remove(idx, 1).Insert(idx, "Y");

            // assert
            Assert.AreEqual(exp, actual);
        }
    }
}
````

__IMPORTANT NOTES:__

1. You must use the install.bat file to install the extension.  Unfortunately, to extend ms test you must copy the new 
library to the vs program directory into /Common7/IDE/PublicAssemblies in order for it to work.  You must also add
a new registry key to a certain location. 
2. The current script is designed for VS 2012 on Windows 7 x64.  You will need to alter the location of the file copy 
and of the registry key for 32-bit installs.  This is not difficult though, just edit the install.bat file directly.
3. The installer project does not currently work.  I have completed all of the WiX files but cannot get around a
permission denied error when trying to do edit the registry.  I have tried several things.  And any ideas would be welcome.

If anyone has any suggestions for other extensions or any requests or questions you can reach me here or at my blog
at http://johngilliland.wordpress.com
