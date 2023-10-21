using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Knight : ChessItem
{
    public Knight(string type, int row, int col) : base(type, row, col)
    {
    }

    public override void CalculateLegalMoves()
    {
        _possibleMoves.Clear();
        AddPosition(_row + 2, _col + 1);
        AddPosition(_row + 2, _col - 1);
        AddPosition(_row - 2, _col + 1);
        AddPosition(_row - 2, _col - 1);
        AddPosition(_row + 1, _col + 2);
        AddPosition(_row - 1, _col + 2);
        AddPosition(_row + 1, _col - 2);
        AddPosition(_row - 1, _col - 2);
    }

    public override void CalculateAttackMoves()
    {
        _attackMoves.Clear();
        AddAttackPosition(_row + 2, _col + 1);
        AddAttackPosition(_row + 2, _col - 1);
        AddAttackPosition(_row - 2, _col + 1);
        AddAttackPosition(_row - 2, _col - 1);
        AddAttackPosition(_row + 1, _col + 2);
        AddAttackPosition(_row - 1, _col + 2);
        AddAttackPosition(_row + 1, _col - 2);
        AddAttackPosition(_row - 1, _col - 2);
    }
}
