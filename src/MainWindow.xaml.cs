﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Fifteen_Game
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Controller controller = new Controller(this);
        }
        //delegate for events handling
        private EventHandler numberClick;
        private EventHandler newGameClick;

        //events
        public event EventHandler NumberClick
        {
            add { numberClick += value; }
            remove { numberClick -= value; }
        }
        public event EventHandler NewGameClick
        {
            add { newGameClick += value; }
            remove { newGameClick -= value; }
        }

        private void NumClick(object sender, RoutedEventArgs e)
        {
            numberClick.Invoke(sender, e);
        }

        private void NewGame_OnClick(object sender, RoutedEventArgs e)
        {
            newGameClick.Invoke(sender,e);
        }

        private void About_OnClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                "Your objective is to place the tiles in oerder by making " +
                "sliding moves that use the empty space");
        }
        private void Exit_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
