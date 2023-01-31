using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private float _laserSpeed = 8f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, 1, 0) * _laserSpeed * Time.deltaTime);

        if(transform.position.y >= 8)
        {
            Destroy(this.gameObject);  
        }
    }
}
