using UnityEngine;

public class RunCircle : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _allWayPoints;
    [SerializeField] private Transform[] _wayPoint;
    [SerializeField] private int _numberWayPoint;

    void Start()
    {
        _wayPoint = new Transform[_allWayPoints.childCount];

        for (int i = 0; i < _allWayPoints.childCount; i++)
        {
            _wayPoint[i] = _allWayPoints.GetChild(i).GetComponent<Transform>();
        }
    }

    public void Update()
    {
        Transform wayPoint = _wayPoint[_numberWayPoint];

        transform.position = Vector3.MoveTowards(transform.position, wayPoint.position, _speed * Time.deltaTime);

        if (transform.position == wayPoint.position)
        {
            GetNextWayPoint();
        }
    }

    public Vector3 GetNextWayPoint()
    {
        _numberWayPoint++;

        if (_numberWayPoint == _wayPoint.Length)
        {
            _numberWayPoint = 0;
        }

        Vector3 nextWayPoint = _wayPoint[_numberWayPoint].transform.position;

        transform.forward = nextWayPoint - transform.position;

        return nextWayPoint;
    }
}