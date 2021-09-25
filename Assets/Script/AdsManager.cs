using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour
{    
    void Start()
    {
        Advertisement.Initialize("4375209");
        PlayAd();
    }

    public void PlayAd()
    {
        if (Advertisement.IsReady("Banner_Android"))
        {
            Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
            Advertisement.Banner.Show("Banner_Android");
        }
        else
            StartCoroutine(RepeatShowBanner());
    }

    public void HideBanner()
    {
        Advertisement.Banner.Hide();
    }

    IEnumerator RepeatShowBanner()
    {

        print("Ready!");
        yield return new WaitForSeconds(.5f);
        PlayAd();
    }

}
