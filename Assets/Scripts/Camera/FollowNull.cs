using Cinemachine;
using UnityEngine;

public class FollowNull : MonoBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera cmCam;

    private void Awake()
    {
        cmCam = GetComponent<CinemachineVirtualCamera>();
    }

    public void StopFollowing()
    {
        cmCam.Follow = null;
    }
}
