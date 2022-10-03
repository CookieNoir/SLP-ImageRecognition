using UnityEngine;

public class SingleImageRecognition : MonoBehaviour
{
    [SerializeField] private TextureHandler _textureHandler;
    [SerializeField] private Perceptron _perceptron;
    [SerializeField] private WeightMatrices _weightMatrices;
    [SerializeField] private AnswerShower _answerShower;
    [SerializeField] private float _weight0 = 0f;
    private float _colorThreshold;

    public void SetColorThreshold(float value)
    {
        _colorThreshold = value;
    }

    public void Recognize()
    {
        Texture2D texture = _textureHandler.ResizedTexture2D;
        if (texture)
        {
            float[,] imageValues = TextureToFloatMatrix.Convert(texture, _colorThreshold);
            float[] result = _perceptron.Calculate(imageValues, _weight0);
            _answerShower.UpdateValues(_weightMatrices, result);
        }
    }
}