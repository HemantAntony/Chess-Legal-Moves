using System;
using UnityEngine;
using System.Diagnostics.CodeAnalysis;
using Chess.Scripts.Core;
using System.Data;
using System.Collections;
using System.Collections.Generic;

[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
public sealed class ChessBoardPlacementHandler : MonoBehaviour {
    [SerializeField] private GameObject[] _rowsArray;
    [SerializeField] private GameObject _highlightPrefab;

    [SerializeField] private Vector4[] _preMoves;

    private GameObject[,] _chessBoard;

    internal static ChessBoardPlacementHandler Instance;

    private void Awake() {
        Instance = this;
        GenerateArray();
    }

    private void GenerateArray() {
        _chessBoard = new GameObject[8, 8];
        for (var i = 0; i < 8; i++) {
            for (var j = 0; j < 8; j++) {
                _chessBoard[i, j] = _rowsArray[i].transform.GetChild(j).gameObject;
            }
        }
    }

    internal GameObject GetTile(int i, int j) {
        try {
            return _chessBoard[i, j];
        } catch (Exception) {
            Debug.LogError("Invalid row or column.");
            return null;
        }
    }

    internal void Highlight(int row, int col) {
        var tile = GetTile(row, col).transform;
        if (tile == null) {
            Debug.LogError("Invalid row or column.");
            return;
        }

        Instantiate(_highlightPrefab, tile.transform.position, Quaternion.identity, tile.transform);
    }

    internal void ClearHighlights() {
        for (var i = 0; i < 8; i++) {
            for (var j = 0; j < 8; j++) {
                var tile = GetTile(i, j);
                if (tile.transform.childCount <= 0) continue;
                foreach (Transform childTransform in tile.transform) {
                    Destroy(childTransform.gameObject);
                }
            }
        }
    }


    private void MovePieceHandler(ChessPlayerPlacementHandler item, int row, int col) // Fix column to col
    {
        item.row = row;
        item.column = col;
        item.UpdatePosition();
        item.ChessItem().SetPosition(row, col);
    }

    private void Start()
    {
        StartCoroutine(MovePositions());
    }

    private IEnumerator MovePositions()
    {
        yield return new WaitForSeconds(0.5f);

        foreach(Vector4 preMove in _preMoves)
        {
            MovePieceHandler(ChessPlayerPlacementHandler.GetHandler((int) preMove.x, (int) preMove.y), (int) preMove.z, (int) preMove.w);
        }
    }

    #region Highlight Testing

    // private void Start() {
    //     StartCoroutine(Testing());
    // }

    // private IEnumerator Testing() {
    //     Highlight(2, 7);
    //     yield return new WaitForSeconds(1f);
    //
    //     ClearHighlights();
    //     Highlight(2, 7);
    //     Highlight(2, 6);
    //     Highlight(2, 5);
    //     Highlight(2, 4);
    //     yield return new WaitForSeconds(1f);
    //
    //     ClearHighlights();
    //     Highlight(7, 7);
    //     Highlight(2, 7);
    //     yield return new WaitForSeconds(1f);
    // }

    #endregion
}