using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] TMP_Text parryCounter; // Text that counts successful parries landed.
    [SerializeField] PlayerParry pP; // Reference to parry script; needed to get parriesLanded int. 
    [SerializeField] TMP_Text cSI; // Character State Indicator
    [SerializeField] PlayerAnims pA; // Reference to animation script; needed to get states of character.

    // Start is called before the first frame update
    void Start()
    {
        pP = GameObject.FindFirstObjectByType<PlayerParry>().GetComponent<PlayerParry>();
        parryCounter.text = "Parries Landed: " + pP.parriesLanded.ToString();
        pA = GameObject.FindFirstObjectByType<PlayerAnims>().GetComponent<PlayerAnims>();
        cSI.text = "Character State: " + pA.characterState.ToString() + "\nIs Grounded? " + pA.isGrounded.ToString() 
            + "\nIs Wall Sliding? " + pA.isOnWall.ToString();
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
