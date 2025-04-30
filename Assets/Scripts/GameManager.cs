using UnityEngine;

public static class GameManager
{
    public static Controll player { get; private set; }
    public static CameraControll cam { get; private set; }
    public static MoveBlock moveBlock { get; private set; }

    public static void SetComponent(MonoBehaviour _component)
    {
        if (_component is Controll _isCon) player = _isCon;
        else if (_component is CameraControll _isCam) cam = _isCam;
        else if (_component is MoveBlock _isShowBlock) moveBlock = _isShowBlock;
    }
}
