using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public enum SortingColor { Magenta, Cyan, Yellow}
public class SortingObject : MonoBehaviour
{
    [field: SerializeField] public SortingColor SortColor {  get; private set; }
    public bool isSorted;

    private Vector3 minBounds = new Vector3(-10f, 1.5f, -2f);
    private Vector3 maxBounds = new Vector3(10f, 6f, 7f);
    private float timeToDie = 3f;
    private float killYLayer = -5f;

    private Vector3 mousePosition;
    private Camera cam;
    private Rigidbody rb;

    private Coroutine endRoutine;
    private void Start()
    {
        isSorted = false;
        cam = Camera.main;
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        CheckForKillLayer();
    }
    private Vector3 GetMousePos()
    {
        return cam.WorldToScreenPoint(transform.position);
    }

    private void OnMouseDown()
    {
        mousePosition = Input.mousePosition - GetMousePos();
    }
    private void OnMouseDrag()
    {
        Vector3 newPos = cam.ScreenToWorldPoint(Input.mousePosition - mousePosition);
        newPos.x = Mathf.Clamp(newPos.x, minBounds.x, maxBounds.x);
        newPos.y = Mathf.Clamp(newPos.y, minBounds.y, maxBounds.y);
        newPos.z = Mathf.Clamp(newPos.z, minBounds.z, maxBounds.z);

        transform.position = newPos;

        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z);
    }
    private void CheckForKillLayer()
    {
        if (!isSorted && transform.position.y < killYLayer)
        {
            Despawn();
        }
    }
    public void Despawn()
    {
        endRoutine ??= StartCoroutine(Countdown());
    }
    private IEnumerator Countdown()
    {
        yield return new WaitForSeconds(timeToDie);
        if (!isSorted)
        {
            Debug.Log("Lost object: " +gameObject.name+" to the void!");
        }
        Destroy(gameObject);
    }
}
