using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    // Varaibles
    public SceneLoader SceneLoader;
    public GameObject UnlockLevel02;
    public GameObject UnlockLevel03;
    public GameObject ShopWindow;
    public Text CashText;
    public Text EngineCost;
    public Text TireCost;
    public Text TireUpgradeCost;
    public Text EngineUpgradeCost;
    private bool shopOpen = false;
    public int[ ] CurrentEngineCost = {50, 100, 200, 350, 600};     
    public int[ ] CurrentTireCost = {50, 100, 200, 350, 600};    

    // Testing to see if a level has been completed
    public void Awake()
    {
        // Shop
        CashText.text = SceneLoader.Cash.ToString();

        ShopWindow.SetActive(false);

        print(SceneLoader.level01Completed);
        if (SceneLoader.level01Completed == true)
        {
            UnlockLevel02.SetActive(false);
        }   else {
            UnlockLevel02.SetActive(true);
        }

        if (SceneLoader.level02Completed == true)
        {
            UnlockLevel03.SetActive(false);
        }   else
        {
            UnlockLevel03.SetActive(true);
        }
    }

    void FixedUpdate()
    {
        // Changing price of shop
        if (SceneLoader.EngineUpgrades == 0)
        {
            EngineCost.text = CurrentEngineCost[0].ToString();
        }   else if (SceneLoader.EngineUpgrades == 1)
        {
            EngineCost.text = CurrentEngineCost[1].ToString();
        }   else if (SceneLoader.EngineUpgrades == 2)
        {
            EngineCost.text = CurrentEngineCost[2].ToString();
        }   else if (SceneLoader.EngineUpgrades == 3)
        {
            EngineCost.text = CurrentEngineCost[3].ToString();
        }   else if (SceneLoader.EngineUpgrades == 4)
        {
            EngineCost.text = CurrentEngineCost[4].ToString();
        }   else
        {
            EngineUpgradeCost.text = "MAXED!";
            EngineCost.text = "";
        }

        if (SceneLoader.TireUpgrades == 0)
        {
            TireCost.text = CurrentTireCost[0].ToString();
        }   else if (SceneLoader.TireUpgrades == 1)
        {
            TireCost.text = CurrentTireCost[1].ToString();
        }   else if (SceneLoader.TireUpgrades == 2)
        {
            TireCost.text = CurrentTireCost[2].ToString();
        }   else if (SceneLoader.TireUpgrades == 3)
        {
            TireCost.text = CurrentTireCost[3].ToString();
        }   else if (SceneLoader.TireUpgrades == 4)
        {
            TireCost.text = CurrentTireCost[4].ToString();
        }   else
        {
            TireUpgradeCost.text = "MAXED!";
            TireCost.text = "";
        }
    }

    // Play Game Button
    public void PlayGameButton()
    {
        SceneManager.LoadScene("Menu");
    }

    // Quit Game Button
    public void QuitGameButton()
    {
        Application.Quit();
    }


    // Shop
    public void ShopButton()
    {
        if (!shopOpen)
        {
            shopOpen = true;
            ShopWindow.SetActive(true);
        }   else
        {
            shopOpen = false;
            ShopWindow.SetActive(false);
        }
    }

    // Leave shop button
    public void LeaveShop()
    {
        shopOpen = false;
        ShopWindow.SetActive(false);
    }

    // Engine upgrade button
    public void EngineUpgradeButton()
    {
        if (SceneLoader.EngineUpgrades == 0)
        {
            EngineCost.text = CurrentEngineCost[0].ToString();
        }   else if (SceneLoader.EngineUpgrades == 1)
        {
            EngineCost.text = CurrentEngineCost[1].ToString();
        }   else if (SceneLoader.EngineUpgrades == 2)
        {
            EngineCost.text = CurrentEngineCost[2].ToString();
        }   else if (SceneLoader.EngineUpgrades == 3)
        {
            EngineCost.text = CurrentEngineCost[3].ToString();
        }   else if (SceneLoader.EngineUpgrades == 4)
        {
            EngineCost.text = CurrentEngineCost[4].ToString();
        }

        if (SceneLoader.Cash > CurrentEngineCost[0] && SceneLoader.EngineUpgrades == 0)
        {
            SceneLoader.EngineUpgrades ++;
            SceneLoader.Cash -= 50;
        }   else if (SceneLoader.Cash > CurrentEngineCost[1] && SceneLoader.EngineUpgrades == 1)
        {
            SceneLoader.EngineUpgrades ++;
            SceneLoader.Cash -= 100;
        }   else if (SceneLoader.Cash > CurrentEngineCost[2] && SceneLoader.EngineUpgrades == 2)
        {
            SceneLoader.EngineUpgrades ++;
            SceneLoader.Cash -= 200;
        }   else if (SceneLoader.Cash > CurrentEngineCost[3] && SceneLoader.EngineUpgrades == 3)
        {
            SceneLoader.EngineUpgrades ++;
            SceneLoader.Cash -= 350;
        }   else if (SceneLoader.Cash > CurrentEngineCost[4] && SceneLoader.EngineUpgrades == 4)
        {
            SceneLoader.EngineUpgrades ++;
            SceneLoader.Cash -= 600;
        } 

        CashText.text = SceneLoader.Cash.ToString();
    }

    // Tire upgrade button
    public void TireGripUpgradeButton()
    {
        if (SceneLoader.TireUpgrades == 0)
        {
            TireCost.text = CurrentTireCost[0].ToString();
        }   else if (SceneLoader.TireUpgrades == 1)
        {
            TireCost.text = CurrentTireCost[1].ToString();
        }   else if (SceneLoader.TireUpgrades == 2)
        {
            TireCost.text = CurrentTireCost[2].ToString();
        }   else if (SceneLoader.TireUpgrades == 3)
        {
            TireCost.text = CurrentTireCost[3].ToString();
        }   else if (SceneLoader.TireUpgrades == 4)
        {
            TireCost.text = CurrentTireCost[4].ToString();
        }

        if (SceneLoader.Cash > CurrentTireCost[0] && SceneLoader.TireUpgrades == 0)
        {
            SceneLoader.TireUpgrades ++;
            SceneLoader.Cash -= 50;
        }   else if (SceneLoader.Cash > CurrentTireCost[1] && SceneLoader.TireUpgrades == 1)
        {
            SceneLoader.TireUpgrades ++;
            SceneLoader.Cash -= 100;
        }   else if (SceneLoader.Cash > CurrentTireCost[2] && SceneLoader.TireUpgrades == 2)
        {
            SceneLoader.TireUpgrades ++;
            SceneLoader.Cash -= 200;
        }   else if (SceneLoader.Cash > CurrentTireCost[3] && SceneLoader.TireUpgrades == 3)
        {
            SceneLoader.TireUpgrades ++;
            SceneLoader.Cash -= 350;
        }   else if (SceneLoader.Cash > CurrentTireCost[4] && SceneLoader.TireUpgrades == 4)
        {
            SceneLoader.TireUpgrades ++;
            SceneLoader.Cash -= 600;
        }

        CashText.text = SceneLoader.Cash.ToString();
    }

    // Level Start Buttons
    public void Level01Button()
    {
        SceneLoader.Map01Start();
    }

    public void Level02Button()
    {
        if (SceneLoader.level01Completed == true)
        {
            SceneLoader.Map02Start();
        }
    }

    public void Level03Button()
    {
        if (SceneLoader.level02Completed == true)
        {
            SceneLoader.Map03Start();
        }   
    }

}
