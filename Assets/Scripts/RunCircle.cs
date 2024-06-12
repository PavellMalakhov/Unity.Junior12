using UnityEngine;

public class RunCircle : MonoBehaviour
{
    [SerializeField] private Transform _allWayPoints;
    [SerializeField] private Transform[] _wayPoints;
    [SerializeField] private float _speed = 10;
    [SerializeField] private int _numberWayPoint;

    public void Awake()
    {
        _wayPoints = new Transform[_allWayPoints.childCount];

        for (int i = 0; i < _allWayPoints.childCount; i++)
        {
            _wayPoints[i] = _allWayPoints.GetChild(i);
        }
    }

    public void Update()
    {
        if (transform.position == _wayPoints[_numberWayPoint].position)
        {
            _numberWayPoint = (_numberWayPoint + 1) % _wayPoints.Length;
        }

        transform.position = Vector3.MoveTowards(transform.position, _wayPoints[_numberWayPoint].position, _speed * Time.deltaTime);
        transform.forward = Vector3.MoveTowards(transform.forward, _wayPoints[_numberWayPoint].position - transform.position, _speed * Time.deltaTime);
    }
}