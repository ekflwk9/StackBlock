using UnityEngine;

public class BlockManager : MonoBehaviour
{
    [SerializeField] private int blockCount = 100;
    private int count;

    private Block[] block;
    public event Func endEvent;

    private void Awake()
    {
        var tempBlock = Resources.Load<Block>("Block");
        block = new Block[blockCount];

        for (int i = 0; i < blockCount; i++)
        {
            var cloneBlock = Instantiate(tempBlock, new Vector3(3f, (float)i, -3f), Quaternion.identity);
            block[i] = cloneBlock;
        }

        GameManager.SetComponent(this);
    }

    public void SetBlock()
    {
        //현재 어느 방향으로 움직이고 있는가?
        var moveBlock = GameManager.moveBlock.transform;
        var blockPos = moveBlock.position;
        var pos = blockPos.x == 0 ? blockPos.z : blockPos.x;

        //게임 종료 검사
        if (CheckEndGame(pos))
        {
            endEvent?.Invoke();
            return;
        }

        count++;
        var index = count == block.Length ? 0 : count;

        block[index].transform.rotation = Quaternion.identity;
        //block[index].transform.localScale = ;
        //GameManager.moveBlock.transform.localScale = Vector3.zero;
        block[index].transform.position = blockPos;
    }

    private bool CheckEndGame(float _pos)
    {
        //현재 음수인가 양수인가?
        var movePos = _pos < 0 ? _pos * -1 : _pos;

        if (movePos > 3f) return true;
        else return false;
    }
}
