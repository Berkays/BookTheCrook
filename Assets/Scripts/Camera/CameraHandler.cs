using UnityEngine;
using Cinemachine;

public class CameraHandler : MonoBehaviour
{
    public CinemachineClearShot clearshotCamera;

    public void TrackPlayer(PlayerVariable Player)
    {
        var target = Player.Value.transform;

        clearshotCamera.LookAt = target;

        Debug.Log("Camera:Follow Player");
        //var target = FindObjectOfType<Player>().transform;
        //var camPosition = new Vector3(target.position.x,3,target.position.z - 3);
        // var cmBrain = this.gameObject.GetComponent<CinemachineBrain>();
        // cmBrain.ActiveVirtualCamera.LookAt = target;
        //this.transform.LookAt(target);
        //this.transform.position = camPosition;
    }
}
