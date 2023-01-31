using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private GameObject _enemyContainer;
    private bool _playerDead = false;
    void Start()
    {
        //Instantiate(_enemy, new Vector3(Random.Range(-9.62f, 9.62f), 0, 0), Quaternion.identity);
        //Instantiate(_enemy, new Vector3(Random.Range(-9.62f, 9.62f), 0, 0), Quaternion.identity);
        StartCoroutine(SpawnRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnRoutine()
    {
        //int a = 0;
        while (!_playerDead)
        {
            GameObject var = Instantiate(_enemyPrefab, new Vector3(Random.Range(-9.62f, 9.62f), 7, 0), Quaternion.identity);
            var.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(5);
            //a++;
        }
    }

    public void playerDead()
    {
        _playerDead = true;
    }
}
