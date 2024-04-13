using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace CoreAssetUI.View
{
    public class ButtonListView : MonoBehaviour
    {
        [SerializeField] private CellBase _cellBase;
        [SerializeField] private Transform m_Parent;

        private Subject<CellStateArg> m_OnSelectionChanged = new Subject<CellStateArg>();
        private Subject<CellStateArg> m_OnHoveredChanged = new Subject<CellStateArg>();
        private Subject<CellStateArg> m_OnPressed = new Subject<CellStateArg>();

        public IObservable<CellStateArg> OnSelectionChanged => m_OnSelectionChanged;
        public IObservable<CellStateArg> OnHoveredChanged => m_OnHoveredChanged;
        public IObservable<CellStateArg> OnPressed => m_OnPressed;

        private List<CellBase> m_Cells = new List<CellBase>();
        public IReadOnlyList<CellBase> Cells => m_Cells;

        private List<string> _selectedCells = new List<string>();
        public IReadOnlyList<string> SelectedCells => _selectedCells;
        private List<int> _selectedIndices = new List<int>();
        public IReadOnlyList<int> SelectedIndices => _selectedIndices;

        private List<string> _hoveredCells = new List<string>();
        public IReadOnlyList<string> HoveredCells => _hoveredCells;
        private List<int> _hoveredIndices = new List<int>();
        public IReadOnlyList<int> HoveredIndices => _hoveredIndices;
    }
}
