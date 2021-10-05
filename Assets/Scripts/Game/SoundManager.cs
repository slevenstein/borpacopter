using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using gs = GameStateEnum.GameState; 

public class SoundManager : MonoBehaviour
{
    private AudioSource[] mySounds;

    // current state
    private gs cs = gs.Play;

    private AudioSource playMusic;
    private AudioSource lossMusic;
    private AudioSource winMusic;
    private AudioSource pauseMusic;
    private AudioSource boss1Music;
    private AudioSource boss2Music;
    private AudioSource boss3Music;

    public int bossLevel = 0;

    // Start is called before the first frame update
    void Start()
    {
        mySounds = GetComponents<AudioSource>();

        playMusic = mySounds[0];
        lossMusic = mySounds[1];
        pauseMusic = mySounds[2];
        winMusic = mySounds[3];
        boss1Music = mySounds[4];
        boss2Music = mySounds[5];
        boss3Music = mySounds[6];
    }

    public void pause(){
        if (cs == gs.Play){
            switch(bossLevel){
                case 0:
                    playMusic.Pause();
                    break;
                case 1:
                    boss1Music.Pause();
                    break;
                case 2:
                    boss2Music.Pause();
                    break;    
                case 3:
                    boss3Music.Pause();
                    break;
            }
        } else if (cs == gs.Loss) {
            lossMusic.Pause();
        } else if (cs == gs.Win){
            winMusic.Pause();
        }
        pauseMusic.Play();
    }

    public void unpause() {
        if (cs == gs.Play){
            switch(bossLevel){
                case 0:
                    playMusic.UnPause();
                    break;
                case 1:
                    boss1Music.UnPause();
                    break;
                case 2:
                    boss2Music.UnPause();
                    break;    
                case 3:
                    boss3Music.UnPause();
                    break;
            }
        } else if (cs == gs.Loss) {
            lossMusic.UnPause();
        } else if (cs == gs.Win){
            winMusic.UnPause();
        }
        pauseMusic.Stop();
    }

    public void setBoss(int lvl) {
        bossLevel = lvl;
    }

    private void stopAll(){
        for (int i = 0; i < mySounds.Length; i++){
            mySounds[i].Stop();
        }
    }

    public void switchGameState(gs state) {
        
        if (state == gs.Play){
            stopAll();
            switch(bossLevel){
                case 0:
                    playMusic.Play();
                    break;
                case 1:
                    boss1Music.Play();
                    break;
                case 2:
                    boss2Music.Play();
                    break;    
                case 3:
                    boss3Music.Play();
                    break;
            }
            cs = gs.Play;
        } else if (state == gs.Loss) {
            stopAll();
            lossMusic.Play();
            cs = gs.Loss;
        } else if (state == gs.Win){
            stopAll();
            winMusic.Play();
            cs = gs.Win;
        } 
    }

}
