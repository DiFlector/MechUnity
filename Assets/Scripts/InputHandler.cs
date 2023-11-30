using LogitechG29.Core.Input;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private InputControllerReader _inputControllerReader;
    private void Start()
    {
        _inputControllerReader.OnHomeCallback = (_)
    }
}
