using UnityEngine;

public class Block : MonoBehaviour
{
    private Rigidbody rigid;

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
        GameManager.block.endEvent += OnEnd;
    }

    private void OnEnd()
    {
        rigid.linearVelocity = Vector3.up * 10f;
    }
}
