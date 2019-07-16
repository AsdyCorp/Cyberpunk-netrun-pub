using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class Music_Player_manager : MonoBehaviour
{
  

    [Header("Audio Stuff")]
    private AudioSource audioSource;
    private AudioClip audioClip;
    private string soundPath;
    private string[] fileNames; //get list of files 

    int currentSongID;//current song ID
    int lastSongID;//last song ID
    void Awake()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        soundPath = Application.streamingAssetsPath + "/ExampleSounds/"; //get our music path in StreamingAssets/Music/ 
        fileNames = Directory.GetFiles(soundPath, "*.ogg");
        currentSongID = GetNewSongID();
        lastSongID = currentSongID;
       // StartCoroutine(LoadAudio());
    }


    private int GetNewSongID()
    {
        return Random.Range(0, fileNames.Length - 1);
    }

    private IEnumerator LoadAudio(string audioName)
    {
        WWW request = GetAudioFromFile(audioName);
        Debug.Log(audioName);
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
    }

    private WWW GetAudioFromFile(string filename)
    {
        WWW request = new WWW(filename);
        return request;
    }

    void Update()
    {
        if (!audioSource.isPlaying)
        {
            while (currentSongID == lastSongID)
            {
                currentSongID = GetNewSongID();
            }
            lastSongID = currentSongID;
            StartCoroutine(LoadAudio(fileNames[currentSongID]));
            while (!audioSource.isPlaying)
            {
                bool test =true;
            }
        }
    }

}