using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    // A private variable to refrence to the animator
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        // To find this Animator component
        anim = GetComponent<Animator>();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // A public function to set a trigger and call it from the button inspector
    public void startAnim()
    {
        anim.SetTrigger("Active");
    }

    // A public function to load the "Tap Game" scene
    public void PlayGameScene()
    {
        SceneManager.LoadScene("TapGame");
    }
}
