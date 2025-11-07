using UnityEngine;


public class ExtrasManager : MonoBehaviour
{
    [SerializeField] private GameObject extrasPagePanel1;
    [SerializeField] private GameObject extrasPagePanel2;
    [SerializeField] private GameObject extrasPagePanel3;

    [SerializeField] private int totalNumberOfExtrasPages = 3;
    [SerializeField] private int currentExtrasPage = 0;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        


    }

    public void PreviousExtrasPage()
    {
        currentExtrasPage--;
        if (currentExtrasPage < 0)
        {
            currentExtrasPage = 0;
        }
    }

    public void NextExtrasPage()
    {
        currentExtrasPage++;
        if (currentExtrasPage >= totalNumberOfExtrasPages - 1)
        {
            currentExtrasPage = totalNumberOfExtrasPages - 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (currentExtrasPage == 0)
        {
            extrasPagePanel1.SetActive(true);
            extrasPagePanel2.SetActive(false);
            extrasPagePanel3.SetActive(false);
        }
        else if (currentExtrasPage == 1)
        {
            extrasPagePanel1.SetActive(false);
            extrasPagePanel2.SetActive(true);
            extrasPagePanel3.SetActive(false);
        }
        else
        {
            extrasPagePanel1.SetActive(false);
            extrasPagePanel2.SetActive(false);
            extrasPagePanel3.SetActive(true);
        }
        
    }
}
