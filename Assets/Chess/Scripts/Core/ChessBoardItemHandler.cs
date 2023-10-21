using Chess.Scripts.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ChessItem // Add to name space Chess Core?, Move to different location
{
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

    static List<ChessItem> _chessItems = new List<ChessItem>();

    private ChessItemType _type;
    protected int _row, _col;
    protected List<int[]> _legalMoves = new List<int[]>();
    protected List<int[]> _attackMoves = new List<int[]>();

    public ChessItem(ChessItemType type, int row, int col)
    {
        _type = type;
        _row = row;
        _col = col;
        _chessItems.Add(this);
    }

    public ChessItemType GetChessItemType()
    {
        return _type;
    }

    public void SetPosition(int row, int col)
    {
        _row = row;
        _col = col;
    }

    public List<int[]> LegalMoves()
    {
        return _legalMoves;
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
        if (row < 0 || row > 7 || col < 0 || col > 7 || !IsThereChessItemAt(row, col) || GetChessItemAt(row, col).GetChessItemType() != ChessItem.ChessItemType.Enemy)
        {
            return;
        }
        _attackMoves.Add(new int[] { row, col });
    }
}

public class ChessBoardItemHandler : MonoBehaviour
{
    private static readonly Dictionary<string, ChessItem.ChessItemType> chessItemTypes = new Dictionary<string, ChessItem.ChessItemType>() {
        { "King", ChessItem.ChessItemType.King },
        { "Queen", ChessItem.ChessItemType.Queen },
        { "Bishop", ChessItem.ChessItemType.Bishop },
        { "Knight", ChessItem.ChessItemType.Knight },
        { "Rook", ChessItem.ChessItemType.Rook },
        { "Pawn", ChessItem.ChessItemType.Pawn },
        { "Enemy", ChessItem.ChessItemType.Enemy }
    };

    public static ChessItem.ChessItemType TagToChessItemType(string tag)
    {
        return chessItemTypes[tag];
    }

    public static ChessItem MakeChessItem(ChessItem.ChessItemType chessItemType, int row, int col)
    {
        switch (chessItemType)
        {
            case ChessItem.ChessItemType.Pawn:
                return new Pawn(chessItemType, row, col);
            case ChessItem.ChessItemType.King:
                return new King(chessItemType, row, col);
            case ChessItem.ChessItemType.Queen:
                return new Queen(chessItemType, row, col);
            case ChessItem.ChessItemType.Bishop:
                return new Bishop(chessItemType, row, col);
            case ChessItem.ChessItemType.Knight:
                return new Knight(chessItemType, row, col);
            case ChessItem.ChessItemType.Rook:
                return new Rook(chessItemType, row, col);
            case ChessItem.ChessItemType.Enemy:
                return new Enemy(chessItemType, row, col);
            default:
                break;
        }

        return null;
    }

    public static ChessItem MakeChessItem(string tag, int row, int col)
    {
        return MakeChessItem(TagToChessItemType(tag), row, col);
    }
}
