using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    // Making the variables that see if a level is completed
    public Map01Game Map01Game;
    public Map02Game Map02Game;
    public Map03Game Map03Game;

    public static bool level01Completed = false;
    public static bool level02Completed = false;
    public static bool level03Completed = false;
    public static int Cash = 0;
    public static int EngineUpgrades = 0;
    public static int TireUpgrades = 0;

    // Loading the maps
    public void Map01Start ()
    {
        SceneManager.LoadScene("Map01");
    }

    public void Map02Start()
    {
        SceneManager.LoadScene("Map02");
    }

    public void Map03Start ()
    {
        SceneManager.LoadScene("Map03");
    }

    // New lap
    public void NewLap()
    {
        if (SceneManager.GetActiveScene().name == "Map01") 
        {  
            Map01Game.NewLap();
        }   else if (SceneManager.GetActiveScene().name == "Map02") 
        {
            Map02Game.NewLap();
        }   else if (SceneManager.GetActiveScene().name == "Map03")
        {
            Map03Game.NewLap();
        }
    }

    // Race over
    public void RaceFinished()
    {
        if (SceneManager.GetActiveScene().name == "Map01") 
        {  
            Map01Game.gameOn = false;
            Map01Game.NewLap();
            Map01Game.GameEnd();
        }   else if (SceneManager.GetActiveScene().name == "Map02") 
        {
            Map02Game.gameOn = false;
            Map02Game.NewLap();
            Map02Game.GameEnd();
        }   else if (SceneManager.GetActiveScene().name == "Map03") 
        {
            Map03Game.gameOn = false;
            Map03Game.NewLap();
            Map03Game.GameEnd();
        }
    }
}