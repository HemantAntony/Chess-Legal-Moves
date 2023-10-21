using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Queen : ChessItem
{
    public Queen(string type, int row, int column) : base(type, row, column)
    {
    }

    public override void CalculateLegalMoves() // Make efficient
    {
        _possibleMoves.Clear();
        for (int row = _row + 1; row <= 7; row++)
        {
            if (!AddPosition(row, _col))
            {
                break;
            }
        }

        for (int row = _row - 1; row >= 0; row--)
        {
            if (!AddPosition(row, _col))
            {
                break;
            }
        }

        for (int column = _col + 1; column <= 7; column++)
        {
            if (!AddPosition(_row, column))
            {
                break;
            }
        }

        for (int column = _col - 1; column >= 0; column--)
        {
            if (!AddPosition(_row, column))
            {
                break;
            }
        }

        for (int row = _row + 1, column = _col + 1; row <= 7 && column <= 7; row++, column++)
        {
            if (!AddPosition(row, column))
            {
                break;
            }
        }

        for (int row = _row - 1, column = _col + 1; row >= 0 && column <= 7; row--, column++)
        {
            if (!AddPosition(row, column))
            {
                break;
            }
        }

        for (int row = _row - 1, column = _col - 1; row >= 0 && column >= 0; row--, column--)
        {
            if (!AddPosition(row, column))
            {
                break;
            }
        }

        for (int row = _row + 1, column = _col - 1; row <= 7 && column >= 0; row++, column--)
        {
            if (!AddPosition(row, column))
            {
                break;
            }
        }
    }

    public override void CalculateAttackMoves()
    {
        _attackMoves.Clear();
        for (int row = _row + 1; row <= 7; row++)
        {
            if (ChessItemAt(row, _col))
            {
                AddAttackPosition(row, _col);
                break;
            }
        }

        for (int row = _row - 1; row >= 0; row--)
        {
            if (ChessItemAt(row, _col))
            {
                AddAttackPosition(row, _col);
                break;
            }
        }

        for (int column = _col + 1; column <= 7; column++)
        {
            if (ChessItemAt(_row, column))
            {
                AddAttackPosition(_row, column);
                break;
            }
        }

        for (int column = _col - 1; column >= 0; column--)
        {
            if (ChessItemAt(_row, column))
            {
                AddAttackPosition(_row, column);
                break;
            }
        }

        for (int row = _row + 1, column = _col + 1; row <= 7 && column <= 7; row++, column++)
        {
            if (ChessItemAt(row, column))
            {
                AddAttackPosition(row, column);
                break;
            }
        }

        for (int row = _row - 1, column = _col + 1; row >= 0 && column <= 7; row--, column++)
        {
            if (ChessItemAt(row, column))
            {
                AddAttackPosition(row, column);
                break;
            }
        }

        for (int row = _row - 1, column = _col - 1; row >= 0 && column >= 0; row--, column--)
        {
            if (ChessItemAt(row, column))
            {
                AddAttackPosition(row, column);
                break;
            }
        }

        for (int row = _row + 1, column = _col - 1; row <= 7 && column >= 0; row++, column--)
        {
            if (ChessItemAt(row, column))
            {
                AddAttackPosition(row, column);
                break;
            }
        }
    }
}
