using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlayer : MonoBehaviour
{
 
    public int hp = 10;
    float angle = 10;

    void Update()
    {
        transform.Rotate(Vector3.up * angle * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Meteorite meteorite = other.GetComponent<Meteorite>();
        Enemy enemy = other.GetComponent<Enemy>();
        if (meteorite != null || enemy != null)
        {
            hp--;
        }
    }
}
