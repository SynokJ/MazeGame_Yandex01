using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Pathfinding.Seeker))]
public class EnemyAI : MonoBehaviour, IStateListener
{
    [Header("Pathfinding Components:")]
    [SerializeField] private Transform _enemyGFX_Tr;
    [SerializeField] private float _nextWayPointDistance = 1.0f;

    [Header("Maze Target Points:")]
    [SerializeField] private List<Transform> _targets;
    private Transform _target;
    private Vector3 _lastTargetPos;

    public float _moveSpeed = 100.0f;

    private Pathfinding.Path _path;
    private int _currentWayPoint = 0;

    private Pathfinding.Seeker _seeker;
    private Rigidbody2D _rb;

    private Vector2 _dir;
    private Vector2 _force;

    private float _distance = 0.0f;

    private const float _DISTANCE_TO_ROTATE = 0.01f;

    private bool _canMove = false;

    private void OnEnable()
    {
        GameStateListener.Listen(this);
    }

    private void OnDisable()
    {
        GameStateListener.CloseListener(this);
    }

    void FixedUpdate()
    {
        if (!_canMove)
            return;

        if (_path == null)
            return;

        if (_currentWayPoint >= _path.vectorPath.Count)
        {
            while (_target.position == _lastTargetPos)
                _target = _targets[Random.Range(0, _targets.Count)];
            _lastTargetPos = _target.position
                ;
            _currentWayPoint = 0;
        }

        _dir = ((Vector2)_path.vectorPath[_currentWayPoint] - _rb.position).normalized;
        _force = _dir * _moveSpeed * Time.deltaTime;

        _rb.AddForce(_force);

        _distance = Vector2.Distance(_rb.position, _path.vectorPath[_currentWayPoint]);

        if (_distance < _nextWayPointDistance)
            _currentWayPoint++;


    }

    private void StartMovement()
    {
        _seeker = GetComponent<Pathfinding.Seeker>();
        _rb = GetComponent<Rigidbody2D>();

        _target = _targets[Random.Range(0, _targets.Count)];
        _lastTargetPos = _target.position;

        InvokeRepeating("UpdatePath", 0.0f, 1f);
        InvokeRepeating("UpdateRotation", 0.0f, 1f);
    }

    private void UpdatePath()
    {
        if (_seeker.IsDone())
            _seeker.StartPath(_rb.position, _target.position, OnPathComplete);
    }

    private void UpdateRotation()
    {
        if (_force.x >= _DISTANCE_TO_ROTATE)
            _enemyGFX_Tr.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if (_force.x <= -_DISTANCE_TO_ROTATE)
            _enemyGFX_Tr.localScale = new Vector3(1.0f, 1.0f, 1.0f);
    }

    private void OnPathComplete(Pathfinding.Path path)
    {
        if (!path.error)
        {
            _path = path;
            _currentWayPoint = 0;
        }
    }

    public void OnGameStarted()
    {
        StartMovement();
        _canMove = true;
    }

    public void OnGameFinished()
    {
        _canMove = false;
    }
}
