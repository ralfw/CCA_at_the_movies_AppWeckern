using System.Media;
using appweckern.contracts;

namespace appweckern.bimmel
{
    public class Bimmel : IBimmel
    {
        private SoundPlayer soundplayer;
        private readonly string filename;

        public Bimmel() {
            filename = "ring.wav";
            Init();
        }

        private void Init() {
            soundplayer = new SoundPlayer {
                SoundLocation = filename
            };
            soundplayer.Load();
        }

        public void Läuten() {
            soundplayer.PlaySync();
        }
    }
}