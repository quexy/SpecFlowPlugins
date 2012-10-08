using System;
using System.CodeDom;
using TechTalk.SpecFlow.Generator;
using TechTalk.SpecFlow.Generator.UnitTestConverter;

namespace TestCaseDecorator.SpecFlowPlugin
{
    /// <summary>
    /// Sample test method decorator plugin for SpecFlow. Inserts
    /// a 'Console.WriteLine' as the first line of the running
    /// test to report that a test case (a scenario marked with
    /// @tc:* tag) is running.
    /// </summary>
    public class TestCaseDecorator : ITestMethodTagDecorator
    {
        private const string TagPrefix = "tc:";

        public int Priority { get { return PriorityValues.Normal; } }

        public bool RemoveProcessedTags { get { return false; } }

        public bool ApplyOtherDecoratorsForProcessedTags { get { return false; } }

        public bool CanDecorateFrom(string tagName, TestClassGenerationContext generationContext, CodeMemberMethod testMethod)
        {
            return tagName.Length > TagPrefix.Length
                && tagName.StartsWith(TagPrefix, StringComparison.InvariantCultureIgnoreCase);
        }

        public void DecorateFrom(string tagName, TestClassGenerationContext generationContext, CodeMemberMethod testMethod)
        {
            var testCase = tagName.Substring(TagPrefix.Length);
            testMethod.Statements.Insert(0,
                new CodeExpressionStatement
                (
                    new CodeMethodInvokeExpression
                    (
                        new CodeTypeReferenceExpression(typeof(Console)),
                        "WriteLine",
                        new CodePrimitiveExpression(string.Format("Running test case '{0}'", testCase))
                    )
                )
            );
        }
    }
}
