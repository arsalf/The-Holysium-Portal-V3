using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAnim : MonoBehaviour
{
    // Start is called before the first frame update
    private NavMeshAgent[] childEnemy;
    private EnemyAi[] childEnemyAi;
    private GameObject child;
    public Transform[] PosEnemy;
    void Awake()
    {
        childEnemy = gameObject.GetComponentsInChildren<NavMeshAgent>();        
        childEnemyAi = gameObject.GetComponentsInChildren<EnemyAi>();        
    }

    void Start()
    {

    }

    void Update()
    {
        SetAllPositionEnemy();
    }

    public void SetAllPositionEnemy()
    {
        int i = 0;
        foreach (var item in childEnemy)
        {            
            item.SetDestination(PosEnemy[i].position);
            i++;            
        }
    }

    public void SetAllEnemyAiActive()
    {
        foreach (var item in childEnemyAi)
        {
            item.enabled = true;
        }
         foreach (var item in PosEnemy)
        {            
            Destroy(item.gameObject);            
        }
    }
    
}
