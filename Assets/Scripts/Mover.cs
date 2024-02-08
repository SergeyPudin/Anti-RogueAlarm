using System.Collections;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Transform _waypointContainer;

    private Transform[] _waypoints;
    
    private void Awake()
    {
        _waypoints = new Transform[_waypointContainer.childCount];

        for (int i = 0; i < _waypointContainer.childCount; i++)
            _waypoints[i] = _waypointContainer.GetChild(i);
    }

    private void Start()
    {
        StartCoroutine(MoveToWaypoint());
    }

    private IEnumerator MoveToWaypoint()
    {
        Transform target;
        int waypointIndex = 0;

        while (waypointIndex != _waypoints.Length)
        {
            target = _waypoints[waypointIndex];

            transform.position = Vector3.MoveTowards(transform.position, target.position, _moveSpeed * Time.deltaTime);

            if (transform.position == target.position)
                waypointIndex++;

            yield return null;
        }
    }
}