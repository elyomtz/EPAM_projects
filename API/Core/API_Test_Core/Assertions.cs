using log4net;
using NUnit.Framework.Constraints;
using API.Core.Logger;

namespace API.Core.API_Test_Core
{
    public static class Assertions
    {
        private static readonly ILog logger = LoggerManager.Create<TestBase>();
        public static void That<T>(
            T actual,
            IResolveConstraint expression,
            string message = "")
        {
            try
            {
                Assert.That(actual, expression, message);
            }
            catch (AssertionException ex)
            {
                logger.Error(
                    $"Assertion failed. " +
                    $"Expected: {expression}. " +
                    $"Actual: {actual}. " +
                    $"Message: {ex.Message}");

                throw;
            }
        }
    }
}
