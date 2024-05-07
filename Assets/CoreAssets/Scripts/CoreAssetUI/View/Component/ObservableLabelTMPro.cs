using UnityEngine;
using TMPro;

namespace CoreAssetUI.View
{
    public class ObservableLabelTMPro : ObservableLabel
	{
		[SerializeField] private TMP_Text _label = null;

		public TMP_Text Label => _label;

		public override string Text
		{
			get { return _label.text; }
			set { _label.text = value; }
		}
	}
}
