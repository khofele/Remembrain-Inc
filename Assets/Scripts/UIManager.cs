using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject deathMessage = null;
    [SerializeField] private GameObject key = null;
    [SerializeField] private GameObject gameOver = null;

    public void DisplayDeathMessage()
    {
        deathMessage.SetActive(true);
    }

    public void DisableDeathMessage()
    {
        deathMessage.SetActive(false);
    }

    public void DisplayKey()
    {
        key.SetActive(true);
    }

    public void DisplayGameOver()
    {
        gameOver.SetActive(true);
    }
}
