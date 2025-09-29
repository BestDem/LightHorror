using UnityEngine;
using UnityEngine.Playables;

public class TimeLineDeath : MonoBehaviour
{
    public static TimeLineDeath singeltonDeath { get; private set; }
    [SerializeField] private PlayableDirector director;
    private void Start()
    {
        if (singeltonDeath == null)
            singeltonDeath = this;
        else if (singeltonDeath == this)
            Destroy(gameObject);
    }
    public void Death()
    {
        director.Play();
    }
}
