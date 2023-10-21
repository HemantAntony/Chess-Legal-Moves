using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Queen : ChessItem
{
    public Queen(ChessItemType type, int row, int col) : base(type, row, col)
    {
    }

    public override void CalculateLegalMoves()
    {
        _legalMoves.Clear();

        AddLegalPositions(Vector2Int.up);
        AddLegalPositions(Vector2Int.right);
        AddLegalPositions(Vector2Int.down);
        AddLegalPositions(Vector2Int.left);
        AddLegalPositions(new Vector2Int(1, 1));
        AddLegalPositions(new Vector2Int(-1, 1));
        AddLegalPositions(new Vector2Int(-1, -1));
        AddLegalPositions(new Vector2Int(1, -1));
    }

    public override void CalculateAttackMoves()
    {
        _attackMoves.Clear();

        AddAttackPositions(Vector2Int.up);
        AddAttackPositions(Vector2Int.right);
        AddAttackPositions(Vector2Int.down);
        AddAttackPositions(Vector2Int.left);
        AddAttackPositions(new Vector2Int(1, 1));
        AddAttackPositions(new Vector2Int(1, -1));
        AddAttackPositions(new Vector2Int(-1, -1));
        AddAttackPositions(new Vector2Int(-1, 1));
    }
}
