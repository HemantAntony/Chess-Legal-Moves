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
            for (int column = _col - 1; column >= 0; column--)
            {
                if (column == 0 && GetChessItem(_row, column).GetChessItemType() == "Rook")
                {
                    AddPosition(_row, 2);
                } else if (ChessItemAt(_row, column))
                {
                    break;
                }
            }

            for (int column = _col + 1; column <= 7; column++)
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
