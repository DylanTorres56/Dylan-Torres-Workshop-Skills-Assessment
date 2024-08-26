using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileLauncher : MonoBehaviour
{
    public GameObject missilePrefab;
    [Range(3.0f, 5.0f)] [SerializeField] float startingLaunchTimer;
    [SerializeField] float launchTimer;

    // Awake is called on the first active frame update
    private void Awake()
    {
        launchTimer = startingLaunchTimer;
    }

    // Update is called once per frame
    void Update()
    {
        launchTimer -= Time.deltaTime;

        if (launchTimer <= 0) 
        {
            launchTimer = startingLaunchTimer;
            LaunchMissile();
        }

    }

    void LaunchMissile() 
    {
        Instantiate(missilePrefab, transform.position, Quaternion.identity);
    }
}
