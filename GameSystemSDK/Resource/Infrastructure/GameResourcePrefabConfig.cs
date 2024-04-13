using GameSystemSDK.BattleScene.Infrastructure;
using UnityEngine;

namespace GameSystemSDK.Resource.Infrastructure
{
    [CreateAssetMenu( fileName = "NewGameResourcePrefabConfig", menuName = "BHP1999/GameResourceSDK/Resource Config" )]
    public class GameResourcePrefabConfig : ScriptableObject
    {
        [SerializeField] private BattleCard _battleCard;
        [SerializeField] private BattleCardIcon _battleCardIcon;
    }
}
