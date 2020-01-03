using System;
using System.ComponentModel;
using System.IO;

namespace SonicHeroes.Skins.SA2TeamDark.Configuration
{
    /// <summary>
    /// Stores a character entry for the mod configuration.
    /// </summary>
    /// <typeparam name="TModel">The model to select.</typeparam>
    /// <typeparam name="TAnimation">The animation to select.</typeparam>
    public class CharacterEntry<TModel, TAnimation>
    {
        /// <summary>
        /// [DO NOT CHANGE] Name of the character and folder belonging to character.
        /// </summary>
        [Browsable(false)]
        [ReadOnly(true)]
        public string       Name       { get; set; }

        public TModel       Character  { get; set; }
        public TAnimation   Animation  { get; set; }

        // For serialization, do not remove.
        public CharacterEntry()
        { }

        public CharacterEntry(string name, TModel character, TAnimation animation)
        {
            Name = name;
            Character = character;
            Animation = animation;
        }

        public string GetModelFolder(string modFolder) => Path.GetFullPath($"{modFolder}/Assets/Models/{Name}/{Character.ToString()}");
        public string GetAnimationFolder(string modFolder) => Path.GetFullPath($"{modFolder}/Assets/Animations/{Name}/{Animation.ToString()}");

        public override string ToString()
        {
            return $"Character: {Character}, Animation: {Animation}";
        }
    }
}
