using System.Text;
using UnityEngine;
using TMPro;

public class AnswerShower : MonoBehaviour
{
    [SerializeField] private TMP_Text _names;
    [SerializeField] private TMP_Text _results;

    public void UpdateValues(WeightMatrices weightMatrices, float[] results)
    {
        WeightMatrix[] matrices = weightMatrices.GetMatrices();
        string[] names = new string[matrices.Length];
        for (int i = 0; i < matrices.Length; ++i)
        {
            names[i] = matrices[i].name;
        }
        UpdateValues(names, results);
    }

    public void UpdateValues(string[] names, float[] results)
    {
        if (names.Length == results.Length)
        {
            StringBuilder namesBuilder = new StringBuilder();
            StringBuilder resultsBuilder = new StringBuilder();

            for (int i = 0; i < names.Length; ++i)
            {
                namesBuilder.Append(names[i]);
                namesBuilder.Append('\n');

                resultsBuilder.Append(results[i]);
                resultsBuilder.Append('\n');
            }

            _names.text = namesBuilder.ToString();
            _results.text = resultsBuilder.ToString();
        }
    }
}