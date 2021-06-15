using System.Runtime.CompilerServices;

using IPA.Config.Stores;

using UnityEngine;


[assembly: InternalsVisibleTo(GeneratedStore.AssemblyVisibilityTarget)]
namespace ImageCoverExpander.Configuration
{
    public class PluginConfig
    {
        public virtual Color TextColor { get; set; } = new(1f, 1f, 1f, 0.9f);
        public virtual Color GradientColor0 { get; set; } = new(0.85f, 0.85f, 0.85f);
        public virtual Color GradientColor1 { get; set; } = new(0.4f, 0.4f, 0.4f);
    }
}