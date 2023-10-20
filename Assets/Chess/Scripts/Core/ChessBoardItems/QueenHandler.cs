using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Queen : ChessItem
{
    public Queen(string type, int row, int column) : base(type, row, column)
    {
    }

    public override void CalculateLegalMoves() // Make efficient
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

        for (int row = _row + 1, column = _column + 1; row <= 7 && column <= 7; row++, column++)
        {
            if (!AddPosition(row, column))
            {
                break;
            }
        }

        for (int row = _row - 1, column = _column + 1; row >= 0 && column <= 7; row--, column++)
        {
            if (!AddPosition(row, column))
            {
                break;
            }
        }

        for (int row = _row - 1, column = _column - 1; row >= 0 && column >= 0; row--, column--)
        {
            if (!AddPosition(row, column))
            {
                break;
            }
        }

        for (int row = _row + 1, column = _column - 1; row <= 7 && column >= 0; row++, column--)
        {
            if (!AddPosition(row, column))
            {
                break;
            }
        }
    }
}
