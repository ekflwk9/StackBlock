using UnityEngine;

public class Controll : MonoBehaviour
{
    private void Awake()
    {
        GameManager.SetComponent(this);
    }

    private void Update()
    {
        Click();
    }

    private void Click()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            this.transform.position = this.transform.position + (Vector3.up * 0.2f);

            GameManager.cam.UpPos();
            GameManager.block.SetBlock();
            GameManager.moveBlock.ChangePos();
        }
    }
}
