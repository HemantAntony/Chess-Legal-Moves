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
        AddPosition(_row + 2, _column + 1);
        AddPosition(_row + 2, _column - 1);
        AddPosition(_row - 2, _column + 1);
        AddPosition(_row - 2, _column - 1);
        AddPosition(_row + 1, _column + 2);
        AddPosition(_row - 1, _column + 2);
        AddPosition(_row + 1, _column - 2);
        AddPosition(_row - 1, _column - 2);
    }
}
