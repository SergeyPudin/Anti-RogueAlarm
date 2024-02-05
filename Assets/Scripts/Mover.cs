using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Transform _waypointContainer;

    private Transform[] _waypoints;
    private int _waypointIndex = 0;

    private void Start()
    {
        _waypoints = new Transform[_waypointContainer.childCount];

        for (int i = 0; i < _waypointContainer.childCount; i++)
            _waypoints[i] = _waypointContainer.GetChild(i).GetComponent<Transform>();
    }

    private void Update()
    {
        if (_waypointIndex >= _waypoints.Length)
            return;

        Transform target = _waypoints[_waypointIndex];

        transform.position = Vector3.MoveTowards(transform.position, target.position, _moveSpeed * Time.deltaTime);

        if (transform.position == target.position)
            _waypointIndex++;
    }
}