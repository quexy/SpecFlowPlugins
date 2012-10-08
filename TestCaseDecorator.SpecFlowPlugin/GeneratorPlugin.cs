using TechTalk.SpecFlow.Generator.Configuration;
using TechTalk.SpecFlow.Generator.Plugins;
using TechTalk.SpecFlow.Generator.UnitTestConverter;

[assembly: TechTalk.SpecFlow.Infrastructure.GeneratorPlugin(typeof(TestCaseDecorator.SpecFlowPlugin.GeneratorPlugin))]

namespace TestCaseDecorator.SpecFlowPlugin
{
    public class GeneratorPlugin : IGeneratorPlugin
    {
        public void RegisterDependencies(BoDi.ObjectContainer container)
        {
            // SKIP
        }

        public void RegisterCustomizations(BoDi.ObjectContainer container, SpecFlowProjectConfiguration generatorConfiguration)
        {
            container.RegisterTypeAs<TestCaseDecorator, ITestMethodTagDecorator>("mka.TestCaseDecorator");
        }

        public void RegisterConfigurationDefaults(SpecFlowProjectConfiguration specFlowConfiguration)
        {
            // SKIP
        }
    }
}
