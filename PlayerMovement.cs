using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Variables
    public SceneLoader SceneLoader;
    private float speed = 0f;    
    private float rotationSpeed = 0f;
    private float acceleration;
    private int randOil;
    private float randSpikes;
    private float maxSpeed;
    private float maxRotationSpeed;
    public bool touchingSpikes = false;
    public Transform player;
    public Sprite straight;
    public Sprite leftTurn;
    public Sprite rightTurn;
    public Sprite noTires;
    public Sprite leftNoTires;
    public Sprite rightNoTires;

    // Making sure the car has the current upgrade
    void Awake()
    {
        if (SceneLoader.EngineUpgrades == 0)
        {
            maxSpeed = .035f;
            maxRotationSpeed = 1.25f;
            acceleration = .00125f;
        }   else if (SceneLoader.EngineUpgrades == 1)
        {
            maxSpeed = .04f;
            maxRotationSpeed = 1.75f;
            acceleration = .0015f;
        }   else if (SceneLoader.EngineUpgrades == 2)
        {
            maxSpeed = .045f;
            maxRotationSpeed = 2.25f;
            acceleration = .00175f;
        }   else if (SceneLoader.EngineUpgrades == 3)
        {
            maxSpeed = .05f;
            maxRotationSpeed = 2.75f;
            acceleration = .002f;
        }   else
        {
            maxSpeed = .055f;
            maxRotationSpeed = 3f;
            acceleration = .00225f;
        }
    }

    // If touching obstacles
    public void TouchingIce ()
    {
        if (SceneLoader.TireUpgrades == 0)
        {
            if (speed > .005f)
            {
                speed = .005f;
            }
        }   else if (SceneLoader.TireUpgrades == 1)
        {
            if (speed > .075f)
            {
                speed = .075f;
            }
        }   else if (SceneLoader.TireUpgrades == 2)
        {
            if (speed > .01f)
            {
                speed = .01f;
            }
        }   else if (SceneLoader.TireUpgrades == 3)
        {
            if (speed > .0125f)
            {
                speed = .0125f;
            }
        }   else
        {
            if (speed > .015f)
            {
                speed = .015f;
            }
        }

        player.transform.Translate(0, speed, 0);
    }

    public void TouchedOil ()
    {
        if (SceneLoader.TireUpgrades == 0)
        {
            randOil = Random.Range(-60, 60);
        }   else if (SceneLoader.TireUpgrades == 1)
        {
            randOil = Random.Range(-50, 50);
        }   else if (SceneLoader.TireUpgrades == 2)
        {
            randOil = Random.Range(-40, 40);
        }   else if (SceneLoader.TireUpgrades == 3)
        {
            randOil = Random.Range(-30, 30);
        }   else
        {
            randOil = Random.Range(-20, 20);
        }

        player.transform.Rotate(0, speed, randOil);
    }

    public void TouchingOil ()
    {
        player.transform.Rotate(0, speed, 0);
    }

    public void TouchingSpikes ()
    {
        if (SceneLoader.TireUpgrades == 0)
        {
            randSpikes = Random.Range(-2f, 2f);
            if (speed > .005f)
            {
                speed = .005f;
            }
        }   else if (SceneLoader.TireUpgrades == 1)
        {
            randSpikes = Random.Range(-1.75f, 1.75f);
            if (speed > .001f)
            {
                speed = .001f;
            }
        }   else if (SceneLoader.TireUpgrades == 2)
        {
            randSpikes = Random.Range(-1.25f, 1.25f);
            if (speed > .015f)
            {
                speed = .015f;
            }
        }   else if (SceneLoader.TireUpgrades == 3)
        {
            randSpikes = Random.Range(-.75f, .75f);
            if (speed > .02f)
            {
                speed = .02f;
            }
        }   else
        {
            randSpikes = Random.Range(-.25f, .25f);
            if (speed > .025f)
            {
                speed = .025f;
            }
        }

        player.transform.Rotate(0, speed, randSpikes);
        touchingSpikes = true;
    }

    public void TouchingGrass ()
    {
        if (Input.GetKey("w"))
        {
            speed = .008f;
            player.transform.Translate(0, speed, 0);
        }   else
        {
            speed = speed - .0008f;
            if (speed < 0f) 
            {
                speed = 0f;
            } else 
            {
                player.transform.Translate(0, speed, 0);
            }
        }
    }
    
    // Movement
    void FixedUpdate()
    {  
        // Holding down W key to speed up
        if (Input.GetKey("w")) 
        {
            print(maxSpeed);
            if (touchingSpikes == true)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = noTires;
            } else 
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = straight;
            }
            if (speed < maxSpeed) 
            {
                speed = speed + acceleration;
                player.transform.Translate(0, speed, 0);
            } else 
            {
                speed = maxSpeed;
                player.transform.Translate(0, speed, 0);
            }
        } else 
        {
            speed = speed - .0008f;
            if (speed < 0f) 
            {
                speed = 0f;
            } else 
            {
                player.transform.Translate(0, speed, 0);
            }
        }

        // Holding down S key to slow down
        if (Input.GetKey("s"))
        {
            if (speed > 0f)
            {
                speed = speed - 0.001f;
                player.transform.Translate(0, speed, 0);
            } 
        } 

        // Holding down the A key to turn left
        if (Input.GetKey("a"))
        {
            if (touchingSpikes == true)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = leftNoTires;
            } else 
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = leftTurn;
            }
            if (rotationSpeed < maxRotationSpeed)
            {
                rotationSpeed = rotationSpeed + .1f;                
                if (speed > 0f)
                {
                    player.transform.Rotate(0, 0, rotationSpeed);
                }
            } else 
            {
                rotationSpeed = maxRotationSpeed;
                if (speed > 0f)
                {
                    player.transform.Rotate(0, 0, rotationSpeed);
                }
            }
        } else 
        {
            if (rotationSpeed > 0f)
            {
                rotationSpeed = rotationSpeed - maxRotationSpeed;
                player.transform.Rotate(0, 0, rotationSpeed);
                if (rotationSpeed < 0f)
                {
                    rotationSpeed = 0f;
                }
            }
        }

        // Holding down the D key to turn left
        if (Input.GetKey("d"))
        {
            if (touchingSpikes == true)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = rightNoTires;
            } else 
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = rightTurn;
            }
            if (rotationSpeed > -maxRotationSpeed)
            {
                rotationSpeed = rotationSpeed -.1f;
                if (speed > 0f)
                {
                    player.transform.Rotate(0, 0, rotationSpeed);
                }
            } else 
            {
                rotationSpeed = -maxRotationSpeed;
                if (speed > 0f)
                {
                    player.transform.Rotate(0, 0, rotationSpeed);
                }
            }
        } else 
        {
            if (rotationSpeed < 0f)
            {
                rotationSpeed = rotationSpeed + maxRotationSpeed;
                player.transform.Rotate(0, 0, rotationSpeed);
                if (rotationSpeed > 0f)
                {
                    rotationSpeed = 0f;
                }
            }
        }
    }
}
