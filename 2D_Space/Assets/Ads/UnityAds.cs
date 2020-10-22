using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class UnityAds : MonoBehaviour, IUnityAdsListener
{
    string GooglePlay_ID = "3873253";
    bool GameMode = true;
    string myPlacementId = "rewardedVideo";
    private int gold;
    public Text goldtext;

    void Start()
    {
        gold = PlayerPrefs.GetInt("gold");
        Advertisement.AddListener(this);
        Advertisement.Initialize(GooglePlay_ID, GameMode);
    }
    public void DisplayAD()
    {
        Advertisement.Show(myPlacementId);
    }


    public void ShowRewardedVideo()
    {
        // Check if UnityAds ready before calling Show method:
        if (Advertisement.IsReady(myPlacementId))
        {
            Advertisement.Show(myPlacementId);
        }
        else
        {
            Debug.Log("Rewarded video is not ready at the moment! Please try again later!");
        }
    }
    
    // Implement IUnityAdsListener interface methods:
    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        // Define conditional logic for each ad completion status:
        if (showResult == ShowResult.Finished)
        {
            gold += 300;
            PlayerPrefs.SetInt("gold", gold);
            goldtext.text = "" + gold;
            // Reward the user for watching the ad to completion.
        }
        else if (showResult == ShowResult.Skipped)
        {
            Debug.LogWarning("2");
            print("2");
            // Do not reward the user for skipping the ad.
        }
        else if (showResult == ShowResult.Failed)
        {
            Debug.LogWarning("The ad did not finish due to an error.");
            print("3");
        }
    }

    public void OnUnityAdsReady(string placementId)
    {
        // If the ready Placement is rewarded, show the ad:
        if (placementId == myPlacementId)
        {
            //Debug.LogWarning("11");
            // Optional actions to take when the placement becomes ready(For example, enable the rewarded ads button)
        }
    }

    public void OnUnityAdsDidError(string message)
    {
        Debug.LogWarning("12");
        // Log the error.
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        Debug.LogWarning("13");
        // Optional actions to take when the end-users triggers an ad.
    }

    // When the object that subscribes to ad events is destroyed, remove the listener:
    public void OnDestroy()
    {
        Advertisement.RemoveListener(this);
    }

}
