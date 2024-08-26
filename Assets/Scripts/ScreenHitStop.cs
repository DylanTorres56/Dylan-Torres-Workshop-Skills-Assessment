using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenHitStop : MonoBehaviour
{
    [SerializeField] bool inHitStop; // A boolean that tracks if the player is already in hitstop.
    float defaultTimeScale; // The default time scale of the project (1.0f).

    void Start()
    {
        defaultTimeScale = Time.timeScale;
    }

    public void HitStop(float hitStopDuration) 
    {
        if(inHitStop)
        {
            return;
        }

        Time.timeScale = 0;
        StartCoroutine(Wait(hitStopDuration));
    }

    IEnumerator Wait(float waitDuration) 
    {
        inHitStop = true;
        yield return new WaitForSecondsRealtime(waitDuration);
        Time.timeScale = defaultTimeScale;
        inHitStop = false;
    }    

}
