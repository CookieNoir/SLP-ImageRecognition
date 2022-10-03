using UnityEngine;
using System.Text;

public class WeightMatrix : MonoBehaviour
{
    private float[,] _weights;

    public void RandomizeWeights(Vector2Int size, Vector2 randomRange)
    {
        _weights = new float[size.x, size.y];
        for (int x = 0; x < size.x; x++)
        {
            for (int y = 0; y < size.y; y++)
            {
                _weights[x, y] = Random.Range(randomRange.x, randomRange.y);
            }
        }
    }

    public float GetSum(float[,] imageValues, float w0 = 0f)
    {
        float result = w0;
        for (int x = 0; x < _weights.GetLength(0); ++x)
        {
            for (int y = 0; y < _weights.GetLength(1); ++y)
            {
                result += _weights[x,y] * imageValues[x, y];
            }
        }
        return result;
    }

    public void RecalculateWeights(float difference, float[,] imageValues, float learningRate)
    {
        for (int x = 0; x < _weights.GetLength(0); ++x)
        {
            for (int y = 0; y < _weights.GetLength(1); ++y)
            {
                _weights[x, y] += difference * learningRate * imageValues[x, y];
            }
        }
    }

    public override string ToString()
    {
        int startCapacity = 7 * _weights.GetLength(0) * _weights.GetLength(1);
        StringBuilder stringBuilder = new StringBuilder(startCapacity);
        for (int y = _weights.GetLength(1) - 1; y >= 0; --y)
        {
            for (int x = 0; x < _weights.GetLength(0); ++x)
            {
                stringBuilder.Append(_weights[x, y].ToString("F3"));
                stringBuilder.Append(' ');
            }
            stringBuilder.Append('\n');
        }
        return stringBuilder.ToString();
    }
}