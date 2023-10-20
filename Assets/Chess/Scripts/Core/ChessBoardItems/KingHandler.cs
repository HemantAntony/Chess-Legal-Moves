using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class King : ChessItem
{
    public King(string type, int row, int column) : base(type, row, column)
    {
    }

    public override void CalculateLegalMoves()
    {
        AddPosition(_row + 1, _column - 1);
        AddPosition(_row + 1, _column);
        AddPosition(_row + 1, _column + 1);
        AddPosition(_row, _column + 1);
        AddPosition(_row - 1, _column + 1);
        AddPosition(_row - 1, _column);
        AddPosition(_row - 1, _column - 1);
        AddPosition(_row, _column - 1);

        if (_row == 0) // Castling
        {
            for (int column = _column - 1; column >= 0; column--)
            {
                if (column == 0 && GetChessItem(_row, column).GetChessItemType() == "Rook")
                {
                    AddPosition(_row, 2);
                } else if (ChessItemAt(_row, column))
                {
                    break;
                }
            }

            for (int column = _column + 1; column <= 7; column++)
            {
                if (column == 7 && GetChessItem(_row, column).GetChessItemType() == "Rook")
                {
                    AddPosition(_row, 6);
                } else if (ChessItemAt(_row, column))
                {
                    break;
                }
            }
        }
    }
}
