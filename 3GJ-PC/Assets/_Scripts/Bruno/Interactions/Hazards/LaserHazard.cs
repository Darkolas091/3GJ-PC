using System.Collections;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(LineRenderer))]
public class LaserHazard : MonoBehaviour


{
    [Header("Laser Settings")]
    [SerializeField] private float laserLength = 1000f;
    [SerializeField] private float laserThickness = 3f;
    [SerializeField] private float fireInterval = 5f;   
    [SerializeField] private float laserDuration = 2f;
    [SerializeField] private GameObject particlePrefabStart;
    [SerializeField] private GameObject particlePrefabEnd;

    private GameObject particleCloneStart;
    private GameObject particleCloneEnd;

    private BoxCollider2D boxCollider;
    private LineRenderer lineRenderer;

    [SerializeField] private bool isVertical = false;

    private void Awake()
    {
        
        boxCollider = GetComponent<BoxCollider2D>();
        boxCollider.isTrigger = true;
        boxCollider.size = new Vector2(laserLength, laserThickness);
        boxCollider.enabled = false;


        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
        lineRenderer.startWidth = laserThickness;
        lineRenderer.endWidth = laserThickness;
        lineRenderer.enabled = false;

        particlePrefabStart.SetActive(false);
        particlePrefabEnd.SetActive(false);

        UpdateLinePositions();
    }

    private void Start()
    {
        StartCoroutine(FireLaserRoutine());
    }

    private void UpdateLinePositions()
    {
        Vector3 start;
        Vector3 end;
        if (isVertical)
        {
            start = transform.position - new Vector3(0, laserLength / 2, 0);
        end = transform.position + new Vector3(0, laserLength / 2, 0);
            boxCollider.size = new Vector2(laserThickness,laserLength);
        }
        else
        {
            start = transform.position - new Vector3(laserLength / 2, 0, 0);
            end = transform.position + new Vector3(laserLength / 2, 0, 0);
            boxCollider.size = new Vector2(laserLength, laserThickness);
        }

        lineRenderer.SetPosition(0, start);
        lineRenderer.SetPosition(1, end);

        particleCloneStart = Instantiate(particlePrefabStart, start, Quaternion.identity);
        particleCloneEnd = Instantiate(particlePrefabEnd,end, Quaternion.identity);
    }

    private IEnumerator FireLaserRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(fireInterval);

            boxCollider.enabled = true;
            lineRenderer.enabled = true;
            particleCloneStart.SetActive(true);
            particleCloneEnd.SetActive(true);
            yield return new WaitForSeconds(laserDuration);

            boxCollider.enabled = false;
            lineRenderer.enabled = false;
            particleCloneStart.SetActive(false);
            particleCloneEnd.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!boxCollider.enabled) return; 

        if (other.GetComponent<PlayerInputHandler>())
        {
            Destroy(other.gameObject);
            LevelManager.OnPlayerDeath?.Invoke();

        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector3 start = Vector3.zero;
        Vector3 end = Vector3.zero;

        if (isVertical)
        {
           start = transform.position - new Vector3(0, laserLength / 2, 0);
           end  = transform.position + new Vector3(0, laserLength / 2, 0);
        }

        else
        {
            start = transform.position - new Vector3(laserLength / 2, 0, 0);
            end = transform.position + new Vector3(laserLength / 2, 0, 0);
        }
        Gizmos.DrawLine(start, end);
    }
}

