using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using GoogleMobileAds.Api;

public class GameController : MonoBehaviour
{
    private InterstitialAd interstitial;
    public GameObject[] WeaponColors;
    public GameObject[] Colors;
    public Color[] PalletColors;
    public Color currentColor;
    public static GameController instance;
    private static int level = 2;
    private static int adDegeri;
    public int[] materialCounts;
    public int ColorObject = 0;
    public GameObject FrameObject;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        MobileAds.Initialize(initStatus => { });
        level = SceneManager.GetActiveScene().buildIndex;
        materialCounts = new int[] { 0, 0, 1, 2, 3, 3, 3, 3, 4, 4, 4, 4, 4, 4, 4, 4, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 6, 6, 6, 6, 6, 6, 6, 6 };
        for (int i = 0; i < 4; i++)
        {
            WeaponColors[i].GetComponent<Renderer>().material.color = PalletColors[0];
            currentColor = PalletColors[3];
            ColorObject = 3;
        }
        RequestInterstitial();
        if (adDegeri % 5 == 0)
        {
            ShowAd();
        }
    }

    void Update()
    {
        Drag.instance.IsDone = GetIsDone();
        if (Drag.instance.IsDone)
        {
            FrameObject.gameObject.SetActive(false);
            ChangeColor();
        }
        EndGame();
       
    }
    public void ChangeColor()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray mouseClick = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            bool hitAnObject = Physics.Raycast(mouseClick, out hit, 1000f);
            if (hitAnObject)
            {
                if (hit.collider.gameObject == Colors[0])
                {
                    for (int i = 0; i < 4; i++)
                    {
                        WeaponColors[i].GetComponent<Renderer>().material.color = PalletColors[1];
                        currentColor = PalletColors[1];
                        ColorObject = 1;
                    }
                }
                if (hit.collider.gameObject == Colors[1])
                {
                    for (int i = 0; i < 4; i++)
                    {
                        WeaponColors[i].GetComponent<Renderer>().material.color = PalletColors[2];
                        currentColor = PalletColors[2];
                        ColorObject = 2;
                    }
                }
                if (hit.collider.gameObject == Colors[2])
                {
                    for (int i = 0; i < 4; i++)
                    {
                        WeaponColors[i].GetComponent<Renderer>().material.color = PalletColors[3];
                        currentColor = PalletColors[3];
                        ColorObject = 3;
                    }
                }
                if (hit.collider.gameObject == Colors[3])
                {
                    for (int i = 0; i < 4; i++)
                    {
                        WeaponColors[i].GetComponent<Renderer>().material.color = PalletColors[4];
                        currentColor = PalletColors[4];
                        ColorObject = 4;
                    }
                }
                if (hit.collider.gameObject == Colors[4])
                {
                    
                    for (int i = 0; i < 4; i++)
                    {
                        WeaponColors[i].GetComponent<Renderer>().material.color = PalletColors[5];
                        currentColor = PalletColors[5];
                        ColorObject = 5;
                    }
                }
                if (hit.collider.gameObject == Colors[5])
                {
                    for (int i = 0; i < 4; i++)
                    {
                        WeaponColors[i].GetComponent<Renderer>().material.color = PalletColors[6];
                        currentColor = PalletColors[6];
                        ColorObject = 6;
                    }
                }
                if (hit.collider.gameObject == Colors[6])
                {
                    for (int i = 0; i < 4; i++)
                    {
                        WeaponColors[i].GetComponent<Renderer>().material.color = PalletColors[7];
                        currentColor = PalletColors[7];
                        ColorObject = 7;
                    }
                }
                if (hit.collider.gameObject == Colors[7])
                {
                    for (int i = 0; i < 4; i++)
                    {
                        WeaponColors[i].GetComponent<Renderer>().material.color = PalletColors[8];
                        currentColor = PalletColors[8];
                        ColorObject = 8;
                    }
                }
            }
        }
    }
    public void EndGame()
    {
        if (IsThePictureCompletelyFilled() == true)
        {
            level++;
            SceneManager.LoadScene(level);
            if (SceneManager.GetActiveScene().buildIndex == 33)
            {
                SceneManager.LoadScene(1);
            }
            else
            {
                if (level > PlayerPrefs.GetInt("levelAt"))
                {
                    PlayerPrefs.SetInt("levelAt", level);
                }
                Debug.Log($" ===> Level {level}'ye geçti <=== ");
            }
            adDegeri++;
        }
    }

    bool GetIsDone()
    {
        bool isDone = false;
        for (int i = 0; i < materialCounts[level]; i++)
        {
            var QObj = GameObject.FindGameObjectWithTag("Q" + (i + 1).ToString());
            if (QObj == null)
            {
                isDone = true;
            }
            else
            {
                isDone = false;
                break;
            }
        }
        return isDone;
    }


    #region ateş etme hallolacak
    bool IsThePictureCompletelyFilled()
    {
        bool isComplete = false;
        for (int i = 0; i < materialCounts[level]; i++)
        {
            var fObj = GameObject.FindGameObjectWithTag("F" + (i + 1).ToString());
            var iObj = GameObject.FindGameObjectWithTag("U" + (i + 1).ToString());
            if (fObj.GetComponent<CollisionObject>().baloonIntColor == iObj.GetComponent<TargetObject>().targetInt)
            {
                isComplete = true;
            }
            else
            {
                isComplete = false;
                break;
            }
        }
        return isComplete;
    }
    #endregion
    private void RequestInterstitial()
    {
        #if UNITY_ANDROID
        string adUnitId = "ca-app-pub-6659219249389991/5814369231";
#elif UNITY_IPHONE
        string adUnitId = "";
#else
        string adUnitId = "";
#endif

        // Initialize an InterstitialAd.
        this.interstitial = new InterstitialAd(adUnitId);
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        this.interstitial.LoadAd(request);
    }
    private void ShowAd()
    {
        if (this.interstitial.IsLoaded())
        {
            this.interstitial.Show();
        }
    }
}
