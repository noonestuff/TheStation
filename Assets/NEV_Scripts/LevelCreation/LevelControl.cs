using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelControl : MonoBehaviour
{
    public static LevelControl thisInstance;
    public GameObject m_PlayerPrefab;
    public GameObject m_currentPlayer;

    private GameObject usingPlayer;
    // Start is called before the first frame update
    void Awake()
    {

        thisInstance = this;


#if UNITY_EDITOR
        if (Application.isEditor)
        {
            PlayFromEditor playfrom = ScriptableObject.CreateInstance<PlayFromEditor>();
            playfrom = UnityEditor.AssetDatabase.LoadAssetAtPath("Assets/PlayFromEditor.asset", typeof(PlayFromEditor)) as PlayFromEditor;

            if (playfrom != null && playfrom.IsPlayFromHere)
            {
                Destroy(m_currentPlayer.gameObject);

                usingPlayer = GameObject.Instantiate(m_PlayerPrefab);

                m_PlayerPrefab.transform.position = new Vector3(playfrom.StartPos.x, playfrom.StartPos.y, playfrom.StartPos.z);
                playfrom.IsPlayFromHere = false;


            }
            else
            {
                usingPlayer = m_PlayerPrefab;
            }
        }
#endif
    }

    public GameObject GetPlayer()
    {
        return usingPlayer;
    }

   
}
