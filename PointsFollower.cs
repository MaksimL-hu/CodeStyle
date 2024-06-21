using UnityEngine;

public class PointsFollower : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _containerPoints;

    private Transform[] _points;
    private Transform _currentPoint;
    private int _index = 0;

    private void Start()
    {
        _points = new Transform[_containerPoints.childCount];

        for (int i = 0; i < _points.Length; i++)
            _points[i] = _containerPoints.GetChild(i);

        _currentPoint = _points[_index];
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _currentPoint.position, _speed * Time.deltaTime);

        if (transform.position == _currentPoint.position)
            GetNextPoint();
    }

    private void GetNextPoint()
    {
        _index = (++_index) % _points.Length;
        _currentPoint = _points[_index];
    }
}