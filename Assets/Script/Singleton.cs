using UnityEngine;


namespace Singleton
{
    /// <summary>
    /// 상속받을 시 싱글톤으로 만들어주는 클래스.
    /// </summary>
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        protected static T _instance = null;


        protected virtual void Awake()
        {

            if (_instance != null)
            {
                Debug.LogError((typeof(T)).ToString() + "Singleton Error");
                // Debug.LogError("Singleton error");
                return;
            }

            _instance = GetComponent<T>();
        }

        protected virtual void OnDestroy()
        {
            if (_instance != null)
            {
                _instance = null;
            }
        }

        public static T Instance
        {
            get
            {
                //현재 Scene에 없으면 하나 생성 후 인스턴스 리턴.
                /* 
                if (_instance == null)
                {
                    GameObject gbj = new GameObject();
                    gbj.transform.position = Vector3.zero;
                    gbj.transform.rotation = Quaternion.identity;
                    gbj.transform.localScale = Vector3.one;
                    _instance = gbj.AddComponent<T>();
                    gbj.name = (typeof(T)).ToString();

                }
                */
                return _instance;
            }
        }
    }
}
