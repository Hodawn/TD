using UnityEngine;
using UnityEngine.Splines;

public class SplineAnimationController : MonoBehaviour
{
    public SplineContainer splineContainer;
    public SplineAnimate splineAnimate;
    public float playSpeed = 1.0f;
    private bool isPlaying = false;
    public bool isLoop = false;
    public float duration;
    private float previousDuration;

    void Start()
    {
        if (splineAnimate == null)
        {
            splineAnimate = GetComponent<SplineAnimate>();
        }

        if (splineAnimate != null)
        {
            splineAnimate.NormalizedTime = 0f;
            splineAnimate.Play();
            splineAnimate.Pause();
        }

        previousDuration = duration;
    }

    void Update()
    {
        if (duration != previousDuration && splineAnimate != null)
        {
            float previousNormalizedTime = splineAnimate.NormalizedTime;
            previousDuration = duration;

            // Stop the animation and save the current progress
            splineAnimate.Pause();
            splineAnimate.NormalizedTime = previousNormalizedTime;

            // Change the duration
            splineAnimate.Duration = duration;

            // Restore the previous progress
            splineAnimate.NormalizedTime = previousNormalizedTime;

            // Resume the animation if it was playing
            if (isPlaying)
            {
                splineAnimate.Play();
            }
        }

        if (isPlaying && splineAnimate != null)
        {
            if (splineAnimate.NormalizedTime >= 1f)
            {
                splineAnimate.NormalizedTime = 1f;
                isPlaying = false;
                OnFinish();
            }
        }
    }

    public void Play()
    {
        if (splineAnimate != null)
        {
            splineAnimate.Play();
            isPlaying = true;
        }
    }

    public void Pause()
    {
        if (splineAnimate != null)
        {
            splineAnimate.Pause();
            isPlaying = false;
        }
    }

    public void ResetSpline()
    {
        if (splineAnimate != null)
        {
            splineAnimate.NormalizedTime = 0f;
            isPlaying = false;
        }
    }

    private void OnFinish()
    {
        Debug.Log("Spline animation finished.");
        ResetSpline();

        if (isLoop)
        {
            Play();
        }
    }
}