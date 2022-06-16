using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class BulletProjectil : MonoBehaviour
{
    private Rigidbody bulletRigidbody;
    public float damage = 2f;
    [SerializeField] private Transform vfxGreenEffect;
    [SerializeField] private Transform vfxRedEffect;

    void Awake()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
        float speed = 10f;
        bulletRigidbody.velocity = transform.forward * speed;
    }
    
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<ThirdPersonController>() != null)
        {
            Instantiate(vfxGreenEffect, transform.position, Quaternion.identity);
            other.GetComponent<ThirdPersonController>().TakeDamage(damage);
        } else if(other.GetComponent<EnemyAi>() != null)
        {
            Instantiate(vfxGreenEffect, transform.position, Quaternion.identity);
            other.GetComponent<EnemyAi>().TakeDamage(damage);
        }else
        {
            Instantiate(vfxRedEffect, transform.position, Quaternion.identity);            
        }

        Destroy(gameObject);
    }
}
