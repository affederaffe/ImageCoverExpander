using ImageCoverExpander.Configuration;

using Zenject;


namespace ImageCoverExpander.Installers
{
    public class ExpanderMenuInstaller : Installer
    {
        private readonly PluginConfig _config;

        public ExpanderMenuInstaller(PluginConfig config)
        {
            _config = config;
        }

        public override void InstallBindings()
        {
            Container.BindInstance(_config);
            Container.BindInterfacesTo<CoverExpander>().AsSingle();
        }
    }
}