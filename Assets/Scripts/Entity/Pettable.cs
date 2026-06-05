using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Pettable : MonoBehaviour
{
    [SerializeField] private float _duration = 0.3f;
    [SerializeField] private float _reductionPercent = 0.1f;
    [SerializeField] private AudioClip _petClip;

    private bool _canPet = true;

    private AudioSource _audioSource;
    private Vector3 _initialScale;

    private void Start()
    {
        _initialScale = transform.localScale;

        _audioSource = GetComponent<AudioSource>();
    }

    public void Pet()
    {
        if (!_canPet) return;

        transform.localScale = _initialScale;

        if (_petClip) _audioSource.PlayOneShot(_petClip);

        _canPet = false;

        StopAllCoroutines();
        StartCoroutine(ScaleRoutine());
    }

    private IEnumerator ScaleRoutine()
    {
        yield return ScaleTo(_initialScale.y * (1 - _reductionPercent));
        yield return ScaleTo(_initialScale.y);

        _canPet = true;
    }

    private IEnumerator ScaleTo(float targetY)
    {
        var currentTime = 0f;
        var startY = transform.localScale.y;

        while (currentTime < _duration)
        {
            currentTime += Time.deltaTime;
            var newY = Mathf.Lerp(startY, targetY, currentTime / _duration);

            transform.localScale = new Vector3(_initialScale.x, newY, _initialScale.z);
            yield return null;
        }

        transform.localScale = new Vector3(_initialScale.x, targetY, _initialScale.z);
    }
}