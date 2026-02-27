using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] private UIManager uiManager;
    [SerializeField] private GameObject particleEffect;
    [SerializeField] private CharController charController;

    private void OnTriggerEnter(Collider other)
    {
        charController.GotKey = true;
        uiManager.DisplayKey();
        Destroy(particleEffect);
        Destroy(gameObject);
    }
}
