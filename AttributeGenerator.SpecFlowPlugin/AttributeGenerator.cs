using System;
using System.CodeDom;
using TechTalk.SpecFlow.Generator;
using TechTalk.SpecFlow.Generator.UnitTestConverter;

namespace AttributeGenerator.SpecFlowPlugin
{
    /// <summary>
    /// Sample test method attribute generator plugin for SpecFlow.
    /// Turns '@sta' tags into '[STAThread]' attributes.
    /// </summary>
    public class AttributeGenerator : ITestMethodTagDecorator
    {
        public int Priority { get { return PriorityValues.Normal; } }

        public bool RemoveProcessedTags { get { return true; } }

        public bool ApplyOtherDecoratorsForProcessedTags { get { return false; } }

        public bool CanDecorateFrom(string tagName, TestClassGenerationContext generationContext, CodeMemberMethod testMethod)
        {
            return string.Equals(tagName, "sta", StringComparison.InvariantCultureIgnoreCase);
        }

        public void DecorateFrom(string tagName, TestClassGenerationContext generationContext, CodeMemberMethod testMethod)
        {
            testMethod.CustomAttributes.Add(new CodeAttributeDeclaration(typeof(STAThreadAttribute).FullName));
        }
    }
}
