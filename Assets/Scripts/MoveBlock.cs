using UnityEngine;

public class MoveBlock : MonoBehaviour
{
    private bool vertical;
    private bool horizontal;
    private float maxRange;

    private Vector3 target;
    private Vector3 movePos;
    private Rigidbody rigid;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        ChangePos();
        GameManager.SetComponent(this);
    }

    private void Update()
    {
        var thisPos = transform.position;

        //옆쪽 이동 검사
        if (horizontal)
        {
            if (thisPos.x < maxRange && !vertical) Direction();
            else if (thisPos.x > maxRange && vertical) Direction();
        }

        //앞쪽 이동 검사
        else
        {
            if (thisPos.z < maxRange && vertical) Direction();
            else if (thisPos.z > maxRange && !vertical) Direction();
        }
    }

    private void Direction()
    {
        //방향 전환
        var temp = movePos;
        movePos = target;
        target = temp;

        maxRange *= -1f;
        vertical = !vertical;
        rigid.linearVelocity = target - movePos;
    }

    public void ChangePos()
    {
        //모두 초기화
        movePos = Vector3.zero;
        target = Vector3.zero;
        rigid.linearVelocity = Vector3.zero;

        horizontal = !horizontal;
        vertical = false;

        //y
        movePos.y = this.transform.position.y + 0.2f;
        target.y = movePos.y;

        //x, z
        if (horizontal)
        {
            maxRange = -2f;
            target.x = -1.5f;
            movePos.x = 1.5f;
        }

        else
        {
            maxRange = 2f;
            target.z = 1.5f;
            movePos.z = -1.5f;
        }

        //할당
        this.transform.position = movePos;
        rigid.linearVelocity = target - movePos;
    }
}
