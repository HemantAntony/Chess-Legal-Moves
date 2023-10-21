using Chess.Scripts.Core;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Bishop : ChessItem
{
    public Bishop(string type, int row, int col) : base(type, row, col)
    {
    }

    public override void CalculateLegalMoves()
    {
        _possibleMoves.Clear();
        for (int row = _row + 1, col = _col + 1; row <= 7 && col <= 7; row++, col++)
        {
            if (!AddPosition(row, col))
            {
                break;
            }
        }

        for (int row = _row - 1, col = _col + 1; row >= 0 && col <= 7; row--, col++)
        {
            if (!AddPosition(row, col))
            {
                break;
            }
        }

        for (int row = _row - 1, col = _col - 1; row >= 0 && col >= 0; row--, col--)
        {
            if (!AddPosition(row, col))
            {
                break;
            }
        }

        for (int row = _row + 1, col = _col - 1; row <= 7 && col >= 0; row++, col--)
        {
            if (!AddPosition(row, col))
            {
                break;
            }
        }
    }

    public override void CalculateAttackMoves()
    {
        _attackMoves.Clear();
        for (int row = _row + 1, col = _col + 1; row <= 7 && col <= 7; row++, col++)
        {
            if (ChessItemAt(row, col))
            {
                AddAttackPosition(row, col);
                break;
            }
        }

        for (int row = _row - 1, col = _col + 1; row >= 0 && col <= 7; row--, col++)
        {
            if (ChessItemAt(row, col))
            {
                AddAttackPosition(row, col);
                break;
            }
        }

        for (int row = _row - 1, col = _col - 1; row >= 0 && col >= 0; row--, col--)
        {
            if (ChessItemAt(row, col))
            {
                AddAttackPosition(row, col);
                break;
            }
        }

        for (int row = _row + 1, col = _col - 1; row <= 7 && col >= 0; row++, col--)
        {
            if (ChessItemAt(row, col))
            {
                AddAttackPosition(row, col);
                break;
            }
        }
    }
}
