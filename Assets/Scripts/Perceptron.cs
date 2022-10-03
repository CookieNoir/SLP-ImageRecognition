using UnityEngine;

public class Perceptron : MonoBehaviour
{
    [SerializeField] private WeightMatrices _weightMatrices;
    [SerializeField] private ActivationFunction _activationFunction;

    public float[] Calculate(float[,] imageValues, float weight0 = 0f)
    {
        int length = _weightMatrices.GetMatricesCount();
        float[] result = new float[length];

        for (int i = 0; i < length; ++i)
        {
            float sum = _weightMatrices.GetSum(i, imageValues, weight0);
            float activationResult = _activationFunction.GetResult(sum);
            result[i] = activationResult;
        }

        return result;
    }
}