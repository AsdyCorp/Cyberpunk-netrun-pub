using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using GoogleMobileAds.Api;
using UnityEngine.SceneManagement;
public class AdManager : MonoBehaviour
{

    private string App_ID = "ca-app-pub-5124962096143531~6606067576";
    [HideInInspector]
    public InterstitialAd InterstitialAd_baner;
    [HideInInspector]
    public BannerView bannerAD;
    [HideInInspector]
    public bool isLoaded = false;
    [HideInInspector]
    public bool isClosed = false;
    [HideInInspector]
    public bool isFailed = false;
    // Start is called before the first frame update
    void Start()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            MobileAds.Initialize(App_ID);

            if (SceneManager.GetActiveScene().name == "main_menu")
            {

                Request_Banner();

            }
            if (SceneManager.GetActiveScene().name == "SampleScene")
            {

                RequestInterstitial();

            }
        }
        
    }

    

    void RequestInterstitial()
    {
        string interStitial_ID = "ca-app-pub-5124962096143531/1967984419";
        InterstitialAd_baner = new InterstitialAd(interStitial_ID);

        // Called when an ad request has successfully loaded.
        InterstitialAd_baner.OnAdLoaded += HandleOnAdLoaded;
        // Called when an ad request failed to load.
        InterstitialAd_baner.OnAdFailedToLoad += HandleOnAdFailedToLoad;
        // Called when an ad is shown.
        InterstitialAd_baner.OnAdOpening += HandleOnAdOpened;
        // Called when the ad is closed.
        InterstitialAd_baner.OnAdClosed += HandleOnAdClosed;
        // Called when the ad click caused the user to leave the application.
        InterstitialAd_baner.OnAdLeavingApplication += HandleOnAdLeavingApplication;

        //real
        AdRequest adRequest = new AdRequest.Builder().Build();

        //test
        //AdRequest adRequest = new AdRequest.Builder()
           // .AddTestDevice("2077ef9a63d2b398840261c8221a0c9b").Build();

        InterstitialAd_baner.LoadAd(adRequest);
    }

    void Request_Banner()
    {
        string banner_id = "ca-app-pub-5124962096143531/4263926958";
        bannerAD = new BannerView(banner_id, AdSize.Banner, AdPosition.Top);


        //real
        AdRequest adRequest = new AdRequest.Builder().Build();

       // AdRequest adRequest  = new AdRequest.Builder()
            //.AddTestDevice("2077ef9a63d2b398840261c8221a0c9b").Build();

        bannerAD.LoadAd(adRequest);
    }

    public void Display_InterstitialAD()
    {
        if (InterstitialAd_baner.IsLoaded())
        {
            InterstitialAd_baner.Show();
        }
    }

    public void Display_Banner()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            bannerAD.Show();
        }
    }



    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        isLoaded = true;
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        isFailed = true;
       
    }

    public void HandleOnAdOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdOpened event received");
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        
        isClosed = true;
    }

    public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLeavingApplication event received");
    }



    

}
