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
        for (int row = _row + 1; row <= 7; row++)
        {
            if (IsThereChessItemAt(row, _col))
            {
                AddAttackPosition(row, _col);
                break;
            }
        }

        for (int row = _row - 1; row >= 0; row--)
        {
            if (IsThereChessItemAt(row, _col))
            {
                AddAttackPosition(row, _col);
                break;
            }
        }

        for (int col = _col + 1; col <= 7; col++)
        {
            if (IsThereChessItemAt(_row, col))
            {
                AddAttackPosition(_row, col);
                break;
            }
        }

        for (int col = _col - 1; col >= 0; col--)
        {
            if (IsThereChessItemAt(_row, col))
            {
                AddAttackPosition(_row, col);
                break;
            }
        }

        for (int row = _row + 1, col = _col + 1; row <= 7 && col <= 7; row++, col++)
        {
            if (IsThereChessItemAt(row, col))
            {
                AddAttackPosition(row, col);
                break;
            }
        }

        for (int row = _row - 1, col = _col + 1; row >= 0 && col <= 7; row--, col++)
        {
            if (IsThereChessItemAt(row, col))
            {
                AddAttackPosition(row, col);
                break;
            }
        }

        for (int row = _row - 1, col = _col - 1; row >= 0 && col >= 0; row--, col--)
        {
            if (IsThereChessItemAt(row, col))
            {
                AddAttackPosition(row, col);
                break;
            }
        }

        for (int row = _row + 1, col = _col - 1; row <= 7 && col >= 0; row++, col--)
        {
            if (IsThereChessItemAt(row, col))
            {
                AddAttackPosition(row, col);
                break;
            }
        }
    }
}
