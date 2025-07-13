using Cysharp.Threading.Tasks;

namespace CoreAssetUI.Presenter
{
    public interface ISelectedCardListView : IListView
    {
        UniTask SetScoreEffect( int index, int val );
    }
}
