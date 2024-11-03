using System.Media;

namespace Console_RPG.Assistant
{
    internal class Sound
    {
        private static readonly SoundPlayer soundPlayer = new();
        internal static void SFXPlayer(string path)
        {
            soundPlayer.SoundLocation = $"SFX\\{path}";
            soundPlayer.Play();
        }
    }
}
