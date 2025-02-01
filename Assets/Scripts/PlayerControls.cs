using System;
using System.Collections;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;

public class PlayerControls : MonoBehaviour
{
    private Camera _mainCam;
    private Vector3 _offset;
    private float _maxLeft;
    private float _maxRight;
    private float _maxDown;
    private float _maxUp;
    private float _playerHalfSizeX;
    private float _playerHalfSizeY;

    private void OnEnable()
    {
        EnhancedTouchSupport.Enable();
    }

    private void OnDisable()
    {
        EnhancedTouchSupport.Disable();
    }

    private void Start()
    {
        _mainCam = Camera.main;
        StartCoroutine(SetBoundariesCoroutine());
    }

    private void Update()
    {
        if (Touch.activeTouches.Count > 0)
        {
            if (Touch.activeTouches[0].finger.index == 0)
            {
                var activeTouch = Touch.activeTouches[0];
                var touchPos = activeTouch.screenPosition;
                touchPos = _mainCam.ScreenToWorldPoint(touchPos);

                if (Touch.activeTouches[0].phase == TouchPhase.Began)
                {
                    _offset = touchPos - (Vector2)transform.position;
                }

                if (Touch.activeTouches[0].phase == TouchPhase.Moved || Touch.activeTouches[0].phase == TouchPhase.Stationary)
                {
                    transform.position = new Vector3(touchPos.x - _offset.x, touchPos.y - _offset.y, 0);
                }
            }
            
            var xPosClamped = Mathf.Clamp(transform.position.x, _maxLeft + _playerHalfSizeX, _maxRight - _playerHalfSizeX);
            var yPosClamped = Mathf.Clamp(transform.position.y, _maxDown + _playerHalfSizeY, _maxUp - _playerHalfSizeY);
            
            transform.position = new Vector3(xPosClamped, yPosClamped, 0f);
        }
    }
    
    [Button]
    private void SetBoundaries()
    {
        _maxLeft = _mainCam.ScreenToWorldPoint(Screen.safeArea.min).x;
        _maxRight = _mainCam.ScreenToWorldPoint(Screen.safeArea.max).x;
        
        _maxDown = _mainCam.ScreenToWorldPoint(Screen.safeArea.min).y;
        _maxUp = _mainCam.ScreenToWorldPoint(Screen.safeArea.max).y;

        _playerHalfSizeX = GetComponent<SpriteRenderer>().bounds.size.x / 2f;
        _playerHalfSizeY = GetComponent<SpriteRenderer>().bounds.size.y / 2f;
    }

    private IEnumerator SetBoundariesCoroutine()
    {
        yield return new WaitForSeconds(0.5f);
        SetBoundaries();
    }
}
