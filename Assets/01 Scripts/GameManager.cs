using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] int enemySpawnCountdown = 4;
    [SerializeField] int numberOfEnemiesSpawned = 1;
    
    string _enemyTag;
    float _posOffset = 0.2f;

    private static GameManager _instance;
    public static GameManager Instance {  get { return _instance; } }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            return;
        }
        if (_instance.gameObject.GetInstanceID() != this.gameObject.GetInstanceID())
        {
            Destroy(this.gameObject);
        }
    }

    [SerializeField] GameObject _player;
    public GameObject Player {  get { return _player; } }

    private void Start()
    {
        StartCoroutine(EnemySpawnCoroutine());
    }

    private Vector3 RandomPos()
    {
        Vector3 pos  = Random.Range(0,1) == 1? RandomX() : RandomY();
        return pos;
    }    
    private Vector3 RandomX()
    {
        float posYOffScreen = 1 + _posOffset;
        float posY = Random.Range(0, 1) == 0 ? posYOffScreen : -posYOffScreen;
        float posX = Random.Range(0 - _posOffset, 1 + _posOffset);
        return Camera.main.ViewportToWorldPoint(new Vector3(posX, posY, 1));
    }
    private Vector3 RandomY()
    {
        float posXOffScreen = 1 + _posOffset;
        float posX = Random.Range(0,1) == 0? posXOffScreen : -posXOffScreen;
        float posY = Random.Range(0 - _posOffset, 1 + _posOffset);
        return Camera.main.ViewportToWorldPoint(new Vector3(posX,posY,1));
    }

    void SpawnEnemy()
    {
        GameObject enemy = EnemyPooling.Instance.GetEnemy();
        enemy.transform.position = RandomPos();
        enemy.transform.rotation = Quaternion.identity;
        enemy.GetComponentInChildren<SpriteRenderer>().color = RandomColor();
        enemy.tag = _enemyTag;
        enemy.SetActive(true);
        enemy.GetComponentInChildren<Animator>().SetInteger("FORM", Random.Range(0, 2));
    }
    void SpawnEnemies()
    {
         for(int i = 0; i < numberOfEnemiesSpawned; i++)
            {
                SpawnEnemy();
            }
    }
    IEnumerator EnemySpawnCoroutine()
    {
        while (true)
        {
            SpawnEnemies();
            yield return new WaitForSeconds(enemySpawnCountdown);
        }
    }
    Color RandomColor()
    {
        COLOR randomColor = (COLOR)Random.Range(1, 7);

        Color resultColor;

        switch (randomColor)
        {
            case COLOR.RED:
                resultColor = CONSTANTS.RED_COLOR;
                _enemyTag = CONSTANTS.RED_TAG;
                break;
            case COLOR.YELLOW:
                resultColor = CONSTANTS.YELLOW_COLOR;
                _enemyTag = CONSTANTS.YELLOW_TAG;
                break;
            case COLOR.BLUE:
                resultColor = CONSTANTS.BLUE_COLOR;
                _enemyTag = CONSTANTS.BLUE_TAG;
                break;
            case COLOR.ORANGE:
                resultColor = CONSTANTS.ORANGE_COLOR;
                _enemyTag = CONSTANTS.ORANGE_TAG;
                break;
            case COLOR.PURPLE:
                resultColor = CONSTANTS.PURPLE_COLOR;
                _enemyTag = CONSTANTS.PURPLE_TAG;
                break;
            case COLOR.GREEN:
                resultColor = CONSTANTS.GREEN_COLOR;
                _enemyTag = CONSTANTS.GREEN_TAG;
                break;
            default:
                resultColor = Color.white;
                break;
        }

        return resultColor;

    }
  

    enum COLOR
    {
        RED = 1,
        YELLOW = 2,
        BLUE = 3,
        ORANGE = 4,
        PURPLE = 5,
        GREEN = 6
    }
}
