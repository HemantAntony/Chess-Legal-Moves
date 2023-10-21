using Chess.Scripts.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ChessItem // Add to name space Chess Core?
{
    static List<ChessItem> _chessItems = new List<ChessItem>();

    private string _type; // Implement Enum
    protected int _row, _col;
    protected List<int[]> _possibleMoves = new List<int[]>();
    protected List<int[]> _attackMoves = new List<int[]>();

    public ChessItem(string type, int row, int col)
    {
        _type = type;
        _row = row;
        _col = col;
        _chessItems.Add(this);
    }

    public string GetChessItemAtType()
    {
        return _type;
    }

    public void SetPosition(int row, int col)
    {
        _row = row;
        _col = col;
    }

    public List<int[]> PossibleMoves()
    {
        return _possibleMoves;
    }

    public List<int[]> AttackMoves()
    {
        return _attackMoves;
    }

    public abstract void CalculateLegalMoves();
    public abstract void CalculateAttackMoves();

    public static ChessItem GetChessItemAt(int row, int col) // Move function? Incorporate with IsThereChessItemAt
    {
        foreach (ChessItem chessItem in _chessItems)
        {
            if (chessItem._row == row && chessItem._col == col)
            {
                return chessItem;
            }
        }
        return null;
    }

    public static bool IsThereChessItemAt(int row, int col) // Move function?
    {
        foreach (ChessItem chessItem in _chessItems)
        {
            if (chessItem._row == row && chessItem._col == col)
            {
                return true;
            }
        }
        return false;
    }

    protected bool AddPosition(int row, int col) // Rename?
    {
        if (row >= 0 && row <= 7 && col >= 0 && col <= 7 && !IsThereChessItemAt(row, col))
        {
            _possibleMoves.Add(new int[] { row, col });
            return true;
        }
        return false;
    }

    protected void AddAttackPosition(int row, int col)
    {
        if (row < 0 || row > 7 || col < 0 || col > 7 || !IsThereChessItemAt(row, col) || GetChessItemAt(row, col).GetChessItemAtType() != "Enemy")
        {
            return;
        }
        _attackMoves.Add(new int[] { row, col });
    }
}

public class ChessBoardItemHandler : MonoBehaviour
{
    public static ChessItem MakeChessItem(string tag, int row, int col)
    {
        switch (tag)
        {
            case "Pawn":
                return new Pawn(tag, row, col);
            case "King":
                return new King(tag, row, col);
            case "Queen":
                return new Queen(tag, row, col);
            case "Bishop":
                return new Bishop(tag, row, col);
            case "Knight":
                return new Knight(tag, row, col);
            case "Rook":
                return new Rook(tag, row, col);
            case "Enemy":
                return new Enemy(tag, row, col);
            default:
                break;
        }

        return null;
    }
}
