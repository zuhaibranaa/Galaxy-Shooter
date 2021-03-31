using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private float speed = 2.5f;
    [SerializeField]
    private int PowerUpId;
    
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed);
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            if (PowerUpId == 0)
            {
                player.trippleShotPowerUpOn();
            }
            else if (PowerUpId == 1)
            {
                player.speedPowerUpOn();
            }
            else if (PowerUpId == 2)
            {
                player.shieldPowerUpOn();
            }
            Destroy(this.gameObject);
        }
        
    }
}
