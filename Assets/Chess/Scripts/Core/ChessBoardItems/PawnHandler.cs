using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Pawn : ChessItem
{
    public Pawn(string type, int row, int col):base(type, row, col)
    {
    }

    public override void CalculateLegalMoves()
    {        
        _legalMoves.Clear();
        if (_row == 1)
        {
            for (int i = 0; i < 2; i++)
            {
                if (!AddLegalPosition(_row + i + 1, _col))
                {
                    break;
                }
            }
        } else
        {
            AddLegalPosition(_row + 1, _col);
        }
    }

    public override void CalculateAttackMoves()
    {
        _attackMoves.Clear();
        AddAttackPosition(_row + 1, _col + 1);
        AddAttackPosition(_row + 1, _col - 1);
    }
}
