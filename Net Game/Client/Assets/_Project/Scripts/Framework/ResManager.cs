using UnityEngine;

public class ResManager : MonoBehaviour
{
    //����Ԥ��
    public static GameObject LoadPrefab(string path)
    {
        return Resources.Load<GameObject>(path);
    }
}
