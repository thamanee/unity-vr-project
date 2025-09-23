using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class DoorOpenSensor : MonoBehaviour
{
    public Transform PlayerTransform;

    public Animator DoorAnimator;

    public float Distance = 3;

    public UnityEvent OnDoorOpen;

    public UnityEvent OnDoorClose;

    private bool isDoorOpen;

    void OnDrawGizmosSelected()
    {

        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(transform.position, Distance);

    }
    void Start()
    {

        isDoorOpen = false;

    }

    void Update()
    {

        if (!isDoorOpen && Vector3.Distance(transform.position, PlayerTransform.position) < Distance)
        {

            DoorAnimator.Play("Open");

            isDoorOpen = true;

            OnDoorOpen?.Invoke();

        }

        else if (isDoorOpen && Vector3.Distance(transform.position, PlayerTransform.position) > Distance)

        {

            DoorAnimator.Play("Close");

            isDoorOpen = false;

            OnDoorClose?.Invoke();

        }
    }
}
