using Zenject;


namespace ImageCoverExpander.Installers
{
    public class ExpanderMenuInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<CoverExpander>().AsSingle();
        }
    }
}