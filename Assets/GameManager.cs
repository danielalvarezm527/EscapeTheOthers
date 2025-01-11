using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public InterstitialAdExample interstitialAdExample;
    public EnemyGenerator enemyGenerator;

    void Awake()
    {
        enemyGenerator = FindObjectOfType<EnemyGenerator>();
    }

    public void DisplayAds(){
        enemyGenerator.active = false;
        interstitialAdExample.LoadAd();
        interstitialAdExample.ShowAd();
    }
}
