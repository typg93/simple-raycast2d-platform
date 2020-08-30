using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSword : MonoBehaviour
{
    private Animator anim;
    private Stats stats;

    public float attackDamage;

    // attack speed
    private float attackCDCounter;
    [SerializeField] private float _attackCD = 0.3f;
    [SerializeField] private float attackCDCap = 0.1f; //sets a cap on the attack speed so through items/equips cannot break this limit.
 
    public float attackCD
    {
        get { return _attackCD; }
        set
        {
            if (value > attackCDCap) { _attackCD = value; }
            else if (value <= attackCDCap) { _attackCD = attackCDCap; }
        }
    }
    [SerializeField]
    public LayerMask whatIsDamageable; //hitbox layer;

    public Transform hitBoxOrigin;
    public float hitBoxRangeX;
    public float hitBoxRangeY;

    
    void Start()
    {
        attackCDCounter = attackCD;
        anim = GetComponent<Animator>();
        stats = GetComponent<Stats>();
    }

    
    void Update()
    {
        attackCDCounter -= Time.deltaTime;
    }

    public void Attack()
    {
        
        if (stats.canSwordAttack && attackCDCounter <= 0)
        {
            anim.SetTrigger("Attack");
            attackCDCounter = attackCD;
            Collider2D[] hitObjects = Physics2D.OverlapBoxAll(hitBoxOrigin.position, new Vector2(hitBoxRangeX, hitBoxRangeY), 0, whatIsDamageable);
            
            foreach (Collider2D collider in hitObjects)
            {
                collider.GetComponent<Enemy>().TakeDamage(attackDamage);
                //Instantiate hit particle
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(hitBoxOrigin.position, new Vector2(hitBoxRangeX, hitBoxRangeY));
    }
}

