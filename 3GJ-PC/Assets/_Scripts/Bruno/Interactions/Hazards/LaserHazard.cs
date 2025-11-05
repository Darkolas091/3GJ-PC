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

    private BoxCollider2D boxCollider;
    private LineRenderer lineRenderer;

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

        UpdateLinePositions();
    }

    private void Start()
    {
        StartCoroutine(FireLaserRoutine());
    }

    private void UpdateLinePositions()
    {
        Vector3 start = transform.position - new Vector3(laserLength / 2, 0, 0);
        Vector3 end = transform.position + new Vector3(laserLength / 2, 0, 0);
        lineRenderer.SetPosition(0, start);
        lineRenderer.SetPosition(1, end);
    }

    private IEnumerator FireLaserRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(fireInterval);

            boxCollider.enabled = true;
            lineRenderer.enabled = true;

            yield return new WaitForSeconds(laserDuration);

            boxCollider.enabled = false;
            lineRenderer.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!boxCollider.enabled) return; 

        if (other.GetComponent<PlayerInputHandler>() || other.GetComponent<PlayerInputHandler>())
        {
            Destroy(other.gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector3 start = transform.position - new Vector3(laserLength / 2, 0, 0);
        Vector3 end = transform.position + new Vector3(laserLength / 2, 0, 0);
        Gizmos.DrawLine(start, end);
    }
}

