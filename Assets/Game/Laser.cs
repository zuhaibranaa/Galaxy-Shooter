using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
  [SerializeField]
  private float __speed = 6.5f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * __speed);
        if (transform.position.y > 5.42f) {
          Destroy(this.gameObject);
        }
    }
}
