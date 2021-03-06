using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTimer : MonoBehaviour
{
    public float timer = 2f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyGameObject", timer);
    }

    void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}
