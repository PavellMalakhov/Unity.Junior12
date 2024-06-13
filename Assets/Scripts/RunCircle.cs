using UnityEngine;

public class RunCircle : MonoBehaviour
{
    [SerializeField] private Transform _containerPoints;
    [SerializeField] private Transform[] _wayPoints;
    [SerializeField] private float _speed = 10;
    [SerializeField] private int _indexWayPoint;

    public void Awake()
    {
        _wayPoints = new Transform[_containerPoints.childCount];

        for (int i = 0; i < _wayPoints.Length; i++)
        {
            _wayPoints[i] = _containerPoints.GetChild(i);
        }
    }

    public void Update()
    {
        if (transform.position == _wayPoints[_indexWayPoint].position)
        {
            _indexWayPoint = (_indexWayPoint + 1) % _wayPoints.Length;
        }

        transform.position = Vector3.MoveTowards(transform.position, _wayPoints[_indexWayPoint].position, _speed * Time.deltaTime);
        transform.forward = Vector3.MoveTowards(transform.forward, _wayPoints[_indexWayPoint].position - transform.position, _speed * Time.deltaTime);
    }
}