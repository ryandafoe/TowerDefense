using UnityEngine;

public class CameraController : MonoBehaviour
{
    //pan speed, controlls the speed youo can move
    public float panSpeed = 5f;
    public float panBoarderThickness = 15f;

    //see if were too fat
    bool move = true;

    public float scrollSpeed = 1f;
    public float minY = 10f;
    public float maxY = 20f;

    // Update is called once per frame
    void Update()
    {

        if(GameManager.gameEnd)
        {
            this.enabled = false;
            return;
        }
        //press escape to make it so we cant move
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            move = !move;
        }
        //if we cant move dont move
        if (!move)
        {
            return;
        }

        //look for key press. W or if the mouse is at the top of the screen
        if(Input.GetKey("w") )//|| Input.mousePosition.y >= Screen.height - panBoarderThickness)
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("s"))// || Input.mousePosition.y <= panBoarderThickness)
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("d") )//|| Input.mousePosition.x >= Screen.width - panBoarderThickness)
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("a") )//|| Input.mousePosition.x <= panBoarderThickness)
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }


        //scroll to zoom in
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        // Debug.Log(scroll);
        Vector3 pos = transform.position;

        

        pos.y -= scroll * 500 * scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        transform.position = pos;

    }
}
