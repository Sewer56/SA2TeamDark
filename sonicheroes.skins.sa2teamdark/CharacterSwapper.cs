using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using Reloaded.Mod.Interfaces;
using Reloaded.Universal.Redirector.Interfaces;
using SonicHeroes.Skins.SA2TeamDark.Configuration;
using SonicHeroes.Skins.SA2TeamDark.Configuration.Characters;

namespace SonicHeroes.Skins.SA2TeamDark
{
    public class CharacterSwapper
    {
        private ILogger _logger;
        private Config _config;
        private string _modFolder;
        private WeakReference<IRedirectorController> _redirector;
        private List<Tuple<string, string>> _redirects = new List<Tuple<string, string>>();

        public CharacterSwapper(ILogger logger, Config config, string modFolder, WeakReference<IRedirectorController> redirector)
        {
            _redirector = redirector;
            _logger = logger;
            _config = config;
            _modFolder = modFolder;
            _config.ConfigurationUpdated += OnConfigurationUpdated;
            ApplyConfig();
        }

        /* Initialize */
        public void RemoveAllRedirects()
        {
            if (_redirector.TryGetTarget(out var redirector))
            {
                foreach (var redirect in _redirects)
                    redirector.RemoveRedirectFolder(redirect.Item1, redirect.Item2);
            }
        }

        public void ApplyConfig()
        {
            // Remove existing redirects.
            RemoveAllRedirects();


            if (_redirector.TryGetTarget(out var redirector))
            {
                // Shadow
                switch (_config.CharShadow)
                {
                    case ShadowCharacters.Shadow:
                        AddCharacterRedirect(redirector, _config.Shadow);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                // Rouge
                switch (_config.CharRouge)
                {
                    case RougeCharacters.Rouge:
                        AddCharacterRedirect(redirector, _config.Rouge);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                // Omega
                switch (_config.CharOmega)
                {
                    case OmegaCharacters.Omega:
                        AddCharacterRedirect(redirector, _config.Omega);
                        break;
                    case OmegaCharacters.EggWalker:
                        AddCharacterRedirect(redirector, _config.EggWalker);
                        break;
                    case OmegaCharacters.MechlessEggman:
                        AddCharacterRedirect(redirector, _config.MechlessEggman);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        /* Functions */
        public void SetRedirector(WeakReference<IRedirectorController> redirector) => _redirector = redirector;

        /* Events */
        private void OnConfigurationUpdated(IConfigurable obj)
        {
            _config = (Config)obj;
            _logger.WriteLine($"[SA2 Team Dank] Config Updated: Applying");
            ApplyConfig();
        }

        /* Utility */
        private void AddCharacterRedirect<TCharacter, TAnimation>(IRedirectorController redirector, CharacterEntry<TCharacter, TAnimation> entry) where TCharacter : Enum where TAnimation : Enum
        {
            AddRedirectFolder(redirector, entry.GetModelFolder(_modFolder));
            AddRedirectFolder(redirector, entry.GetAnimationFolder(_modFolder));
        }

        private void AddRedirectFolder(IRedirectorController redirector, string folder)
        {
            const string dvdroot = "/dvdroot";
            _redirects.Add(new Tuple<string, string>(folder, dvdroot));
            redirector.AddRedirectFolder(folder, dvdroot);
        }
    }
}
