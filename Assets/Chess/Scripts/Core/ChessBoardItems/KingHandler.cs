using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class King : ChessItem
{
    public King(string type, int row, int column) : base(type, row, column)
    {
    }

    public override void CalculateLegalMoves() // Implement castling
    {
        AddPosition(_row + 1, _column - 1);
        AddPosition(_row + 1, _column);
        AddPosition(_row + 1, _column + 1);
        AddPosition(_row, _column + 1);
        AddPosition(_row - 1, _column + 1);
        AddPosition(_row - 1, _column);
        AddPosition(_row - 1, _column - 1);
        AddPosition(_row, _column - 1);
    }
}
