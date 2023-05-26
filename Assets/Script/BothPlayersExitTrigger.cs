using UnityEngine;

public class BothPlayersExitTrigger : MonoBehaviour
{
    [Tooltip("Defines if both players are needed to activate trigger")][SerializeField] private bool bothPlayersRequired = true;
    [Tooltip("Defines if trigger is for camera rotation")][SerializeField] private bool isCameraTrigger = true;
    private GameObject[] players;
    private bool player1Exited = false;
    private bool player2Exited = false;

    private void Start()
    {
        if(isCameraTrigger) GetComponent<CameraRotate>().PreventTagActivation();
    }

    /// <summary>
    /// Called when player exits triggerarea, checks which way the player 
    /// exited and closes the door if they both exited from 
    /// positive z direction as their last exit.
    /// </summary>
    /// <param name="other">Collider of the player that has exited</param>
    private void OnTriggerExit(Collider other)
    {
        //Added for testing with one player
        if (players.Length == 1)
        {
            if (other.name == players[0].name)
            {
                Vector3 exitDirection = transform.InverseTransformDirection(players[0].transform.position - transform.position);
                if (exitDirection.z > 0) player1Exited = true;
            }
        }
        // if 2 players are found makes sure that both have their last exit in the right direction
        if (players.Length == 2)
        {
            if (other.name == players[0].name)
            {
                Vector3 exitDirection = transform.InverseTransformDirection(players[0].transform.position - transform.position);
                if (exitDirection.z > 0) player1Exited = true;
                else player1Exited = false;
            }

            if (other.name == players[1].name)
            {
                Vector3 exitDirection = transform.InverseTransformDirection(players[1].transform.position - transform.position);
                if (exitDirection.z > 0) player2Exited = true;
                else player2Exited = false;
            }
        }
        if (player1Exited && player2Exited || !bothPlayersRequired && (player1Exited || player2Exited))
        {
            player1Exited = false;
            player2Exited = false;
            tag = "triggered";
            if (isCameraTrigger) GetComponent<CameraRotate>().Rotate();
        }
    }
    private void Update()
    {
        players = GameObject.FindGameObjectsWithTag("player");
    }
}
