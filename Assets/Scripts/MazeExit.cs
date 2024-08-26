using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MazeExit : MonoBehaviour
{
    [SerializeField] SceneManager sM;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Parrying Player")) 
        {
            sM.GoToResults();
        }
    }
}
