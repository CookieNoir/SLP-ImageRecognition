using UnityEngine;

public class Trainer : MonoBehaviour
{
    [SerializeField] private TestItem[] _testItems;
    [SerializeField] private TextureResizer _textureResizer;
    [SerializeField] private Perceptron _perceptron;
    [SerializeField] private WeightMatrices _weightMatrices;
    [SerializeField] private Vector2 _randomRange;
    [SerializeField] private float _weight0 = 0f;
    private float _colorThreshold;
    private float _learningRate;
    private Vector2Int _size;

    public void SetColorThreshold(float value)
    {
        _colorThreshold = value;
    }

    public void SetLearningRate(float value)
    {
        _learningRate = value;
    }

    public void SetSize(Vector2Int value)
    {
        _size = value;
    }

    public void Train()
    {
        _weightMatrices.RandomizeWeights(_size, _randomRange);

        int successCount = 0;
        while (successCount != _testItems.Length)
        {
            successCount = 0;
            for (int i = 0; i < _testItems.Length; ++i)
            {
                Texture2D resized = _textureResizer.ResizeTexture(_testItems[i].Texture, _size);
                float[,] imageValues = TextureToFloatMatrix.Convert(resized, _colorThreshold);
                float[] result = _perceptron.Calculate(imageValues, _weight0);

                bool success = true;
                for (int v = 0; v < result.Length; ++v)
                {
                    if (_testItems[i].expectedResult[v] != result[v])
                    {
                        _weightMatrices.RecalculateWeights(
                            FloatHelper.GetDifference(_testItems[i].expectedResult, result),
                            imageValues, _learningRate);
                        success = false;
                        break;
                    }
                }
                if (success) successCount++;
            }
        }

        Debug.Log("Successfully trained");
        _weightMatrices.LogMatrices();
    }
}