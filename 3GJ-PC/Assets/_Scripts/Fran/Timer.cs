using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
//    [SerializeField] private float currentTimerTime = 0.000f;
//    [SerializeField] private float timerTimeDecrement = 0.001f;
    [SerializeField] private float initialTimerTime = 0.0f;
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private float timer;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //        currentTimerTime = initialTimerTime;
        timer = initialTimerTime;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;
        timerText.text = timer.ToString("F2");
    }

    public float GetTime()
    {
        return timer;
    }

}
