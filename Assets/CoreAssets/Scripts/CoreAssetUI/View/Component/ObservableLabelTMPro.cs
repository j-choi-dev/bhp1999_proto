using UnityEngine;
using TMPro;

namespace CoreAssetUI.View
{
    public class ObservableLabelTMPro : ObservableLabel
	{
		[SerializeField] private TMP_Text m_Text = null;

		public override string Text
		{
			get { return m_Text.text; }
			set { m_Text.text = value; }
		}
	}
}
