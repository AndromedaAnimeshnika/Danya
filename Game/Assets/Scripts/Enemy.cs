using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject explosionPartcile;
    public Transform target;
    float speed = 2;

    private void Start()
    {
        speed *= Random.Range(0.5f,2);
    }

    private void Update()
    {
        if(target != null)
        {
            transform.LookAt(target);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject g = Instantiate(explosionPartcile, transform.position,Quaternion.identity);
        Destroy(g,2);
        Destroy(gameObject);
    }
}
