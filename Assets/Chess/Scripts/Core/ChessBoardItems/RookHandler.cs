using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Rook : ChessItem
{
    public Rook(string type, int row, int column) : base(type, row, column)
    {
    }

    public override void CalculateLegalMoves()
    {
        for (int row = _row + 1; row <= 7; row++)
        {
            if (!AddPosition(row, _column))
            {
                break;
            }
        }

        for (int row = _row - 1; row >= 0; row--)
        {
            if (!AddPosition(row, _column))
            {
                break;
            }
        }

        for (int column = _column + 1; column <= 7; column++)
        {
            if (!AddPosition(_row, column))
            {
                break;
            }
        }

        for (int column = _column - 1; column >= 0; column--)
        {
            if (!AddPosition(_row, column))
            {
                break;
            }
        }
    }
}
