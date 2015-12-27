using UnityEngine;
using System.Collections;

public class PositionScaleLogic : MonoBehaviour
{
    public float ScaleToPosition(float scale, float scaleRef, float positionRef)
    {
        return (positionRef * scale) / scaleRef;
    }
    public float PositionToScale(float position, float scaleRef, float positionRef)
    {
        return (position * scaleRef) / positionRef;
    }
}