using Chess.Scripts.Core;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Bishop : ChessItem
{
    public Bishop(ChessItemType type, int row, int col) : base(type, row, col)
    {
    }

    public override void CalculateLegalMoves()
    {
        _legalMoves.Clear();

        AddLegalPositions(new Vector2Int(1, 1));
        AddLegalPositions(new Vector2Int(-1, 1));
        AddLegalPositions(new Vector2Int(-1, -1));
        AddLegalPositions(new Vector2Int(1, -1));
    }

    public override void CalculateAttackMoves()
    {
        _attackMoves.Clear();

        AddAttackPositions(new Vector2Int(1, 1));
        AddAttackPositions(new Vector2Int(1, -1));
        AddAttackPositions(new Vector2Int(-1, -1));
        AddAttackPositions(new Vector2Int(-1, 1));
    }
}
