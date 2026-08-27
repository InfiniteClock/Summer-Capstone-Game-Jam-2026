using UnityEngine;


public class GameplayManager : MonoBehaviour
{
    public static GameplayManager Instance;
    [field: SerializeField]
    public TheHand hand { get; private set; }

    [field: SerializeField]
    public bool useHandCursor { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        
        Instance = this;
    }
    private void OnValidate()
    {
        hand.UseHandCursor = useHandCursor;
    }

}
