using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Fifteen_Game
{
    class Model
    {
        private int numberOfMoves;
        private Random rand;

        public Model()
        {
            rand = new Random(DateTime.Now.Millisecond);
            NewGame();
        }

        public int NumberOfMoves
        {
            get { return numberOfMoves; }
        }

        public void NewGame()
        {
            numberOfMoves = 0;
        }

        public bool IsClose(Button buttonToDeside, Button EmptyButton)
        {
            numberOfMoves++;
            //returns direction from buttonToDeside to EmptyButton if it is close
            if ((Canvas.GetLeft(buttonToDeside) - 75) == Canvas.GetLeft(EmptyButton) &&
                Canvas.GetTop(buttonToDeside) == Canvas.GetTop(EmptyButton))
                return true;
            if ((Canvas.GetLeft(buttonToDeside) + 75) == Canvas.GetLeft(EmptyButton) &&
                Canvas.GetTop(buttonToDeside) == Canvas.GetTop(EmptyButton))
                return true;
            if ((Canvas.GetTop(buttonToDeside) - 75) == Canvas.GetTop(EmptyButton) &&
                Canvas.GetLeft(buttonToDeside) == Canvas.GetLeft(EmptyButton))
                return true;
            if ((Canvas.GetTop(buttonToDeside) + 75) == Canvas.GetTop(EmptyButton) &&
                Canvas.GetLeft(buttonToDeside) == Canvas.GetLeft(EmptyButton))
                return true;

            return false;
        }
        public string[] Shuffle()
        {
            string[] result = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", " " };
            for (int i = 0; i < result.Length; i++)
            {
                int j = rand.Next(15);
                string temp = result[j];
                result[j] = result[i];
                result[i] = temp;
            }

            return result;
        }
    }
}
