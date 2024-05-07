using Cysharp.Threading.Tasks;

namespace CoreAssetUI.View
{
    public interface IBattleCardCell : IDoubleTapCell
    {
        UniTask PlayCardAnimation();
    }
}
