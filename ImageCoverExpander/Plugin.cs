using ImageCoverExpander.Configuration;
using ImageCoverExpander.Installers;

using IPA;
using IPA.Config;
using IPA.Config.Stores;

using SiraUtil.Zenject;


namespace ImageCoverExpander
{
    [Plugin(RuntimeOptions.DynamicInit)]
    // ReSharper disable once UnusedType.Global
    public class Plugin
    {
        [Init]
        public Plugin(Config config, Zenjector zenjector)
        {
            zenjector.OnMenu<ExpanderMenuInstaller>().WithParameters(config.Generated<PluginConfig>());
        }
    }
}