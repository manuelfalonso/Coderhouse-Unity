using UnityEngine;

public class SetAnimationParameter : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private string _floatParameter = default(string);
    [SerializeField] private string _boolParameter = default(string);

    public void SetFloatParameter(float parameterValue)
    {
        _animator.SetFloat(_floatParameter, parameterValue);
    }

    public void SetBoolParameter(bool parameterValue)
    {
        _animator.SetBool(_boolParameter, parameterValue);
    }
}
