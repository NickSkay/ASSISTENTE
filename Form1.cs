using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Speech.Recognition;
using System.Globalization;


namespace ASSISTENTE_TCC_01
{
    public partial class Form1 : Form
    {

        private SpeechRecognitionEngine engine;
        private CultureInfo ci;
        private bool EstaOuvindo = true;
        public static string NOME_ASSISTENTE = "Assistente";
        private string city;


        public Form1()
        {
            InitializeComponent();
            Init();
        }


        private void Init()
        {
            try
            {
                ci = new CultureInfo("pt_BR");
                engine = new SpeechRecognitionEngine(ci);
                SaidaSom.Speak("Carregando");

                city = Localizacao.GetCidadeNome(Executer.GetIp()).ToLower();

                SpeechRec();

                SaidaSom.Speak("Sistema Carregado");

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro em Init()");
            }
        }

        private void setText(string text)
        {
            this.labeltext.Text = "Você: " + text;
        }

        private void setColor(string cor)
        {
            switch (cor)
            {
                case "green":
                    this.labelstatus.BackColor = Color.Green;
                    break;

                case "red":
                    this.labelstatus.BackColor = Color.Red;
                    break;
                case "orange":
                    this.labelstatus.BackColor = Color.Orange;
                    break;
                default:
                    this.labelstatus.BackColor = Color.Black;
                    break;
            }

        }

        private List<Grammar> Load_Grammar()
        {


            List<Grammar> GramaticasParaFala = new List<Grammar>();
            

            #region Choices
            // SISTEMA
            Choices comandosDoSistema = new Choices();
            comandosDoSistema.Add(Gramaticas.QueHorasSao.ToArray());
            comandosDoSistema.Add(Gramaticas.QualDataE.ToArray());
            comandosDoSistema.Add(Gramaticas.PareDeOuvir.ToArray());
            comandosDoSistema.Add(Gramaticas.VolteAOuvir.ToArray());
            comandosDoSistema.Add(Gramaticas.Temperatura.ToArray());
            comandosDoSistema.Add(Gramaticas.MaisInformacoes.ToArray());
          
           


            // CÁLCULOS
            Choices QuantoE = new Choices();
            QuantoE.Add("Quanto é");

            Choices NValues = new Choices();
            NValues.Add(Gramaticas.Numeros.ToArray());

            Choices Operadores = new Choices();
            Operadores.Add(Gramaticas.Operadores.ToArray());

            

            #endregion

            #region GramarBuilder
            GrammarBuilder comandosDoSistema_gb = new GrammarBuilder();
            comandosDoSistema_gb.Append(comandosDoSistema);

            GrammarBuilder calculos = new GrammarBuilder();
            calculos.Append(QuantoE);
            calculos.Append(NValues);
            calculos.Append(Operadores);
            calculos.Append(NValues);

            #endregion

            #region Grammar
            Grammar gramaticaSistema = new Grammar(comandosDoSistema_gb);
            gramaticaSistema.Name = "system";
            Grammar gramaticaCalculos = new Grammar(calculos);
            gramaticaCalculos.Name = "calc";
            #endregion



            GramaticasParaFala.Add(gramaticaSistema);
            GramaticasParaFala.Add(gramaticaCalculos);
            return GramaticasParaFala;


         
        }

        private void SpeechRec()
        {
            try
            {
                List<Grammar> g = Load_Grammar();

                #region Speech Recognition (Eventos)

                engine.SetInputToDefaultAudioDevice();

                foreach(Grammar gr in g)
                {
                    engine.LoadGrammar(gr);
                }

                engine.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(Rec);
                engine.AudioLevelUpdated += new EventHandler<AudioLevelUpdatedEventArgs>(AudioLevel);
                engine.SpeechRecognitionRejected += new EventHandler<SpeechRecognitionRejectedEventArgs>(Rejected);

                #endregion

                engine.RecognizeAsync(RecognizeMode.Multiple); //inicia o reconhecimento

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro em SpeechRec()");
            }
        }

        #region Eventos do reconhecimento

        private void Rec(object s, SpeechRecognizedEventArgs e) //Entra caso seja reconhecido
        {
            string fala = e.Result.Text;

            
            

            if (EstaOuvindo)
            {

                setText(fala);
                setColor("green");


                switch (e.Result.Grammar.Name)
                {
                    case "system":
                        // Tudo aqui corresponde a gramatica do sistema

                        if (Gramaticas.QueHorasSao.Any(f => f == fala))
                        {                           
                            Executer.GetHoras();
                        }
                        else if (Gramaticas.QualDataE.Any(f => f == fala))
                        {                                             
                            Executer.GetData();
                        }
                        else if(Gramaticas.PareDeOuvir.Any(f => f == fala))
                        {
                            EstaOuvindo = false;
                            setColor("orange");
                            Executer.ModoSilencioso();
                        }
                        else if(Gramaticas.Temperatura.Any(f => f == fala))
                        {
                            Executer.GetTemperature(city);
                        }
                        else if(Gramaticas.MaisInformacoes.Any(f => f == fala))
                        {
                            Executer.GetMainInfos(city);
                        }
               
                        break;

                    case "calc":
                        SaidaSom.Speak(Calculadora.Calcule(fala));
                        break;
                }
                
            }
            else
            {
                if (Gramaticas.VolteAOuvir.Any(f => f == fala))
                {
                    EstaOuvindo = true;
                    setColor("green");
                    Executer.VoltandoDoModoSilencioso();
                    
                }
            }





        }
        private void AudioLevel(object s, AudioLevelUpdatedEventArgs e)
        {

            if (e.AudioLevel > barraDeAudio.Maximum)
            {
                barraDeAudio.Value = barraDeAudio.Maximum;
            }
            else if (e.AudioLevel < barraDeAudio.Minimum)
            {
                barraDeAudio.Value = barraDeAudio.Minimum;
            }
            else
            {
                barraDeAudio.Value = e.AudioLevel;
            }
             
        }

        private void Rejected(object s, SpeechRecognitionRejectedEventArgs e) //O que nao for reconhecido
        {
            setText("????????");
            setColor("red");
        }

        #endregion
    }
}
