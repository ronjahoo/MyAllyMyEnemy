using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ©GameGurus - Heikkinen R., Hopeasaari J., Kantola J., Kettunen J., Kommio R, PC, Parviainen P., Rautiainen J.
// By: Parviainen P
// If player enters trigger-area calls DoorTrigger Script and tells it that player has left the area


public class DoorExitTriggerScript : MonoBehaviour
{
    /// <summary>
    /// If player enters trigger-area calls DoorTrigger Script and tells it that player has left the area
    /// </summary>
    /// <param name="other">Collider of the player that hit trigger-area</param>
    private void OnTriggerExit(Collider other)
    {
        Debug.Log(other.name);
        if (other.name == "Kipina(Clone)")
        {
            transform.parent.GetComponentInChildren<DoorTriggerScript>().DoorExit("Kipina");
        }
        if (other.name == "Haba(Clone)")
        {
            transform.parent.GetComponentInChildren<DoorTriggerScript>().DoorExit("Haba");
        }
    }
}
