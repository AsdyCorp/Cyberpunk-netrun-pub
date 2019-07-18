using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

//using System;
/// <summary>
/// нужно закидывать точное название трека.ogg в массив fileNames, треки в папке стриминга - музыка
/// </summary>
public class Music_Player_manager : MonoBehaviour
{
    static System.Random _random = new System.Random(); //shuffle random



    [Header("Audio Stuff")]
    public AudioClip[] musicBase;
    private AudioSource audioSource;
    private AudioClip audioClip;
    private string soundPath;
    
    private int[] songListID;//current list of songs(only ID's)

    //[HideInInspector]
    private bool pauseSource;//true for pause//false for play
    private bool soundSourceActive;//проверка на значение в сохраненных настройках уровня громкости > 0.05 

    private bool death=false;
    private float pitchLevel; //изменяем до нуля pitch level при смерти 

    int currentSongID = 0;//current song counter id in songListId's
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
        death = false;
        pitchLevel = 2.0f;
        float soundLevel = PlayerPrefs.GetFloat("sound_Slider", 1.0f);
        if (soundLevel > 0.05f)
        {
            soundSourceActive = true;
        }
        else
        {
            soundSourceActive = false;
        }
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.volume = soundLevel;
        if (soundSourceActive) //не включаем ничего ,если в настройках звук на нуле(<0.05)
        {
            


            songListID = new int[musicBase.Length];
            for (int i = 0; i < musicBase.Length; i++)
            {
                songListID[i] = i;
            }
            Shuffle(songListID); //initial shuffle
        }


        // StartCoroutine(LoadAudio());
    }


    public void PauseAudioSource()//set audio on pause
    {
        pauseSource = true;
        audioSource.Pause();
    }

    public void UnPauseAudioSource()
    {
        pauseSource = false;
        audioSource.UnPause();
    }

    private void LoadAudio(int audioId)
    {
        audioClip = musicBase[audioId];
        PlayAudioFile();

    }

    private void PlayAudioFile()
    {
        audioSource.clip = audioClip;
        audioSource.Play();
        audioSource.loop = false;
        currentSongID++;
    }


    public void DeathSoundEvent()//активация аудио эффекта смерти(код в update)
    {
        death = true;
    }

    void Update()
    {
        int lastCycleSong;
        if (currentSongID == musicBase.Length && soundSourceActive == true)
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

        if (soundSourceActive == true && pauseSource == false && death==false && !audioSource.isPlaying && lastPlayedId != currentSongID)
        {
            if (audioClip != null)
            {
                audioSource.clip.UnloadAudioData();
                audioClip.UnloadAudioData();
            }
            lastPlayedId = currentSongID;

            LoadAudio(songListID[currentSongID]);

        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            audioSource.Stop();
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            DeathSoundEvent();
        }


        if (death == true) //проигрываем аудио эффект смерти
        {
            if (pitchLevel > 0.07f && audioSource.isPlaying)//нужно 0.07 и выше иначе спамит в логи про невозможность отрицательного питча для нескомпрессированных файлов
            {
                pitchLevel -= Time.deltaTime;
            }
            else
            {
                audioSource.Stop();
                audioSource.clip.UnloadAudioData();
                audioClip.UnloadAudioData();
            }
            audioSource.pitch = pitchLevel / 2;
            
            
        }

    }

}