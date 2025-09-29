using UnityEngine;

public class NotesManager : MonoBehaviour, InteractObject
{
    [SerializeField] private string textInNotes;
    public void UseObject()
    {
        InvenoryController.singltonInventory.ConclusionTextTiNote(textInNotes);
    }
}
