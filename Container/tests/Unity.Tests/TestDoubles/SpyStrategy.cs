using Unity.Builder;
using Unity.Strategies;

namespace Unity.Tests.v5.TestDoubles
{
    /// <summary>
    /// A small snoop strategy that lets us check afterwards to
    /// see if it ran in the strategy chain.
    /// </summary>
    internal class SpyStrategy : BuilderStrategy
    {
        private object existing = null;
        private bool buildUpWasCalled = false;

        public override void PreBuildUp(ref BuilderContext context)
        {
            buildUpWasCalled = true;
            existing = context.Existing;

            UpdateSpyPolicy(ref context);
        }

        public override void PostBuildUp(ref BuilderContext context)
        {
            existing = context.Existing;
        }

        public object Existing => existing;

        public bool BuildUpWasCalled => buildUpWasCalled;

        private void UpdateSpyPolicy(ref BuilderContext context)
        {
            SpyPolicy policy = (SpyPolicy)context.Get(null, null, typeof(SpyPolicy));

            if (policy != null)
            {
                policy.WasSpiedOn = true;
            }
        }
    }
}
