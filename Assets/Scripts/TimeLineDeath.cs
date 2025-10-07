using UnityEngine;
using UnityEngine.Playables;

public class TimeLineDeath : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject spawn;
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

    public void TeleportPlayer()
    {
        player.transform.position = spawn.transform.position;
    }
}
