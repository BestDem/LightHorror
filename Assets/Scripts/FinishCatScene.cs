using UnityEngine;
using UnityEngine.Playables;

public class FinishCatScene : MonoBehaviour, InteractObject
{
    [SerializeField] private PlayableDirector director;
    public void UseObject()
    {
        director.Play();
    }
}
