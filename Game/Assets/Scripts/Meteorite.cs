using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteorite : MonoBehaviour
{
    [SerializeField] GameObject dustPartcile;
    float speed = 10, angle = 10;

    private void Start()
    {
        float xAxis = Random.Range(0,360);
        float zAxis = Random.Range(0,360);
        float yAxis = Random.Range(0,360);

        Vector3 randomAxis = new Vector3(xAxis,yAxis,zAxis);
        transform.rotation = Quaternion.Euler(randomAxis);
        speed *= Random.Range(0.5f,2);
        angle *= Random.Range(-2,2);
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        transform.Rotate(Vector3.up * angle * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        GameObject g = Instantiate(dustPartcile, transform.position, Quaternion.identity);      
        Destroy(g,2);
        Destroy(gameObject);
    }
}
