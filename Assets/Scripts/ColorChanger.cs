using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public Color myColor = Color.red;
    public GameObject head;

    void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            Color randomColor;
            Color forbiddenBlue;
            ColorUtility.TryParseHtmlString("#1715E7", out forbiddenBlue);

            // Keep picking a new color until it is NOT the blue you hate
            do
            {
                randomColor = Color.HSVToRGB(Random.value, 0.7f, 0.8f);
            } while (ColorsAreClose(randomColor, forbiddenBlue, 0.1f));

            renderer.material.SetColor("_BaseColor", randomColor);
            head.GetComponent<Renderer>().material.SetColor("_BaseColor", randomColor);
        }
    }

    // Helper function to see if colors are "too similar"
    bool ColorsAreClose(Color a, Color b, float threshold)
    {
        return Mathf.Abs(a.r - b.r) < threshold &&
               Mathf.Abs(a.g - b.g) < threshold &&
               Mathf.Abs(a.b - b.b) < threshold;
    }
}
