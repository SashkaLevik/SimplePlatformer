using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class Monster : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform[] _wayPoints;
    [SerializeField] private Transform _monster;

    private Vector2 _monsterScale;

    private int _turnRight = 1;
    private int _turnLeft = -1;
    private int _distance;
    private int _minDistance = 0;
    private int _maxDistance = 1;
    private float _distanceToPoint = 0.2f;

    private void Awake()
    {
        _monsterScale = _monster.localScale;
    }

    private void Update()
    {
        Patrol();
    }

    private void Patrol()
    {
        transform.position = Vector2.MoveTowards(transform.position, _wayPoints[_distance].position, _speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, _wayPoints[_distance].position) < _distanceToPoint)
        {
            ChangeDirection();
        }
    }

    private void FaceDirection(int direction)
    {
        _monster.localScale = new Vector2(Mathf.Abs(_monsterScale.x) * direction, _monsterScale.y);
    }
    
    private void ChangeDirection()
    {
        if (_distance > _minDistance)
        {
            _distance = _minDistance;
            FaceDirection(_turnRight);
        }
        else
        {
            _distance = _maxDistance;
            FaceDirection(_turnLeft);
        }
    }
}
