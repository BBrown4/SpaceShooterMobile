using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private float parallaxSpeed;

    private float _spriteHeight;
    private Vector3 _startPosition;

    private void Start()
    {
        _startPosition = transform.position;
        _spriteHeight = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    private void Update()
    {
        transform.Translate(Vector3.down * (parallaxSpeed * Time.deltaTime));

        if (transform.position.y < _startPosition.y - _spriteHeight)
        {
            transform.position = _startPosition;
        }
    }
}
