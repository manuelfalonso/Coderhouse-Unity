using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

[RequireComponent(typeof(PostProcessVolume))]
public class PostProcessExposer : MonoBehaviour
{
    private PostProcessVolume _volume;

    private AmbientOcclusion ambientOcclusion;
    private Bloom bloom;
    private DepthOfField depthOfField;
    private Grain grain;
    private Vignette vignette;

    void Start()
    {
        _volume = GetComponent<PostProcessVolume>();
    }

    public void ToggleAmbientOcclusion()
    {
        if (_volume == null)
            return;

        if (_volume.profile.TryGetSettings(out ambientOcclusion))
        {
            ambientOcclusion.active = !ambientOcclusion.active;
        }
    }

    public void ToggleBloom()
    {
        if (_volume == null)
            return;

        if (_volume.profile.TryGetSettings(out bloom))
        {
            bloom.active = !bloom.active;
        }
    }

    public void ToggleDepthOfField()
    {
        if (_volume == null)
            return;

        if (_volume.profile.TryGetSettings(out depthOfField))
        {
            depthOfField.active = !depthOfField.active;
        }
    }

    public void ToggleGrain()
    {
        if (_volume == null)
            return;

        if (_volume.profile.TryGetSettings(out grain))
        {
            grain.active = !grain.active;
        }
    }

    public void ToggleVignette()
    {
        if (_volume == null)
            return;

        if (_volume.profile.TryGetSettings(out vignette))
        {
            vignette.active = !vignette.active;
        }
    }
}
