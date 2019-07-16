using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
//using System;

public class Music_Player_manager : MonoBehaviour
{
    static System.Random _random = new System.Random(); //shuffle random

     

    [Header("Audio Stuff")]
    private AudioSource audioSource;
    private AudioClip audioClip;
    private string soundPath;
    public string[] fileNames; //get list of files 
    private int[] songListID;//current list of songs(only ID's)

    //[HideInInspector]
    public bool pauseSource=false;//true for pause//false for play

    int currentSongID=0;//current song counter id in songListId's
    int lastPlayedId = -1;//last played song
    
    
    static void Shuffle<T>(T[] array) ///shuffle of array
    {
        /// <summary>
        /// Fisher-Yates shuffle.
        /// https://www.dotnetperls.com/fisher-yates-shuffle
        /// 
        /// </summary>
        /// 
        int n = array.Length;
        for (int i = 0; i < n; i++)
        {
            // Use Next on random instance with an argument.
            // ... The argument is an exclusive bound.
            //     So we will not go past the end of the array.
            int r = i + _random.Next(n - i);
            T t = array[r];
            array[r] = array[i];
            array[i] = t;
        }
    }
    
    void Awake()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        
        if (Application.platform == RuntimePlatform.Android)
        {
            soundPath = "jar:file://" + Application.dataPath + "!/assets" + "/Music/";
        }
          
        else if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            soundPath = Application.dataPath + "/Raw" + "/Music/"; //get our music path in StreamingAssets/Music/
        }
        else if (Application.isEditor)
        {
            soundPath = Application.streamingAssetsPath + "/Music/"; //get our music path in StreamingAssets/Music/
        }
       // soundPath = "file://"+Application.streamingAssetsPath + "/ExampleSounds/"; //get our music path in StreamingAssets/Music/ 
        

        songListID = new int[fileNames.Length];
        for(int i=0; i < fileNames.Length; i++)
        {
            songListID[i] = i;
        }
        Shuffle(songListID); //initial shuffle
        

        
       // StartCoroutine(LoadAudio());
    }


    

    private IEnumerator LoadAudio(string audioName)
    {
        WWW request = GetAudioFromFile(soundPath+audioName);
        
        yield return request;

        audioClip = request.GetAudioClip();
        audioClip.name = fileNames[currentSongID];
        PlayAudioFile();
    }

    private void PlayAudioFile()
    {
        audioSource.clip = audioClip;
        audioSource.Play();
        audioSource.loop = false;
        currentSongID++;
        
    }

    private WWW GetAudioFromFile(string filename)
    {
        WWW request = new WWW(filename);
        return request;
    }

    void Update()
    {
        int lastCycleSong;
        if (currentSongID == fileNames.Length)
        {
            lastCycleSong = songListID[currentSongID - 1];
            currentSongID = 0;
            lastPlayedId = -1;
            Shuffle(songListID);
            while (lastCycleSong == songListID[0]) //проверка, что последняя песня в цикле не будет первой в следующем
            {
                Shuffle(songListID);
            }
        }

        if (!audioSource.isPlaying && lastPlayedId!=currentSongID)
        {
            if (audioClip!=null) {
                audioClip.UnloadAudioData();
            }
            lastPlayedId = currentSongID;
            StartCoroutine(LoadAudio(fileNames[songListID[currentSongID]]));
        }
    }
    
}