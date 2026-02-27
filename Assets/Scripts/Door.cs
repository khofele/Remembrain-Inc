using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private UIManager uiManager;
    [SerializeField] private CharController charController;

    private void OnTriggerEnter(Collider other)
    {
        if(charController.GotKey == true)
        {
            uiManager.DisplayGameOver();
            charController.GameOver = true;
        }
    }
}
