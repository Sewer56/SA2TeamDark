using System.ComponentModel;
using System.Diagnostics;
using SonicHeroes.Skins.SA2TeamDark.Configuration;
using SonicHeroes.Skins.SA2TeamDark.Configuration.Characters;
using SonicHeroes.Skins.SA2TeamDark.Configuration.Characters.Omega;
using SonicHeroes.Skins.SA2TeamDark.Configuration.Characters.Omega.Animations;
using SonicHeroes.Skins.SA2TeamDark.Configuration.Characters.Rouge;
using SonicHeroes.Skins.SA2TeamDark.Configuration.Characters.Rouge.Animations;
using SonicHeroes.Skins.SA2TeamDark.Configuration.Characters.Shadow;
using SonicHeroes.Skins.SA2TeamDark.Configuration.Characters.Shadow.Animations;
using SonicHeroes.Skins.SA2TeamDark.Template;

namespace SonicHeroes.Skins.SA2TeamDark
{
    public class Config : Configurable<Config>
    {
        private const string CategoryCharSelect = "Character Select";
        private const string CategoryCustomizer = "Character Customization";

        /* -- Character Select -- */
        [Category(CategoryCharSelect)]
        [DisplayName("Shadow")]
        [Description("The character that replaces shadow.")]
        public ShadowCharacters CharShadow { get; set; }

        [Category(CategoryCharSelect)]
        [DisplayName("Rouge")]
        [Description("The character that replaces rouge.")]
        public RougeCharacters CharRouge { get; set; }

        [Category(CategoryCharSelect)]
        [DisplayName("Omega")]
        [Description("The character that replaces omega.")]
        public OmegaCharacters CharOmega { get; set; }

        /* -- Character Customization -- */
        [Category(CategoryCustomizer)]
        [DisplayName(nameof(Shadow))]
        public CharacterEntry<ShadowModel, ShadowAnimation> Shadow { get; set; } =
            new CharacterEntry<ShadowModel, ShadowAnimation>("Shadow", ShadowModel.ShadowGamecube, ShadowAnimation.Regular);

        [Category(CategoryCustomizer)]
        [DisplayName(nameof(Rouge))]
        public CharacterEntry<RougeModel, RougeAnimation> Rouge { get; set; } =
            new CharacterEntry<RougeModel, RougeAnimation>("Rouge", RougeModel.RegularBattle, RougeAnimation.Regular);

        [Category(CategoryCustomizer)]
        [DisplayName(nameof(Omega))]
        public CharacterEntry<OmegaModel, OmegaAnimation> Omega { get; set; } =
            new CharacterEntry<OmegaModel, OmegaAnimation>("Omega", OmegaModel.Regular, OmegaAnimation.Regular);

        [Category(CategoryCustomizer)]
        [DisplayName(nameof(EggWalker))]
        public CharacterEntry<EggWalkerModel, EggWalkerAnimation> EggWalker { get; set; } =
            new CharacterEntry<EggWalkerModel, EggWalkerAnimation>("EggWalker", EggWalkerModel.Gamecube, EggWalkerAnimation.GamecubeWalker);

        [Category(CategoryCustomizer)]
        [DisplayName(nameof(MechlessEggman))]
        public CharacterEntry<MechlessEggmanModel, MechlessEggmanAnimation> MechlessEggman { get; set; } =
            new CharacterEntry<MechlessEggmanModel, MechlessEggmanAnimation>("MechlessEggman", MechlessEggmanModel.Gamecube, MechlessEggmanAnimation.Default);
    }
}
