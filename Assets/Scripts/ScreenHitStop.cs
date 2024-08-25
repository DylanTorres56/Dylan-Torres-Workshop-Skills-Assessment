using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenHitStop : MonoBehaviour
{

    [SerializeField] float hitStopDuration; // Amount of time hitstop occurs for when parrying a hazard.
    [SerializeField] float pendingHSD; // Pending Hit Stop Duration.
    [SerializeField] bool inHitStop; // A boolean that tracks if the player is already in hitstop.

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pendingHSD < 0 && !inHitStop)
        {
            StartCoroutine(FreezeFrame());
        }
    }

    void HitStop()
    {
        pendingHSD = hitStopDuration;
    }

    IEnumerator FreezeFrame()
    {
        inHitStop = true;
        var defaultTimeScale = Time.timeScale;
        Time.timeScale = 0;

        yield return new WaitForSecondsRealtime(hitStopDuration);

        Time.timeScale = defaultTimeScale;
        pendingHSD = 0;
        inHitStop = false;
    }

}
