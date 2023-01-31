using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.5f;
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private float _fireRate = 0.5f;
    [SerializeField]
    private float _canFire = -1f;
    [SerializeField]
    private float _playerLives = 3.0f;
    private SpawnManager _spawnManager;
    [SerializeField]
    private bool _tripleShotOn = false;
    [SerializeField]
    private GameObject _tripleShotPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        _spawnManager = GameObject.FindWithTag("SpawnManager").GetComponent<SpawnManager>();

        if(_spawnManager == null)
        {
            Debug.LogError("SpawnManager script is unavailable.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();

        // comment block: firing lasers logic
        {
            /*
            - if space key is pressed, fire a laser. also include a cool down logic
            so the player can't spam the fire key too much
            */
        }
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
        {
            FireLaser();
        }

    }

    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        

        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * _speed * Time.deltaTime);

        /*comment block:*/
        {
            /*
             * {
             - restricting the player's range of motion

            - not going above y = 0;
            - check if y > 0:
                - set it to 0

            - check if y < -3.8:
                - set it to -3.8

            - check if x < -3.8:
                - set it to 3.8

            - check if x > 3.8:
                - set it to -3.8
            }

            */
        }
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -3.8f, 0), transform.position.z);
        //Mathf.Clamp returns either the variable's value, or the max value if the variable is larger than the max value, or the min 
        //value if the variable is less than the min value

        if (transform.position.x < -11.3f)
        {
            transform.position = new Vector3(11.3f, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > 11.3f)
        {
            transform.position = new Vector3(-11.3f, transform.position.y, transform.position.z);
        }
    }

    void FireLaser()
    {
        if (_tripleShotOn)
        {
            Instantiate(_tripleShotPrefab, transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(_laserPrefab, new Vector3(transform.position.x, transform.position.y + 0.8f, transform.position.z), Quaternion.identity);
        }
        _canFire = Time.time + _fireRate;
    }

    public void Damage()
    {
        _playerLives--;
        if( _playerLives <= 0)
        {
            _spawnManager.playerDead();
            Destroy(this.gameObject);
        }
    }
}
