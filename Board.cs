using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chess.Enums;

namespace Chess
{
    class Board
    {
        public string Fen { get; private set; }
        Figure[,] Figures;
        public Color moveColor { get; private set; }
        public int moveNumber { get; private set;}
        public Board(string fen)
        {
            this.Fen = fen;
            Figures = new Figure[8, 8];
            Init();


        }

        void Init()
        {
            SetFigureAt(new Square("a1"), Figure.whiteKing);
            SetFigureAt(new Square("h8"), Figure.blackKing);
            moveColor = Color.white; 
        }

        public Figure GetFigureAt (Square square)
        {
            if (square.OnBoard())
                return Figures[square.x, square.y];
            return Figure.none;
        }

        void SetFigureAt(Square square, Figure figure)
        {
            if (square.OnBoard())
                Figures[square.x, square.y] = figure;
        }

        public Board Move (FigureMoving fm)
        {
            Board next = new Board(Fen);
            next.SetFigureAt(fm.From, Figure.none);
            next.SetFigureAt(fm.To, fm.PawnPromotion == Figure.none ? fm.Figure : fm.PawnPromotion);
            if (moveColor == Color.black)
                next.moveNumber++;
            next.moveColor = moveColor.FlipColor();
            return next;
        }
    }

}
