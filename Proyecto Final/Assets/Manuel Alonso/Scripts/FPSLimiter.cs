using UnityEngine;

public static class FPSLimiter
{
    [RuntimeInitializeOnLoadMethod]
    private static void LimitFPS()
    {
        Application.targetFrameRate = 60;
    }
}
