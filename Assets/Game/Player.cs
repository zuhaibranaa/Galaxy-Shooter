using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  public GameObject Laser;
  public GameObject TrippleShot;
  [SerializeField]
  private int lifes = 3;
  private float fireRate = 0.25f;
  private float canFire = 0.0f;
  [SerializeField]
  public bool CanTrippleShot = false;
  [SerializeField]
  public bool isSpeedBoostActive = false;
  [SerializeField]
  public bool isShieldActive = false;
  [SerializeField]
  float _speed = 4.5f;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0,0,0);
    }

    // Update is called once per frame
    void Update()
    {
      InputManager();
      bounds();
    }
    public void Damage()
    {
      lifes--;
      if (lifes < 1)
      {
          Destroy(this.gameObject);
      }
    }

    void bounds(){
      if (transform.position.y > 4.2f) {
        transform.position = new Vector3(transform.position.x,4.2f,0);
      }else if (transform.position.y < -4.2f) {
        transform.position = new Vector3(transform.position.x,-4.2f,0);
      }else if (transform.position.x > 11.6f) {
        transform.position = new Vector3(-11.6f,transform.position.y,0);
      }else if (transform.position.x < -11.6f) {
        transform.position = new Vector3(11.6f,transform.position.y,0);
      }
    }


    void InputManager(){
      float hinput,vinput;
      hinput = Input.GetAxis("Horizontal");
      vinput = Input.GetAxis("Vertical");
      Shooting();

      if (isSpeedBoostActive == true)
      {
        _speed = 4.5f * 1.5f;
      }
      else if(isSpeedBoostActive == false)
      {
        _speed = 4.5f;
      }
      transform.Translate(Vector3.right * Time.deltaTime * hinput * _speed);
      transform.Translate(Vector3.up * Time.deltaTime * vinput * _speed);
      
    }


    void Shooting(){

      if (Input.GetKey(KeyCode.Space)) {
        if (Time.time > canFire)
        {    
          if (CanTrippleShot)
          {
              Instantiate(TrippleShot, new Vector3(transform.position.x, transform.position.y+1, 0), Quaternion.identity);
          }else
          {
              Instantiate(Laser, new Vector3(transform.position.x, transform.position.y+1, 0), Quaternion.identity);
          }
          canFire = Time.time + fireRate;
        }
     }

    }
    public void trippleShotPowerUpOn()
    {
      CanTrippleShot = true;
      StartCoroutine(TrippleShotPowerDown());
    }
    public void speedPowerUpOn()
    {
      isSpeedBoostActive = true;
      StartCoroutine(SpeedBoostPowerDown());
    }

    public void shieldPowerUpOn()
    {
      isShieldActive = true;
      StartCoroutine(ShieldPowerDown());
    }

    private IEnumerator TrippleShotPowerDown()
    {
      yield return new WaitForSeconds(10.0f);
      CanTrippleShot = false;
    }

    private IEnumerator ShieldPowerDown()
    {
      yield return new WaitForSeconds(10.0f);
      isShieldActive = false;
    }

    private IEnumerator SpeedBoostPowerDown()
    {
      yield return new WaitForSeconds(10.0f);
      isSpeedBoostActive = false;
    }
}
