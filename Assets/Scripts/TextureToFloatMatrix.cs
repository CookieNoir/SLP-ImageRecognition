using UnityEngine;

public static class TextureToFloatMatrix
{
    public static float[,] Convert(Texture2D texture, float colorThreshold = 0.5f)
    {
        float[,] result = new float[texture.width, texture.height];

        for (int x = 0; x < texture.width; ++x)
        {
            for (int y = 0; y < texture.height; ++y)
            {
                Color color = texture.GetPixel(x, y);
                float grayscale = color.r * 0.3f + color.g * 0.59f + color.b * 0.11f;
                float value = grayscale >= colorThreshold ? 1f : 0f;
                result[x, y] = value;
            }
        }

        return result;
    }
}