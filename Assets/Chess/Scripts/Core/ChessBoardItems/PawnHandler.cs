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
        _legalMoves.Clear();
        if (_row == 1)
        {
            for (int i = 0; i < 2; i++)
            {
                int row = _row + i + 1;
                if (!IsThereChessItemAt(row, _col))
                {
                    _legalMoves.Add(new int[] { row, _col }); // Use AddLegalPosition
                } else
                {
                    break;
                }
            }
        } else
        {
            int row = _row + 1;
            if (!IsThereChessItemAt(row, _col) && row <= 7)
            {
                _legalMoves.Add(new int[] { row, _col });
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
