using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Enemy : ChessItem
{
    public Enemy(ChessItemType type, int row, int col):base(type, row, col)
    {
    }

    public override void CalculateLegalMoves()
    {
    }

    public override void CalculateAttackMoves()
    {
    }
}
