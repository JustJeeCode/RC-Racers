using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{

    // Variables
    public int checkpointScore = 0;
    public int lapCount = 1;
    public PlayerMovement playerMovement;
    public SceneLoader SceneLoader;

    // If player is touching something
    private void OnTriggerEnter2D (Collider2D collider)
    {
        if (collider.tag == "Checkpoint")
        {
            checkpointScore ++;
            
            if (checkpointScore == 22)
                {
                    lapCount = lapCount + 1;
                    SceneLoader.NewLap();
                }

                if (checkpointScore == 43)
                {
                    lapCount = lapCount + 1;
                    SceneLoader.NewLap();
                }

                if (checkpointScore == 64)
                {
                    lapCount = lapCount + 1;
                    SceneLoader.RaceFinished();
                }
        }

        if (collider.tag == "Oil")
        {
            playerMovement.TouchedOil();
        }

        if (collider.tag == "Money")
        {
            SceneLoader.Cash ++;
            print(SceneLoader.Cash);
        }
    }

    // If player is constantly touching something
    private void OnTriggerStay2D (Collider2D collider)
    {
        if (collider.tag == "Ice")
        {
            playerMovement.TouchingIce();
        }

        if (collider.tag == "Spikes")
        {
            playerMovement.TouchingSpikes();
        } else {
            playerMovement.touchingSpikes = false;
        }

        if (collider.tag == "Grass")
        {
            playerMovement.TouchingGrass();
        }

        if (collider.tag == "Oil")
        {
            playerMovement.TouchingOil();
        }
    }
}
