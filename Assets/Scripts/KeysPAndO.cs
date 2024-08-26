using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeysPAndO : MonoBehaviour
{
    [SerializeField] GameObject oKeyTextToggle, pKeyTextToggle;

    // Start is called before the first frame update
    void Start()
    {
        oKeyTextToggle.SetActive(false);
        pKeyTextToggle.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        OAndPKeyToggle();

        if (Input.GetKey(KeyCode.Escape)) 
        {
            Application.Quit();
        }

    }

    void OAndPKeyToggle()
    {
        if (Input.GetKeyDown(KeyCode.O) && !oKeyTextToggle.activeSelf)
        {
            oKeyTextToggle.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.O) && oKeyTextToggle.activeSelf)
        {
            oKeyTextToggle.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.P) && !pKeyTextToggle.activeSelf)
        {
            pKeyTextToggle.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.P) && pKeyTextToggle.activeSelf)
        {
            pKeyTextToggle.SetActive(false);
        }
    }
}
