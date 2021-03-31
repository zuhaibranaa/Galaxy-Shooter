using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public GameObject EnemyExplosion;
    public float speed = 3.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float randx = Random.Range(-11.5f,11.5f); 
        transform.Translate(Vector3.down * Time.deltaTime * speed);
        if (transform.position.y < -7)
        {
            transform.position = new Vector3(randx,7,0);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Laser")
        {
            Destroy(other.gameObject);
            Instantiate(EnemyExplosion,new Vector3(transform.position.x,transform.position.y,0), Quaternion.identity);
            Destroy(this.gameObject);
        }
        else if(other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            player.Damage();
            Instantiate(EnemyExplosion,new Vector3(transform.position.x,transform.position.y,0), Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
