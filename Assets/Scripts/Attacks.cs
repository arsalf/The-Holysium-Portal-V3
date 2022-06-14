using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacks : MonoBehaviour
{

    public LayerMask collisionLayer;
    public float radius=1f;
    public float damage=2f;
    public bool isPlayer, isEnemy;
    public GameObject hitFX;

    // Update is called once per frame
    void Update()
    {
        DetectCollision();
    }
    
    void DetectCollision()
    {
        Collider[] hit = Physics.OverlapSphere(transform.position, radius, collisionLayer);

        //is Hit
        if(hit.Length > 0)
        {       
            // If this player take the damage for enemy
            if(isPlayer)
            {                     
                Instantiate(hitFX, transform.position, Quaternion.identity); 
                hit[0].gameObject.GetComponent<EnemyAi>().TakeDamage(damage);           
            }

            gameObject.SetActive(false);
        }
    }
}
