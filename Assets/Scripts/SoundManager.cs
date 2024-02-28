using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour

{

    //A public variable for the audio source we just imported.
    public AudioSource explosionSound;

    //A variable to check whether the user wanted a sound or the user muted it.
    int IsSound;

    //References to the sound buttons and its two images.
    public Sprite soundImage;
    public Sprite noSoundImage;
    public Button SoundButton;

    // Start is called before the first frame update
    void Start()
    {
        //Get the sound value from the player preferences.
        IsSound = PlayerPrefs.GetInt("Sound", 1);

        //Check if the user wants a sound or not.
        if (IsSound == 1)
        {
            //Change its image
            SoundButton.GetComponent<Image>().sprite = soundImage;
        }
        else
        {
            //Change its image
            SoundButton.GetComponent<Image>().sprite = noSoundImage;
        }

    }

    public void playSound()
    {
        IsSound = PlayerPrefs.GetInt("Sound", 1);

        if (IsSound == 1)
        {
            //Play the explosion sound
            explosionSound.Play();

        }

    }
    public void muteSound()
    {
        //Reduce the volume to zero

        explosionSound.volume = 0;
    }

    public void unmuteSound()
    {
       //Raise the volume to one
        explosionSound.volume = 1;
    }

public void ToggleSound()
    {
        //Check if the sound is on, equal to 1
        if (IsSound == 1)
        {
            //Change the variable to zero and save it in preferences
            IsSound = 0;
            PlayerPrefs.SetInt("Sound", IsSound);
            PlayerPrefs.Save();
            SoundButton.GetComponent<Image>().sprite = noSoundImage;
            muteSound();

        }
        else
        {
            IsSound = 1;
            PlayerPrefs.SetInt("Sound", IsSound);
            PlayerPrefs.Save();
            SoundButton.GetComponent<Image>().sprite = soundImage;
            unmuteSound();
        }
    }

}
