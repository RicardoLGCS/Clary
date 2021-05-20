using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.Threading;
using System.IO;
using System.Globalization;
using System.Speech.Recognition;

namespace Clary
{
    public partial class Form1 : Form
    {
        //Variables declaration
        int iCenterClaryVertically, iCurrentClaryYPosition, iCurrentClaryXPosition, iCurrentClaryWidth, iCurrentClaryHeight;
        string sMessage;
        Clary clary;
        ClaryModes claryModes;
        CurrentDateTime currentDateTime;
        MessageDisplay MessageDisplay;
        List<Commands> Commands;
        SpeechRecognitionEngine _recognizer, _recognizerSleep;
        StringBuilder errorMessage;
        SpeechSynthesizer _clary;
        TerminateClary terminateClary;
        Memos claryMemos;
        private void messageTimer_Tick(object sender, EventArgs e)
        {
            MessageDisplay.writeMessageByChar(messageTimer, sMessage, this);
        }
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            iCenterClaryVertically = ((Screen.PrimaryScreen.Bounds.Height / 2) - 128); //Calculation to center Clary vertically
            iCurrentClaryYPosition = this.Location.Y;
            iCurrentClaryXPosition = this.Location.X;
            iCurrentClaryWidth = this.Size.Width;
            iCurrentClaryHeight = this.Size.Height;
            this.Opacity = .75;

            this.Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            this.Location = new Point(0);
            //this.TopMost = true;

            pictureBox1.Size = new Size(760, 503);
            pictureBox1.Location = new Point(((this.Size.Width / 2) - (pictureBox1.Width / 2)), ((this.Size.Height / 2) - (pictureBox1.Height / 2)));

            try
            {
                clary = new Clary();
                clary.claryStart();
                _clary = clary.clary;

                //Creating a new instance of each command class and adding to alist of type "Commands"
                claryModes = new ClaryModes(); //Since claryModes is derived from Commands and Commands from Clary it will call Clary default constructor automatically
                currentDateTime = new CurrentDateTime();
                terminateClary = new TerminateClary();
                claryMemos = new Memos();
                Commands = new List<Commands> { claryModes, currentDateTime, terminateClary, claryMemos }; //It is possible to make a list with only classes that inherit from "Commands"

                //Returning both recognizers from claryModes to use their events here
                _recognizer = claryModes._recognizer;
                _recognizerSleep = claryModes._recognizerSleep;

                //Creating Events
                _recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(OnSpeechRecognition);
                _recognizerSleep.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(OnSpeechSleepRecognition);
                _clary.SpeakCompleted += new EventHandler<SpeakCompletedEventArgs>(claryModes.OnSpeakCompletion);
                _clary.SpeakStarted += new EventHandler<SpeakStartedEventArgs>(claryModes.OnSpeakStart);
                //Getting speech synthesizer from all commands and assigning the event SpeakCompleted to them so that recognition can be activate after to prevent duplicated recognitions
                foreach (Commands command in Commands) 
                {
                    command.getClary.SpeakCompleted += new EventHandler<SpeakCompletedEventArgs>(claryModes.OnSpeakCompletion);
                    command.getClary.SpeakStarted += new EventHandler<SpeakStartedEventArgs>(claryModes.OnSpeakStart);
                }
            }
            catch(Exception error)
            {
                errorMessage = new StringBuilder();
                errorMessage.AppendLine("Apparently something went wrong...");
                errorMessage.AppendLine("Error: " + error.Message);
                MessageBox.Show(errorMessage.ToString(), "Exception error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
        }

        private void OnSpeechRecognition(object sender, SpeechRecognizedEventArgs e)
        {
            foreach (Commands command in Commands)
            {
                string sCommandSemanticKey = command.SemanticKey; //Getting the SemanticKey from all the classes that inherit from commands with the foreach loop
                if (e.Result.Semantics.ContainsKey(sCommandSemanticKey)) //Verifying if the spoken speech SemanticKey match any of the SemanticKey variable values in all childrens in the list
                {
                    MessageDisplay = command.ExecuteCommand(e.Result.Semantics[sCommandSemanticKey].Value.ToString(), this, messageTimer); //Executing the method and saving the returned MessageDisplay object to a variable
                    sMessage = command.LabelMessage; //Returning the corresponding command message
                }
            }
        }

        private void OnSpeechSleepRecognition(object sender, SpeechRecognizedEventArgs e)
        {
            string sCommandSemanticKey = "claryModes"; //Give a fixed value to sCommandSemanticKey since it will have only 1 possible command to leave sleep mode
            if (e.Result.Semantics.ContainsKey(sCommandSemanticKey))
            {
                MessageDisplay = claryModes.UndoExecuteCommand(e.Result.Semantics[sCommandSemanticKey].Value.ToString(), this, messageTimer);
                sMessage = claryModes.LabelMessage;
            }
        }

        //Hide Clary from TAB applications as well as from task manager
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                // turn on WS_EX_TOOLWINDOW style bit
                cp.ExStyle |= 0x80;
                return cp;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.Location.X != 0) //If the X position from the window is not 0 it will continue to remove 1 from te current position until reach X = 0 because of the timer
            {
                this.Location = new Point(iCurrentClaryXPosition, this.Location.Y);
                iCurrentClaryXPosition--;
            }else if(this.Location.X == 0) //Otherwise, by reaching 0 it will turn the opacity to 0.7
                this.Opacity = 1;
            if (this.Location.Y != iCenterClaryVertically) //If the Y position from the window is not half of the screen continue to add 1 to the current position also because of the timer
            {
                this.Location = new Point(this.Location.X, iCurrentClaryYPosition);
                iCurrentClaryYPosition++;
            }
            if (this.Size.Width != 256 && this.Size.Height != 256) //If the width and height are both not equal to 256px it will continue to reduce the size
            {
                this.Size = new Size(iCurrentClaryWidth, iCurrentClaryHeight);
                iCurrentClaryWidth--;
                iCurrentClaryHeight--;
            }
        }
    }
}
