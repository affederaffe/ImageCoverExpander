using ImageCoverExpander.Installers;

using IPA;

using SiraUtil.Zenject;


namespace ImageCoverExpander
{
    [Plugin(RuntimeOptions.DynamicInit)]
    // ReSharper disable once UnusedType.Global
    public class Plugin
    {
        [Init]
        public Plugin(Zenjector zenjector)
        {
            zenjector.OnMenu<ExpanderMenuInstaller>();
        }
    }
}