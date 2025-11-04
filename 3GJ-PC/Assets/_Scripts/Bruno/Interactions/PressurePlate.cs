using UnityEngine;

public class PressurePlate : MonoBehaviour,ITrigger
{
    private PlayerInputHandler PlayerInputHandler;

    [SerializeField] private MonoBehaviour[] targets;
    private IActivatable[] activatables;
    private int objectsOnPlate;

    private void Awake()
    {
        activatables = new IActivatable[targets.Length];
        for (int i = 0; i < targets.Length; i++)
        {
            activatables[i] = targets[i] as IActivatable;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerInputHandler>())
        {
            objectsOnPlate++;
            if (objectsOnPlate == 1)
                Activate();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<PlayerInputHandler>())
        {
            objectsOnPlate--;
            if (objectsOnPlate <= 0)
                Deactivate();
        }
    }

    public void Activate()
    {
        foreach (var a in activatables)
        {
            a?.Activate();
        }
    }

    public void Deactivate()
    {
        foreach (var a in activatables)
        {
            a?.Deactivate();
        }
    }

}
