using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Chess.Scripts.Core {
    public class ChessPlayerPlacementHandler : MonoBehaviour {
        [SerializeField] public int row, column;

        ChessItem _item;

        private static List<ChessPlayerPlacementHandler> _handlers = new List<ChessPlayerPlacementHandler>();

        public static ChessPlayerPlacementHandler GetHandler(int requiredRow, int requiredCol)
        {
            foreach(ChessPlayerPlacementHandler handler in _handlers)
            {
                if (handler.row == requiredRow && handler.column == requiredCol)
                {
                    return handler;
                }
            }

            return null;
        }

        public void UpdatePosition()
        {
            transform.position = ChessBoardPlacementHandler.Instance.GetTile(row, column).transform.position;
        }

        public ChessItem Item()
        {
            return _item;
        }

        private void Start() {
            UpdatePosition();
            _item = ChessItem.New(gameObject.tag, row, column);
            _handlers.Add(this);
        }

        private void OnMouseDown()
        {
            ChessBoardPlacementHandler.Instance.ClearHighlights();
            if (_item != null)
            {
                _item.CalculateLegalMoves();
                _item.CalculateAttackMoves();
                foreach (int[] coordinate in _item.LegalMoves())
                {
                    ChessBoardPlacementHandler.Instance.Highlight(coordinate[0], coordinate[1]);
                }
                foreach (int[] coordinate in _item.AttackMoves())
                {
                    ChessBoardPlacementHandler.Instance.AttackHighlight(coordinate[0], coordinate[1]);
                }
            }
        }
    }
}