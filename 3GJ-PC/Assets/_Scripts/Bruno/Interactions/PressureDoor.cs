using System.Collections;
using UnityEngine;

public class Door : MonoBehaviour, IActivatable
{
    [SerializeField] private float openSpeed = 20f; // how fast it shrinks
    private Vector3 closedScale;
    private Vector3 openScale;
    private Coroutine moveRoutine;

    private bool isOpen = false;

    void Awake()
    {
        closedScale = transform.localScale;
        openScale = new Vector3(closedScale.x, 0f, closedScale.z);
    }

    public void Activate()
    {
        if (isOpen) return;
        isOpen = true;
        StartShrink(openScale);
        
    }

    public void Deactivate()
    {
        if (!isOpen) return;
        isOpen = false;
        StartShrink(closedScale);
    }

    private void StartShrink(Vector3 targetScale)
    {
        if (moveRoutine != null)
            StopCoroutine(moveRoutine);
        moveRoutine = StartCoroutine(ShrinkTo(targetScale));
    }

    private IEnumerator ShrinkTo(Vector3 targetScale)
    {
        while (Vector3.Distance(transform.localScale, targetScale) > 0.01f)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, targetScale, Time.deltaTime * openSpeed);
            yield return null;
        }
        transform.localScale = targetScale;
    }
}
