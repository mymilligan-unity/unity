using Microsoft.Practices.Unity.Configuration;

namespace Microsoft.Practices.Unity.InterceptionExtension.Configuration
{
    /// <summary>
    /// Section extension class used to add the elements needed to configure
    /// Unity interception to the configuration schema.
    /// </summary>
    public class InterceptionConfigurationExtension : SectionExtension
    {
        /// <summary>
        /// Add the extensions to the section via the context.
        /// </summary>
        /// <param name="context">Context object that can be used to add elements and aliases.</param>
        [System.Security.SecuritySafeCritical]
        public override void AddExtensions(SectionExtensionContext context)
        {
            AddAliases(context);

            AddElements(context);
        }

        private static void AddElements(SectionExtensionContext context)
        {
            context.AddElement<AddInterfaceElement>("addInterface");
            context.AddElement<PolicyInjectionElement>("policyInjection");
        }

        [System.Security.SecurityCritical]
        private static void AddAliases(SectionExtensionContext context)
        {
        }
    }
}
