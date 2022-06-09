using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;

public class BannerAd : MonoBehaviour
{

    string gameId = "4790717";
    bool testMode = true;
    public string placementId = "Banner_Android";


    void Start()
    {
        // Initialize the SDK if you haven't already done so:
        //Advertisement.Initialize(gameId, testMode);
        Advertisement.Initialize(gameId);
        StartCoroutine(ShowBannerWhenReady());
    }

    IEnumerator ShowBannerWhenReady()
    {
        while (!Advertisement.IsReady(placementId))
        {
            yield return new WaitForSeconds(0.5f);
        }
        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
        Advertisement.Banner.Show(placementId);
    }

}
