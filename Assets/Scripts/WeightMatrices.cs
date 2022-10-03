using UnityEngine;

public class WeightMatrices : MonoBehaviour
{
    [SerializeField] private WeightMatrix[] _matrices;

    public int GetMatricesCount()
    {
        return _matrices.Length;
    }

    public WeightMatrix[] GetMatrices()
    {
        return _matrices;
    }

    public void RandomizeWeights(Vector2Int size, Vector2 randomRange)
    {
        for (int i = 0; i < _matrices.Length; ++i) 
            _matrices[i].RandomizeWeights(size, randomRange);
    }

    public float GetSum(int index, float[,] imageValues, float w0 = 0f)
    {
        return _matrices[index].GetSum(imageValues, w0);
    }

    public void RecalculateWeights(float[] difference, float[,] imageValues, float learningRate)
    {
        for (int i = 0; i < _matrices.Length; ++i)
        {
            if (!Mathf.Approximately(difference[i], 0f)) 
                _matrices[i].RecalculateWeights(difference[i], imageValues, learningRate); 
        }
    }

    public void LogMatrices()
    {
        for (int i = 0; i < _matrices.Length; ++i)
            Debug.Log(_matrices[i].ToString());
    }
}