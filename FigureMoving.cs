﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class FigureMoving
    {
        public Figure Figure { get; private set; }
        public Square From { get; private set; }
        public Square To { get; private set; }
        public Figure PawnPromotion { get; private set; }

        public FigureMoving (FigureOnSquare fs, Square to, Figure promotion = Figure.none)
        {
            this.Figure = fs.Figure;
            this.From = fs.Square;
            this.To = to;
            this.PawnPromotion = promotion;
        }
        FigureMoving(string move)
        {
            this.Figure = (Figure)move[0];
            this.From = new Square(move.Substring(1, 2));
            this.To = new Square(move.Substring(3, 2));
            this.PawnPromotion = (move.Length == 6) ? (Figure)move[5] : Figure.none;
        }
    }
}
