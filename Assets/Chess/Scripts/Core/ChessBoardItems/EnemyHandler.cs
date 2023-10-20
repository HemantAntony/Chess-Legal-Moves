using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Enemy : ChessItem
{
    public Enemy(string type, int row, int column):base(type, row, column)
    {
    }

    public override void CalculateLegalMoves() // Find better way to implement this
    {
    }

    public override void CalculateAttackMoves()
    {
    }
}
