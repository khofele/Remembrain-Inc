using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    [SerializeField] private CharController charController = null;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("oh oh");
        charController.Dead = true;
    }
}
