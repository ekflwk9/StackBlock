using UnityEngine;

public class Service
{
    public static Transform FindChild(Transform _parent, string _name)
    {
        Transform findChild = null;

        for (int i = 0; i < _parent.childCount; i++)
        {
            var child = _parent.GetChild(i);
            findChild = child.name == _name ? child : FindChild(child, _name);
            if (findChild != null) break;
        }

        return findChild;
    }
}
