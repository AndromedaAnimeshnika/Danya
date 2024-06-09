using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] Transform basePlayer;
    float speed = 10, boost = 2, sens = 50;
    public int hp = 5;
    public AudioSource blaster, engine;
    void Start()
    {
        Respawn();
        engine.Play();
    }


    void Update()
    {
        Rotate();
        Move();
        Shoot();
    }

    void Rotate() 
    {
        float xAxis=0;
        float yAxis=0;
        float zAxis=0;

        if (Input.GetKey(KeyCode.A)) { zAxis = 1; }
        if (Input.GetKey(KeyCode.D)) { zAxis = -1; }
        if (Input.GetKey(KeyCode.W)) { xAxis = 1; }
        if (Input.GetKey(KeyCode.S)) { xAxis = -1; }
        if (Input.GetKey(KeyCode.Q)) { yAxis = -1; }
        if (Input.GetKey(KeyCode.E)) { yAxis = 1; }

        Vector3 allAxis = new Vector3 (xAxis, yAxis, zAxis)*sens*Time.deltaTime;
        Quaternion newQuaternion = Quaternion.Euler(allAxis);
        transform.rotation *= newQuaternion;

    }
    void Move() 
    {
        float current_speed = speed;
        
        if(Input.GetKey(KeyCode.Space))
        {
            current_speed *= boost;
            
            engine.volume = 1f;
        }
        else
        {
            engine.volume = 0.5f;
        }
        transform.Translate(Vector3.forward * current_speed * Time.deltaTime);
        
    }
    void Shoot() 
    {
        if(Input.GetMouseButtonDown(0) && Time.timeScale == 1)
        {
            Vector3 firePosition = transform.position+ transform.forward*2;
            Instantiate(bullet, firePosition,transform.rotation);
            blaster.Play();
        }
    }

    void Respawn()
    {
        Vector3 randomPos = Random.onUnitSphere * 100;
        transform.position = randomPos;
        transform.LookAt(basePlayer);
    }
    private void OnTriggerEnter(Collider other)
    {
        Bullet bullet = other.GetComponent<Bullet>();
        if(bullet != null)
        {
            return;
        }
        hp--;
        Respawn();  
    }

}
