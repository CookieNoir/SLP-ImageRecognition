using UnityEngine;

public class WeightsButtonCreatorStarter : MonoBehaviour
{
    [SerializeField] private WeightMatrices _weightMatrices;
    [SerializeField] private WeightsButtonCreator _creator;
    [SerializeField] private TextSetter _textSetter; 

    private void Start()
    {
        CreateButtons();
    }

    public void CreateButtons()
    {
        WeightMatrix[] weightMatrices = _weightMatrices.GetMatrices();
        string[] names = new string[weightMatrices.Length];
        for (int i = 0; i < names.Length; ++i)
        {
            names[i] = weightMatrices[i].name;
        }
        _creator.CreateButtons(names, weightMatrices, _textSetter.SetText);
    }
}