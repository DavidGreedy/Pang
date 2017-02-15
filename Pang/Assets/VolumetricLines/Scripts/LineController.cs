using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VolumetricLines;

public class LineController : Singleton<LineController>
{
    [SerializeField]
    private Color m_lineColor;

    [SerializeField]
    private float m_lineWidth;

    [SerializeField, Range(0, 1)]
    private float m_glowFactor;

    [SerializeField]
    private float glowSpeed;

    private float t = 0;

    float Hermite(float t)
    {
        return -t * t * t * 2f + t * t * 3f;
    }

    void Update()
    {
        foreach (VolumetricLineBehavior line in VolumetricLineBehavior.lines)
        {
            line.LineColor = m_lineColor;
            line.LineWidth = m_lineWidth;
            line.GlowFactor = Mathf.PingPong(Time.time, glowSpeed);
        }
    }

    public IEnumerator Score(int times)
    {
        for (int i = 0; i < times; i++)
        {
            foreach (VolumetricLineBehavior line in VolumetricLineBehavior.lines)
            {
                line.GlowFactor = Mathf.PingPong(Time.time, glowSpeed);
            }
            yield return new WaitForSeconds(1.0f / glowSpeed);
        }
        yield break;
    }
}