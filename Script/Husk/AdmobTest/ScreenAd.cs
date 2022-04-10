#define UNITY_ANDROID
 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
using System;
using GoogleMobileAds.Api;
 
public class ScreenAd : MonoBehaviour
{
    private InterstitialAd interstitial;
 
    void OnEnable()
    {
        RequestInterstitial();

        AdShow();
    }
 
 
    private void RequestInterstitial()
    {
        #if UNITY_ANDROID
            // string adUnitId = "ca-app-pub-3940256099942544/1033173712";
            // TODO : 발매 전 전면광고 아이디 변경
            string adUnitId = "ca-app-pub-5730925351595432/2504926606";
        #else
            string adUnitId = "unexpected_platform";
        #endif
 
        // Initialize an InterstitialAd.
        this.interstitial = new InterstitialAd(adUnitId);
 
        // Called when an ad request has successfully loaded.
        this.interstitial.OnAdLoaded += HandleOnAdLoaded;
        // Called when an ad request failed to load.
        this.interstitial.OnAdFailedToLoad += HandleOnAdFailedToLoad;
        // Called when an ad is shown.
        this.interstitial.OnAdOpening += HandleOnAdOpened;
        // Called when the ad is closed.
        this.interstitial.OnAdClosed += HandleOnAdClosed;
 
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        this.interstitial.LoadAd(request);
    }
 
    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLoaded event received");
    }
 
    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        MonoBehaviour.print("HandleFailedToReceiveAd event received with message: "
            + args.ToString());
    }
 
    public void HandleOnAdOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdOpened event received");
    }
 
    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdClosed event received");
    }
 
    private void OnDestroy()
    {
        this.interstitial.Destroy();
    }
 
    public void AdShow()
    {
        if (this.interstitial.IsLoaded())
        {
            this.interstitial.Show();
        }
    }
}