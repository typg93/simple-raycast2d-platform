using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public bool canSwordAttack = true;
    public bool canJump = true;

    // attack damage
    [SerializeField] private float _meleeDamage = 0; // this is the player's base damage
    public float meleeDamage
    {
        get { return _meleeDamage; }
        set
        {
            if (value >= 0) { _meleeDamage = value; }
            else if (value < 0) { _meleeDamage = 0; } // set minimum damage to min 0;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
