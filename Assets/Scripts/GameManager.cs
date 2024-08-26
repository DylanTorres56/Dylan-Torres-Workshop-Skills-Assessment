using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject oKeyTextToggle, pKeyTextToggle;
    [SerializeField] TMP_Text parryCounter; // Text that counts successful parries landed.
    [SerializeField] PlayerParry pP; // Reference to parry script; needed to get parriesLanded int. 
    [SerializeField] TMP_Text cSI; // Character State Indicator
    [SerializeField] PlayerAnims pA; // Reference to animation script; needed to get states of character.

    // Start is called before the first frame update
    void Start()
    {
        oKeyTextToggle.SetActive(false);
        pKeyTextToggle.SetActive(false);
        pP = GameObject.FindFirstObjectByType<PlayerParry>().GetComponent<PlayerParry>();
        parryCounter.text = "Parries Landed: " + pP.parriesLanded.ToString();
        pA = GameObject.FindFirstObjectByType<PlayerAnims>().GetComponent<PlayerAnims>();
        cSI.text = "Character State: " + pA.characterState.ToString() + "\nIs Grounded? " + pA.isGrounded.ToString() 
            + "\nIs Wall Sliding? " + pA.isOnWall.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        OAndPKeyToggle();
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

    public void UpdateParryCounter() 
    {
        parryCounter.text = "Parries Landed: " + pP.parriesLanded.ToString();
    }

    public void UpdateCSI() 
    {
        cSI.text = "Character State: " + pA.characterState.ToString() + "\nIs Grounded? " + pA.isGrounded.ToString()
            + "\nIs Wall Sliding? " + pA.isOnWall.ToString();
    }

}
