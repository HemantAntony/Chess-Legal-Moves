using Chess.Scripts.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ChessItem // Add to name space Chess Core?, Move to different location
{
    protected ChessItemType _type;
    protected int _row, _col;
    protected List<int[]> _legalMoves = new List<int[]>();
    protected List<int[]> _attackMoves = new List<int[]>();

    private static List<ChessItem> _chessItems = new List<ChessItem>();
    private static readonly Dictionary<string, ChessItemType> chessItemTypes = new Dictionary<string, ChessItemType>() {
        { "King", ChessItemType.King },
        { "Queen", ChessItemType.Queen },
        { "Bishop", ChessItemType.Bishop },
        { "Knight", ChessItemType.Knight },
        { "Rook", ChessItemType.Rook },
        { "Pawn", ChessItemType.Pawn },
        { "Enemy", ChessItemType.Enemy }
    };

    public ChessItem(ChessItemType type, int row, int col)
    {
        _type = type;
        _row = row;
        _col = col;
        _chessItems.Add(this);
    }

    public enum ChessItemType
    {
        King,
        Queen,
        Bishop,
        Knight,
        Rook,
        Pawn,
        Enemy
    }

    public static ChessItemType TagToChessItemType(string tag)
    {
        return chessItemTypes[tag];
    }

    public static ChessItem New(ChessItemType chessItemType, int row, int col)
    {
        switch (chessItemType)
        {
            case ChessItemType.Pawn:
                return new Pawn(chessItemType, row, col);
            case ChessItemType.King:
                return new King(chessItemType, row, col);
            case ChessItemType.Queen:
                return new Queen(chessItemType, row, col);
            case ChessItemType.Bishop:
                return new Bishop(chessItemType, row, col);
            case ChessItemType.Knight:
                return new Knight(chessItemType, row, col);
            case ChessItemType.Rook:
                return new Rook(chessItemType, row, col);
            case ChessItemType.Enemy:
                return new Enemy(chessItemType, row, col);
            default:
                break;
        }

        return null;
    }

    public static ChessItem New(string tag, int row, int col)
    {
        return New(TagToChessItemType(tag), row, col);
    }

    public static ChessItem GetChessItemAt(int row, int col) // Incorporate with IsThereChessItemAt
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

    public static bool IsThereChessItemAt(int row, int col)
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

    public ChessItemType GetChessItemType()
    {
        return _type;
    }

    public List<int[]> LegalMoves()
    {
        return _legalMoves;
    }

    public List<int[]> AttackMoves()
    {
        return _attackMoves;
    }

    public void SetPosition(int row, int col)
    {
        _row = row;
        _col = col;
    }

    protected bool AddLegalPosition(int row, int col)
    {
        if (row >= 0 && row <= 7 && col >= 0 && col <= 7 && !IsThereChessItemAt(row, col))
        {
            _legalMoves.Add(new int[] { row, col });
            return true;
        }
        return false;
    }

    protected void AddAttackPosition(int row, int col)
    {
        if (row < 0 || row > 7 || col < 0 || col > 7 || !IsThereChessItemAt(row, col) || GetChessItemAt(row, col).GetChessItemType() != ChessItemType.Enemy)
        {
            return;
        }
        _attackMoves.Add(new int[] { row, col });
    }

    public abstract void CalculateLegalMoves();
    public abstract void CalculateAttackMoves();
}
