using UnityEngine;

public class CustomSound
{
    public AudioClip AudioClip;
    public float Volume = 1;
    public bool b_IsLoop = false;

    public bool b_RandomPitch = false;
    public float MaxPitchRandomness = 0.15f;

    public float Delay = 0;

    public bool b_IsLocated = false;
    public Vector3 AudioPosition = Vector3.zero;
    public float MaxDistance = 500;

    public string Category = "none";
}
