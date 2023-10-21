using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Rook : ChessItem
{
    public Rook(string type, int row, int col) : base(type, row, col)
    {
    }

    public override void CalculateLegalMoves()
    {
        _legalMoves.Clear();
        for (int row = _row + 1; row <= 7; row++)
        {
            if (!AddLegalPosition(row, _col))
            {
                break;
            }
        }

        for (int row = _row - 1; row >= 0; row--)
        {
            if (!AddLegalPosition(row, _col))
            {
                break;
            }
        }

        for (int col = _col + 1; col <= 7; col++)
        {
            if (!AddLegalPosition(_row, col))
            {
                break;
            }
        }

        for (int col = _col - 1; col >= 0; col--)
        {
            if (!AddLegalPosition(_row, col))
            {
                break;
            }
        }
    }

    public override void CalculateAttackMoves()
    {
        _attackMoves.Clear();
        for (int row = _row + 1; row <= 7; row++)
        {
            if (IsThereChessItemAt(row, _col))
            {
                AddAttackPosition(row, _col);
                break;
            }
        }

        for (int row = _row - 1; row >= 0; row--)
        {
            if (IsThereChessItemAt(row, _col))
            {
                AddAttackPosition(row, _col);
                break;
            }
        }

        for (int col = _col + 1; col <= 7; col++)
        {
            if (IsThereChessItemAt(_row, col))
            {
                AddAttackPosition(_row, col);
                break;
            }
        }

        for (int col = _col - 1; col >= 0; col--)
        {
            if (IsThereChessItemAt(_row, col))
            {
                AddAttackPosition(_row, col);
                break;
            }
        }
    }
}
