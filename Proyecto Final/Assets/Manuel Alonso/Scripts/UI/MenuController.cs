using UnityEngine;

public class MenuController : MonoBehaviour
{
    public void PlayClip(AudioClip clip)
    {
        AudioManager.Instance.PlaySound(clip);
    }
}
