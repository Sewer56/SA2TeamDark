using System;
using Reloaded.Mod.Interfaces;
using Reloaded.Mod.Interfaces.Internal;
using Reloaded.Universal.Redirector.Interfaces;
using SonicHeroes.Skins.SA2TeamDark.Template;

namespace SonicHeroes.Skins.SA2TeamDark
{
    public class Program : IMod
    {
        private const string ModId = "sonicheroes.skins.sa2teamdark"; // Insert Your Mod ID from ModConfig.json Here

        private ILogger _logger;
        private IModLoader _modLoader;
        private CharacterSwapper _swapper;

        public void Start(IModLoaderV1 loader)
        {
            _modLoader = (IModLoader)loader;
            _logger    = (ILogger)_modLoader.GetLogger();

            /* Your mod code starts here. */
            var modFolder     = _modLoader.GetDirectoryForModId(ModId);
            var configurator  = new Configurator(modFolder);
            var configuration = configurator.GetConfiguration<Config>(0);
            var redirector    = _modLoader.GetController<IRedirectorController>();
            _swapper = new CharacterSwapper(_logger, configuration, modFolder, redirector);

            _modLoader.ModLoaded += OnRedirectorLoaded;
        }

        /* Events */
        private void OnRedirectorLoaded(IModV1 arg1, IModConfigV1 arg2)
        {
            if (arg2.ModId.Equals("reloaded.universal.redirector", StringComparison.OrdinalIgnoreCase))
                _swapper.SetRedirector(_modLoader.GetController<IRedirectorController>());
        }

        /* Mod loader actions. */
        public void Suspend()
        {
            _swapper.RemoveAllRedirects();
        }

        public void Resume()
        {
            _swapper.ApplyConfig();
        }

        public void Unload() => Suspend();
        public bool CanUnload()  => true;
        public bool CanSuspend() => true;

        /* Automatically called by the mod loader when the mod is about to be unloaded. */
        public Action Disposing { get; }
    }
}
