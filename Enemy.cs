using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _enemySpeed = 4f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _enemySpeed * Time.deltaTime);

        if(transform.position.y < -5.16f)
        {
            transform.position = new Vector3(Random.Range(-9.62f, 9.62f), 7.01f, transform.position.z);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            // damage the player
            Player player = other.gameObject.GetComponent<Player>();

            if (player != null)
                player.Damage();

            Destroy(this.gameObject);
        }

        else if (other.gameObject.CompareTag("Laser"))
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}