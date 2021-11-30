using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;

namespace ASSISTENTE_TCC_01
{
    class SaidaSom
    {
        private static SpeechSynthesizer synthesizer = new SpeechSynthesizer();

        public static void Speak(string text)
        {
            if (synthesizer.State == SynthesizerState.Speaking)
                synthesizer.SpeakAsyncCancelAll();

            synthesizer.SpeakAsync(text);
        }

        public static void Speak(params string[] text)
        {
            Speak(text[new Random().Next(0, text.Length - 1)]);
        } 
    }
}
