using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopTime : MonoBehaviour
{
    [SerializeField]
    GameManager GM;

    private void OnTriggerEnter(Collider other)
    {
        GM.startPressed = false;
    }
}