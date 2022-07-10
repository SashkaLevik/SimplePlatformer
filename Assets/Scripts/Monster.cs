using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class Monster : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform[] _wayPoints;
    [SerializeField] private Transform _monster;
    private int _distance;
    private Vector2 _monsterScale;

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

        if (Vector2.Distance(transform.position, _wayPoints[_distance].position) < 0.2f)
        {
            if (_distance > 0)
            {
                _distance = 0;
                FaceDirection(1);
            }
            else
            {
                _distance = 1;
                FaceDirection(-1);
            }
        }
    }

    private void FaceDirection(int direction)
    {
        _monster.localScale = new Vector2(Mathf.Abs(_monsterScale.x) * direction, _monsterScale.y);
    }    
}
