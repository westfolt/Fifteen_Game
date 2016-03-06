using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.TextFormatting;

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
        }
        

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
        }
        

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
                default:
                    button = mainWindow.Button_1;
                    break;
            }
        }
    }
}
