using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Knight : ChessItem
{
    public Knight(string type, int row, int column) : base(type, row, column)
    {
    }

    public override void CalculateLegalMoves()
    {
        _possibleMoves.Clear();
        AddPosition(_row + 2, _column + 1);
        AddPosition(_row + 2, _column - 1);
        AddPosition(_row - 2, _column + 1);
        AddPosition(_row - 2, _column - 1);
        AddPosition(_row + 1, _column + 2);
        AddPosition(_row - 1, _column + 2);
        AddPosition(_row + 1, _column - 2);
        AddPosition(_row - 1, _column - 2);
    }

    public override void CalculateAttackMoves()
    {
        _attackMoves.Clear();
        AddAttackPosition(_row + 2, _column + 1);
        AddAttackPosition(_row + 2, _column - 1);
        AddAttackPosition(_row - 2, _column + 1);
        AddAttackPosition(_row - 2, _column - 1);
        AddAttackPosition(_row + 1, _column + 2);
        AddAttackPosition(_row - 1, _column + 2);
        AddAttackPosition(_row + 1, _column - 2);
        AddAttackPosition(_row - 1, _column - 2);
    }
}
