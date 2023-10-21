using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class King : ChessItem
{
    public King(string type, int row, int col) : base(type, row, col)
    {
    }

    public override void CalculateLegalMoves()
    {
        _possibleMoves.Clear();
        AddPosition(_row + 1, _col - 1);
        AddPosition(_row + 1, _col);
        AddPosition(_row + 1, _col + 1);
        AddPosition(_row, _col + 1);
        AddPosition(_row - 1, _col + 1);
        AddPosition(_row - 1, _col);
        AddPosition(_row - 1, _col - 1);
        AddPosition(_row, _col - 1);

        if (_row == 0) // Castling
        {
            for (int col = _col - 1; col >= 0; col--)
            {
                if (col == 0 && GetChessItemAt(_row, col).GetChessItemAtType() == "Rook")
                {
                    AddPosition(_row, 2);
                } else if (IsThereChessItemAt(_row, col))
                {
                    break;
                }
            }

            for (int col = _col + 1; col <= 7; col++)
            {
                if (col == 7 && GetChessItemAt(_row, col).GetChessItemAtType() == "Rook")
                {
                    AddPosition(_row, 6);
                } else if (IsThereChessItemAt(_row, col))
                {
                    break;
                }
            }
        }
    }

    public override void CalculateAttackMoves()
    {
        _attackMoves.Clear();
        AddAttackPosition(_row + 1, _col - 1);
        AddAttackPosition(_row + 1, _col);
        AddAttackPosition(_row + 1, _col + 1);
        AddAttackPosition(_row, _col + 1);
        AddAttackPosition(_row - 1, _col + 1);
        AddAttackPosition(_row - 1, _col);
        AddAttackPosition(_row - 1, _col - 1);
        AddAttackPosition(_row, _col - 1);
    }
}
