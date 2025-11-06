using UnityEngine;

public class Elevator : MonoBehaviour, IActivatable
{
    [SerializeField] private float moveDistance = 5f;   
    [SerializeField] private float moveSpeed = 2f;      
    private Vector3 startPos;
    private Vector3 targetPos;
    private Coroutine moveRoutine;

    private void Awake()
    {
        startPos = transform.position;
        targetPos = startPos + Vector3.up * moveDistance;
    }

    public void Activate()
    {
        StartMove(targetPos);
    }

    public void Deactivate()
    {
        StartMove(startPos);
    }

    private void StartMove(Vector3 destination)
    {
        if (moveRoutine != null)
            StopCoroutine(moveRoutine);

        moveRoutine = StartCoroutine(MoveTo(destination));
    }

    private System.Collections.IEnumerator MoveTo(Vector3 destination)
    {
        while (Vector3.Distance(transform.position, destination) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                destination,
                moveSpeed * Time.deltaTime
            );
            yield return null;
        }
        transform.position = destination;
    }


}
