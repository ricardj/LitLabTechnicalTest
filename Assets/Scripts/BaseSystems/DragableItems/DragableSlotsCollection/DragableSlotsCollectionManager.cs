using UnityEngine;

public class DragableSlotsCollectionManager : MonoBehaviour
{
    [SerializeField] DragableSlotsCollectionSO _dragableSlotsCollection;
    public void Awake()
    {
        _dragableSlotsCollection.Clear();
    }
}