using UnityEngine;

public class Cam : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject player;
    public int cam_euler_x = 90;
    public int cam_euler_y = 0;
    public int cam_euler_z = 0;
    public float cam_height = 10;    
    public float cam_vertical_distance = 0;
    public float cam_horizontal_distance = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position=player.transform.position  + new Vector3(cam_horizontal_distance, cam_height, cam_vertical_distance);
        transform.rotation=Quaternion.Euler(cam_euler_x, cam_euler_y, cam_euler_z);
        
    }
}
    