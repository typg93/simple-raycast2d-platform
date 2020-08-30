using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSwitch : MonoBehaviour
{
    public GameObject cam;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            cam.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            cam.SetActive(false);
        }
    }
}
