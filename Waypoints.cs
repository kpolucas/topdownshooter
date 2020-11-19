using UnityEngine;

public class Waypoints : MonoBehaviour
{
    // https://www.youtube.com/watch?v=aFxucZQ_5E4
    public static Transform[] points;

    private void Awake()
    {
        points = new Transform[transform.childCount];
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = transform.GetChild(i);
        }
    }
}
