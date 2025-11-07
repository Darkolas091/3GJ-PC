using UnityEngine;
using UnityEngine.UI;

public class WinPanel : MonoBehaviour
{

    [SerializeField] private Image[] stars;
    [SerializeField] private Sprite emptyStar;
    [SerializeField] private Sprite fullStar;
    [SerializeField] private Sprite SpecialStar;
    [SerializeField] private SpecialCollectable specialCollectable;
    [SerializeField] private Image specialStarDisplay;
    private float starsAwarded;
    private float timeNeeded = 20;
    private float timeScored;

    public void StarsCollected(float time)
    {
        if (timeScored < timeNeeded * 0.25f)
        {
            starsAwarded = 3;
            
            Debug.Log("3 zvjezdice");
        }
        else if (timeScored < timeNeeded * 0.5f)
        {
            starsAwarded = 2;
            Debug.Log("2 zvjezdice");
        }
        else if (timeScored < timeNeeded * 0.75f)
        {
            starsAwarded = 1;
            Debug.Log("1 zvjezdica");
        }
        else
        {
            starsAwarded = 0;
            Debug.Log("0 zvjezdica");
        }

        DisplayStars();
    }

    private void DisplayStars()
    {
        for(int i = 0; i<starsAwarded; i++)
        {
            stars[i].sprite = fullStar;
        }
        if (specialCollectable.isCollected)
        {
            specialStarDisplay.sprite = SpecialStar;
        }
    }

}
