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

        public Model()
        {
            NewGame();
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
    }
}
