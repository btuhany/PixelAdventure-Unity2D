using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingPlatformController : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 2f;
    [SerializeField] Vector2 _direction;
    [SerializeField] float _length;
    
    Vector3 _offset;
    float sinWave;
  
    private void Update()
    {
        sinWave = Mathf.Sin(Time.time * _moveSpeed);
        _offset = _direction.normalized * _length * sinWave;
        
        transform.position += _offset*Time.deltaTime;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.collider.transform.SetParent(transform);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.collider.transform.SetParent(null);
    }
}
