using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.TextFormatting;
using System.Threading;

namespace Fifteen_Game
{
    class Controller
    {
        private Model model;
        private MainWindow mainWindow;

        //constructor
        public Controller(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
            model = new Model();
            
            //subscribing to events
            this.mainWindow.NumberClick += mainWindow_NumberClick;
            this.mainWindow.NewGameClick += mainWindow_NewGameClick;
            ////thread for counter displaying in statusbar
            //Thread threadBottom = new Thread(CounterDisplay);
            //threadBottom.Start();
        }

        //display of counter in statusBar
        void CounterDisplay()
        {
            mainWindow.NumberOfMoves.Text = "Number of moves: " + model.NumberOfMoves;
        }

        //event handlers
        void mainWindow_NumberClick(object sender, EventArgs e)
        {
            //getting reference to clicked button
            Button buttonClicked = new Button();
            GetButton(((Button)sender).Content.ToString(),out buttonClicked);
            
            //deciding, if it is close to empty cell
            if (model.IsClose(buttonClicked, mainWindow.Button_Free_Cell))
            {
                //if true - exchange button places
                Exchanger(ref buttonClicked, ref mainWindow.Button_Free_Cell);
            }
            if (EnsureComleteness())
                GameCompleted();

            CounterDisplay();
        }
        void mainWindow_NewGameClick(object sender, EventArgs e)
        {
            Buttons_Shuffler();
            model.NewGame();
            CounterDisplay();
        }

        void GameCompleted()
        {
            MessageBox.Show("You completed this gameand done " + model.NumberOfMoves + "moves");
            model.NewGame();
            CounterDisplay();
        }

        bool EnsureComleteness()
        {
            if (Canvas.GetTop(mainWindow.Button_1) == 10 && Canvas.GetTop(mainWindow.Button_2) == 10 &&
                Canvas.GetTop(mainWindow.Button_3) == 10 && Canvas.GetTop(mainWindow.Button_4) == 10
                && Canvas.GetTop(mainWindow.Button_5) == 85 && Canvas.GetTop(mainWindow.Button_6) == 85 &&
                Canvas.GetTop(mainWindow.Button_7) == 85 && Canvas.GetTop(mainWindow.Button_8) == 85
                && Canvas.GetTop(mainWindow.Button_9) == 160 && Canvas.GetTop(mainWindow.Button_10) == 160 &&
                Canvas.GetTop(mainWindow.Button_11) == 160 && Canvas.GetTop(mainWindow.Button_12) == 160
                && Canvas.GetTop(mainWindow.Button_13) == 235 && Canvas.GetTop(mainWindow.Button_14) == 235 &&
                Canvas.GetTop(mainWindow.Button_15) == 235 &&
                Canvas.GetLeft(mainWindow.Button_1) == 10 && Canvas.GetLeft(mainWindow.Button_2) == 85 &&
                Canvas.GetLeft(mainWindow.Button_3) == 160 && Canvas.GetLeft(mainWindow.Button_4) == 235
                && Canvas.GetLeft(mainWindow.Button_5) == 10 && Canvas.GetLeft(mainWindow.Button_6) == 85 &&
                Canvas.GetLeft(mainWindow.Button_7) == 160 && Canvas.GetLeft(mainWindow.Button_8) == 235
                && Canvas.GetLeft(mainWindow.Button_9) == 10 && Canvas.GetLeft(mainWindow.Button_10) == 85 &&
                Canvas.GetLeft(mainWindow.Button_11) == 160 && Canvas.GetLeft(mainWindow.Button_12) == 235
                && Canvas.GetLeft(mainWindow.Button_13) == 10 && Canvas.GetLeft(mainWindow.Button_14) == 85 &&
                Canvas.GetLeft(mainWindow.Button_15) == 160)
                return true;

            return false;
        }
        //shuffles all buttons on the field
        void Buttons_Shuffler()
        {
            string[] positions = model.Shuffle();
            //for button anf coordinates references
            Button tempButton = new Button();
            double Top = 0;
            double Left = 0;

            for (int i = 0; i < positions.Length; i++)
            {
                GetButton(positions[i],out tempButton);
                GetPosition((i+1).ToString(),out Top, out Left);
                Canvas.SetTop(tempButton, Top);
                Canvas.SetLeft(tempButton,Left);
            }
        }
        //excanges places of two buttons
        void Exchanger(ref Button buttonToCheck1, ref Button buttonToCheck2)
        {
            double Top = Canvas.GetTop(buttonToCheck1);
            double Left = Canvas.GetLeft(buttonToCheck1);
            Canvas.SetTop(buttonToCheck1,Canvas.GetTop(buttonToCheck2));
            Canvas.SetLeft(buttonToCheck1, Canvas.GetLeft(buttonToCheck2));
            Canvas.SetTop(buttonToCheck2, Top);
            Canvas.SetLeft(buttonToCheck2,Left);
        }
        //getting button reference
        void GetButton(string Content,out Button button)
        {
            switch (Content)
            {
                case "1":
                    button = mainWindow.Button_1;
                    break;
                case "2":
                    button = mainWindow.Button_2;
                    break;
                case "3":
                    button = mainWindow.Button_3;
                    break;
                case "4":
                    button = mainWindow.Button_4;
                    break;
                case "5":
                    button = mainWindow.Button_5;
                    break;
                case "6":
                    button = mainWindow.Button_6;
                    break;
                case "7":
                    button = mainWindow.Button_7;
                    break;
                case "8":
                    button = mainWindow.Button_8;
                    break;
                case "9":
                    button = mainWindow.Button_9;
                    break;
                case "10":
                    button = mainWindow.Button_10;
                    break;
                case "11":
                    button = mainWindow.Button_11;
                    break;
                case "12":
                    button = mainWindow.Button_12;
                    break;
                case "13":
                    button = mainWindow.Button_13;
                    break;
                case "14":
                    button = mainWindow.Button_14;
                    break;
                case "15":
                    button = mainWindow.Button_15;
                    break;
                    //added for buttons shuffle
                case " ":
                    button = mainWindow.Button_Free_Cell;
                    break;
                default:
                    button = mainWindow.Button_1;
                    break;
            }
        }

        //get position markers for button
        void GetPosition(string Content, out double Top, out double Left)
        {
            switch (Content)
            {
                case "1":
                    Top = 10;
                    Left = 10;
                    break;
                case "2":
                    Top = 10;
                    Left = 85;
                    break;
                case "3":
                    Top = 10;
                    Left = 160;
                    break;
                case "4":
                    Top = 10;
                    Left = 235;
                    break;
                case "5":
                    Top = 85;
                    Left = 10;
                    break;
                case "6":
                    Top = 85;
                    Left = 85;
                    break;
                case "7":
                    Top = 85;
                    Left = 160;
                    break;
                case "8":
                    Top = 85;
                    Left = 235;
                    break;
                case "9":
                    Top = 160;
                    Left = 10;
                    break;
                case "10":
                    Top = 160;
                    Left = 85;
                    break;
                case "11":
                    Top = 160;
                    Left = 160;
                    break;
                case "12":
                    Top = 160;
                    Left = 235;
                    break;
                case "13":
                    Top = 235;
                    Left = 10;
                    break;
                case "14":
                    Top = 235;
                    Left = 85;
                    break;
                case "15":
                    Top = 235;
                    Left = 160;
                    break;
                case "16":
                    Top = 235;
                    Left = 235;
                    break;
                default:
                    Top = 10;
                    Left = 10;
                    break;
            }
        }
    }
}
