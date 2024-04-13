using CoreAssetUI.View;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private ListView _deck = null;
    private int _maxHand;
    private int _currHand;
    
    private void Awake()
    {
        
    }
}
