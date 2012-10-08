using TechTalk.SpecFlow.Generator.Configuration;
using TechTalk.SpecFlow.Generator.Plugins;
using TechTalk.SpecFlow.Generator.UnitTestConverter;

[assembly: TechTalk.SpecFlow.Infrastructure.GeneratorPlugin(typeof(AttributeGenerator.SpecFlowPlugin.GeneratorPlugin))]

namespace AttributeGenerator.SpecFlowPlugin
{
    public class GeneratorPlugin : IGeneratorPlugin
    {
        public void RegisterDependencies(BoDi.ObjectContainer container)
        {
            // SKIP
        }

        public void RegisterCustomizations(BoDi.ObjectContainer container, SpecFlowProjectConfiguration generatorConfiguration)
        {
            container.RegisterTypeAs<AttributeGenerator, ITestMethodTagDecorator>("mka.AttributeGenerator");
        }

        public void RegisterConfigurationDefaults(SpecFlowProjectConfiguration specFlowConfiguration)
        {
            // SKIP
        }
    }
}
