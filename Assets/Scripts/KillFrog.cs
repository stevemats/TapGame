using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField]
    GameObject SmokeEffect;

    [SerializeField]
    GameObject WaterEffect;

    //Reference to the SoundManager Script
    SoundManager soundManager;

    public int TotalScore = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        soundManager = GameObject.Find("SoundManagerObject").GetComponent<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        // this object was clicked
        TotalScore = PlayerPrefs.GetInt("Score ", 0);
        TotalScore++;

        soundManager.playSound();

        PlayerPrefs.SetInt("Score ", TotalScore);
        PlayerPrefs.Save();

        // Debug.Log("Score " +  TotalScore.ToString());

        Destroy(gameObject);
        Instantiate(SmokeEffect, transform.position, Quaternion.identity);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Lake")
        {
            Destroy(gameObject);
            Instantiate(WaterEffect, transform.position, Quaternion.identity);
        }
    }
}
