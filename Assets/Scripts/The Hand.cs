using UnityEngine;

public class TheHand : MonoBehaviour
{
    
    [SerializeField] private Texture2D openHand;
    [SerializeField] private Texture2D closeHand;
    [SerializeField] private Vector2 hotspot = Vector2.zero;

    private bool useHandCursor;
    public bool UseHandCursor
    {
        get => useHandCursor;
        set
        {
            if (useHandCursor == value) return;

            useHandCursor = value;
            if (value == true)
                SetOpenHand();
            else
                ResetCursor();
        }
    }
    public void SetOpenHand()
    {
        Cursor.SetCursor(openHand, hotspot, CursorMode.Auto);
        //Debug.Log("Opening Hand");
    }
    public void SetClosedHand()
    {
        Cursor.SetCursor(closeHand, hotspot, CursorMode.Auto);
        //Debug.Log("Closing Hand");
    }
    private void ResetCursor()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}
