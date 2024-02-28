using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawn : MonoBehaviour
{
    [SerializeField]
    GameObject Frog;

    [SerializeField]
    Text scoreText;

    public int TotalScore = 0;

    [SerializeField]
    GameObject darkScreen;

    [SerializeField]
    GameObject frame;

    int IsPause;

    GameObject[] gameObjects;

    // Start is called before the first frame update
    void Start()
    {
        IsPause = 0;
        StartCoroutine(spawningFrog());
    }

    // Update is called once per frame
    void Update()
    {
        TotalScore = PlayerPrefs.GetInt("Score ", 0);
        scoreText.text = "Score " + TotalScore.ToString();

        // destroy frogs already in scene by finding game
        // objects with tag "frog
        if (IsPause == 1)
        {
            gameObjects = GameObject.FindGameObjectsWithTag("frog");

            foreach (GameObject frog in gameObjects)
            {
                GameObject.Destroy(frog);
            }
        }
    }

    IEnumerator spawningFrog()
    {
        while (IsPause == 0)
        {
            yield return new WaitForSeconds(0.8f);

            // Generate a random number between 0 & screen's height
            float posY = Random.Range
                (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);

            // Generate a random number between 0 & screen's width
            float posX = Random.Range
               (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);

            // X & Y coordinate for the position of frog
            Vector2 spawnPosition = new Vector2(posX, posY+3);

            // Instantiate the frog in that generated position
            Instantiate(Frog, spawnPosition, Quaternion.identity);
        }
    }

    public void PauseGame()
    {
        IsPause = 1;
        darkScreen.SetActive(true);
        frame.SetActive(true);
    }

    public void ResumeGame()
    {
        IsPause = 0;
        StopAllCoroutines(); //stop all running coroutines
        darkScreen.SetActive(false);
        frame.SetActive(false);
        StartCoroutine(spawningFrog());
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
