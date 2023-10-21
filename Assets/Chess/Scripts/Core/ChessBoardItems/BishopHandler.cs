using Chess.Scripts.Core;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Bishop : ChessItem
{
    public Bishop(string type, int row, int column) : base(type, row, column)
    {
    }

    public override void CalculateLegalMoves()
    {
        _possibleMoves.Clear();
        for (int row = _row + 1, column = _col + 1; row <= 7 && column <= 7; row++, column++)
        {
            if (!AddPosition(row, column))
            {
                break;
            }
        }

        for (int row = _row - 1, column = _col + 1; row >= 0 && column <= 7; row--, column++)
        {
            if (!AddPosition(row, column))
            {
                break;
            }
        }

        for (int row = _row - 1, column = _col - 1; row >= 0 && column >= 0; row--, column--)
        {
            if (!AddPosition(row, column))
            {
                break;
            }
        }

        for (int row = _row + 1, column = _col - 1; row <= 7 && column >= 0; row++, column--)
        {
            if (!AddPosition(row, column))
            {
                break;
            }
        }
    }

    public override void CalculateAttackMoves()
    {
        _attackMoves.Clear();
        for (int row = _row + 1, column = _col + 1; row <= 7 && column <= 7; row++, column++)
        {
            if (ChessItemAt(row, column))
            {
                AddAttackPosition(row, column);
                break;
            }
        }

        for (int row = _row - 1, column = _col + 1; row >= 0 && column <= 7; row--, column++)
        {
            if (ChessItemAt(row, column))
            {
                AddAttackPosition(row, column);
                break;
            }
        }

        for (int row = _row - 1, column = _col - 1; row >= 0 && column >= 0; row--, column--)
        {
            if (ChessItemAt(row, column))
            {
                AddAttackPosition(row, column);
                break;
            }
        }

        for (int row = _row + 1, column = _col - 1; row <= 7 && column >= 0; row++, column--)
        {
            if (ChessItemAt(row, column))
            {
                AddAttackPosition(row, column);
                break;
            }
        }
    }
}
