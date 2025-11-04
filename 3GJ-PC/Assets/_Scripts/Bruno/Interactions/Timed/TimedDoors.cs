using System.Collections;
using UnityEngine;

public class TimedDoors : MonoBehaviour,IActivatable
{

    [SerializeField] private float openSpeed = 3f;
    [SerializeField] private float stayOpenTime = 6f;
    private Coroutine autoCloseRoutine;
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
        if (!isOpen)
        {
            isOpen = true;
            StartShrink(openScale);
        }

        if (autoCloseRoutine != null)
        {
            StopCoroutine(autoCloseRoutine);
        }

        autoCloseRoutine = StartCoroutine(AutoClose());
    }

    public void Deactivate()
    {
        StartShrink(closedScale);
        isOpen = false;
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



    private IEnumerator AutoClose()
    {
        yield return new WaitForSeconds(stayOpenTime);
        Deactivate(); 
    }
}
