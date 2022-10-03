using UnityEngine;

public class GameObjectToggler : MonoBehaviour
{
    [SerializeField] private GameObject _targetObject;

    public void Toggle(bool value)
    {
        _targetObject.SetActive(value);
    }
}