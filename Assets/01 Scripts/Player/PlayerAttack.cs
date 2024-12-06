using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] CircleCollider2D _attackZone;
    [SerializeField] List<GameObject> _enemyInAtkZone = new List<GameObject>();

    [SerializeField] public string _colorWeapon = CONSTANTS.RED_TAG;
    [SerializeField] bool _isMixMode = false;
    [SerializeField] string _firstColor = null;
    [SerializeField] string _secondColor = null;

    // Start is called before the first frame update
    void Start()
    {
        _attackZone = this.GetComponent<CircleCollider2D>();
    }

    void Update()
    {
        Attack();
        ChooseWeaponColor();
    }

    private void ChooseWeaponColor()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            if (_isMixMode)
            {
                ConfirmMixColor();
            }
            else
            {
                EnterMixMode();
            }
        }

        if (_isMixMode)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                ToggleColor(CONSTANTS.RED_TAG);
            }
            if (Input.GetKeyDown(KeyCode.X))
            {
                ToggleColor(CONSTANTS.YELLOW_TAG);
            }
            if (Input.GetKeyDown(KeyCode.C))
            {
                ToggleColor(CONSTANTS.BLUE_TAG);
            }
            if (Input.GetKeyDown(KeyCode.B))
            {
                CancelMixMode();
            }
        }
        else
        {
            bool colorChanged = false;
            if (Input.GetKeyDown(KeyCode.Z))
            {
                _colorWeapon = CONSTANTS.RED_TAG;
                colorChanged = true;
            }
            if (Input.GetKeyDown(KeyCode.X))
            {
                _colorWeapon = CONSTANTS.YELLOW_TAG;
                colorChanged = true;
            }
            if (Input.GetKeyDown(KeyCode.C))
            {
                _colorWeapon = CONSTANTS.BLUE_TAG;
                colorChanged = true;
            }
            if (colorChanged)
            {
                Observer.Notify(CONSTANTS.NotMixMode_ACTION);
            }
        }
        Observer.Notify(CONSTANTS.ChooseColor_ACTION, _colorWeapon);
    }
    private void EnterMixMode()
    {
        _isMixMode = true;
        _firstColor = null;
        _secondColor = null;
        NotifyMixModeState();
        NotifyToggleColor();
    }
    private void CancelMixMode()
    {
        _isMixMode = false;
        _firstColor = null;
        _secondColor = null;
        NotifyMixModeState();
    }
    private void ToggleColor(string color)
    {
        if (_firstColor == null)
        {
            if (color != _secondColor)
                _firstColor = color;
            else _secondColor = null;
            NotifyToggleColor();
            return;
        }

        if (_firstColor == color)
        {
            _firstColor = null;
            NotifyToggleColor();
            return;
        }

        if (_secondColor == null)
        {
            _secondColor = color;
            NotifyToggleColor();
            return;
        }

        if (_secondColor == color)
        {
            _secondColor = null;
            NotifyToggleColor();
        }

    }
    private void ConfirmMixColor()
    {
        if (_firstColor != null && _secondColor != null)
        {
            if ((_firstColor == CONSTANTS.RED_TAG && _secondColor == CONSTANTS.YELLOW_TAG) ||
                (_firstColor == CONSTANTS.YELLOW_TAG && _secondColor == CONSTANTS.RED_TAG))
            {
                _colorWeapon = CONSTANTS.ORANGE_TAG;
                //_spriteRenderer.color = CONSTANTS.ORANGE_COLOR;
            }
            else if ((_firstColor == CONSTANTS.RED_TAG && _secondColor == CONSTANTS.BLUE_TAG) ||
                     (_firstColor == CONSTANTS.BLUE_TAG && _secondColor == CONSTANTS.RED_TAG))
            {
                _colorWeapon = CONSTANTS.PURPLE_TAG;
                //_spriteRenderer.color = CONSTANTS.PURPLE_COLOR;
            }
            else if ((_firstColor == CONSTANTS.YELLOW_TAG && _secondColor == CONSTANTS.BLUE_TAG) ||
                     (_firstColor == CONSTANTS.BLUE_TAG && _secondColor == CONSTANTS.YELLOW_TAG))
            {
                _colorWeapon = CONSTANTS.GREEN_TAG;

                //_spriteRenderer.color = CONSTANTS.GREEN_COLOR;
            }
            NotifyConfirmColor(_colorWeapon);
        }

        // Reset mix mode after confirmation
        CancelMixMode();
    }
    private void NotifyToggleColor()
    {
        Observer.Notify(CONSTANTS.SetMixColor_ACTION, _firstColor, _secondColor);
    }
    private void NotifyMixModeState()
    {
        Observer.Notify(CONSTANTS.SetMixMode_ACTION, _isMixMode);
    }
    private void NotifyConfirmColor(string color)
    {
        Observer.Notify(CONSTANTS.ConfirmColor_ACTION, color);
    }

    private void Attack()
    {
        List<GameObject> enemiesToDestroy = new List<GameObject>(_enemyInAtkZone);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            foreach (GameObject e in enemiesToDestroy)
            {
                if (e.CompareTag(_colorWeapon))
                {
                    e.SetActive(false);
                    AudioController.Instance.PlaySound("pop");
                    Observer.Notify(CONSTANTS.DestroyEnemy_ACTION);
                }
            }
            Observer.Notify(CONSTANTS.Attack_ACTION);
        }
        enemiesToDestroy = null;
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        string layerName = LayerMask.LayerToName(collision.gameObject.layer);
        if (layerName == CONSTANTS.ENEMY_LAYER)
        {
            _enemyInAtkZone.Add(collision.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
       
        string layerName = LayerMask.LayerToName(collision.gameObject.layer);
        if (layerName == CONSTANTS.ENEMY_LAYER)
        {
            _enemyInAtkZone.Remove(collision.gameObject);
        }
    }
}
