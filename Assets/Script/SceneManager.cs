using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Container
{
    public class SceneManager : MonoBehaviour
    {

        public enum SceneState
        {
            Main = 0,
            Item = 1,
            Map = 2,
            Stage = 3,
            game = 4,
            End,
        }

        /// <summary>
        /// testmode
        /// </summary>
        public SceneState testscene;

        /// <summary>
        /// all of scene gameobject
        /// </summary>
        [SerializeField]
        GameObject[] gamepannel;

        /// <summary>
        /// now scene state
        /// </summary>
        [SerializeField]
        SceneState nowstate = SceneState.Main;

        /// <summary>
        /// setting map prefab`
        /// </summary>
        [SerializeField]
        GameObject mapprefab;

        private void Awake()
        {
            DontDestroyOnLoad(transform.gameObject);
        }
        // Use this for initialization
        void Start()
        {

        }

        /// <summary>
        /// change scene
        /// </summary>
        /// <param name="state"> scene number </param>
        public void ChangeScene(SceneState state)
        {
            for (int i = 0; i < gamepannel.Length; ++i)
            {
                if (i == (int)state)
                    gamepannel[i].SetActive(true);
                else
                    gamepannel[i].SetActive(false);
            }
        }

        /// <summary>
        /// load map prefab
        /// </summary>
        /// <param name="prefabname"> prefab name </param>
        public void setprefab(string prefabname)
        {
            mapprefab = Resources.Load(prefabname) as GameObject;
        }
        
    }
}
