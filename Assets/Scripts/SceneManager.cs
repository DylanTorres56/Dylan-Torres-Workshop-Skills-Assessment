using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    public void GoToGameplay() 
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    public void GoToResults()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }

    public void ReturnToTitle()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("TitleScreen");
    }
}
