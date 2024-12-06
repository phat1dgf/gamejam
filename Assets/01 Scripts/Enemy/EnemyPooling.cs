using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPooling : MonoBehaviour
{
    private static EnemyPooling _instance;
    public static EnemyPooling  Instance {  get { return _instance; } }

    [SerializeField] GameObject _enemyPrefab;
    [SerializeField] List<GameObject> _enemyPool = new List<GameObject>();
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            return;
        }
        if (_instance.gameObject.GetInstanceID() == this.gameObject.GetInstanceID())
        {
            Destroy(this.gameObject);
        }
    }
    
    public GameObject GetEnemy()
    {
        foreach (GameObject enemy in _enemyPool)
        {
            if (enemy.activeSelf)
            {
                continue;
            }
            return enemy;
        }

        GameObject g = Instantiate(_enemyPrefab,this.transform.position,Quaternion.identity);
        _enemyPool.Add(g);
        g.SetActive(false);
        return g;
    }
}
