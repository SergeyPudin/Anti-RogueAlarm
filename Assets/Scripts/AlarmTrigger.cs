using UnityEngine;

public class AlarmTrigger : MonoBehaviour
{
    [SerializeField] private Alarm _alarm;

    private bool _isRobberInside = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Robber robber))
        {           
                _alarm.SoundOn();
                _isRobberInside = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Robber robber))
        {
            _alarm.SoundOff();
            _isRobberInside = false;
        }
    }
}