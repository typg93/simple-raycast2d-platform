using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bunny : MonoBehaviour
{

    Controller2D controller;
    Vector2 test = new Vector2(-1,0);
    
    void Start()
    {
        controller = GetComponent<Controller2D>();
    }

    
    void Update()
    {
        controller.Move(test * Time.deltaTime, false);

    }
}
