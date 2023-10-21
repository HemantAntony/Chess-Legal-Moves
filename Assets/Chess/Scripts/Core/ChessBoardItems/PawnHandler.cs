using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Pawn : ChessItem
{
    public Pawn(string type, int row, int col):base(type, row, col)
    {
    }

    public override void CalculateLegalMoves() // Implement pawn promotion?
    {        
        _possibleMoves.Clear();
        if (_row == 1)
        {
            for (int i = 0; i < 2; i++)
            {
                int row = _row + i + 1;
                if (!ChessItemAt(row, _col))
                {
                    _possibleMoves.Add(new int[] { row, _col });
                } else
                {
                    break;
                }
            }
        } else
        {
            int row = _row + 1;
            if (!ChessItemAt(row, _col) && row <= 7)
            {
                _possibleMoves.Add(new int[] { row, _col });
            }
        }
    }

    public override void CalculateAttackMoves()
    {
        _attackMoves.Clear();
        AddAttackPosition(_row + 1, _col + 1);
        AddAttackPosition(_row + 1, _col - 1);
    }
}
