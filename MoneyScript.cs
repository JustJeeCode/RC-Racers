using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyScript : MonoBehaviour
{

    // Destroy money on touch of player
    private void OnTriggerEnter2D (Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
