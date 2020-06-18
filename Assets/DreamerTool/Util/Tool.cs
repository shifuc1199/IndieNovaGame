using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
 
using UnityEngine.Networking;

using System;



//http://www.hko.gov.hk/cgi-bin/gts/time5a.pr?a=1 时间
 
 

namespace DreamerTool.Util
{
    public static class DreamerUtil
    {
       
        public static T GetScriptableObject<T>() where T:UnityEngine.ScriptableObject
        {
            return Resources.Load<T>("ScriptableObject/"+typeof(T).Name);
        }
        public static T GetScriptableObject<T>(string _name) where T : UnityEngine.ScriptableObject
        {
            return Resources.Load<T>("ScriptableObject/" + _name);
        }
        
        public static string GetColorRichText(string t,Color c)
        {
            return "<color=#"+ ColorUtility.ToHtmlStringRGBA(c) + ">" + t + "</color>";
        }
        public static string GetColorRichText(string t, string c)
        {
            return "<color=#" + c + ">" + t + "</color>";
        }

        public static System.Collections.IEnumerator GetDateTimeFromURL(UnityAction<System.DateTime> action)
        {
            UnityWebRequest webRequest = UnityWebRequest.Get("http://www.hko.gov.hk/cgi-bin/gts/time5a.pr?a=1");
            yield return webRequest.SendWebRequest();
            if(webRequest.isNetworkError)
            {
                yield break;
            }
             
            System.DateTime start =System.TimeZone.CurrentTimeZone.ToLocalTime( new System.DateTime(1970, 1, 1));
            start =  start.AddMilliseconds(long.Parse(webRequest.downloadHandler.text.Substring(2)));
            
            action(start);
            yield return  null;

        }
    
        public static double GetHurtValue(double a, double d)
        {
            if ((a + d) == 0)
                return 0;

            return a * a / (a + d);
        }
         
       
        public static List<int> GetRandomNonRepeat(List<int> temp, int number)
        {
            List<int> result = new List<int>();

            for (int i = 0; i < number; i++)
            {
                var index = UnityEngine.Random.Range(0, temp.Count);
                result.Add(temp[index]);
                temp.RemoveAt(index);
            }
            return result;
        }
      
    }
}
 

 
 
namespace DreamerTool.Extra
{
    
    public static class Extra
    { 
        
        public static T String2Enum<T>(this string enumName) where  T:  struct
        {
           
            return (T)Enum.Parse(typeof(T), enumName);
        }
        public static bool CurrentAnimClipIs(this Animator anim,string clip,int layer=0)
        {
            return anim.GetCurrentAnimatorStateInfo(layer).IsName(clip);
        }
        public static void Copy<Tkey, Tvalue>(this Dictionary<Tkey, Tvalue> dict, Dictionary<Tkey, Tvalue> copy_dict)
        {
            foreach (var item in copy_dict)
            {
                if (dict.ContainsKey(item.Key))
                    dict[item.Key] = item.Value;
                else
                    dict.Add(item.Key, item.Value);
            }
        }
        public static KeyValuePair<Tkey, Tvalue> Get<Tkey, Tvalue>(this Dictionary<Tkey, Tvalue> dict, int index)
        {
            int temp = 0;
            foreach (var item in dict)
            {

                if (temp == index)
                {
                    return item;
                }
                temp++;
            }
            return default;
        }
        public static List<int> GetKeys<Tvalue>(this Dictionary<int, Tvalue> dic)
        {
            List<int> temp = new List<int>();
            foreach (var item in dic)
            {
                temp.Add(item.Key);
            }
            return temp;
        }
        public static T GetLast<T>(this List<T> list)
        {
            if (list.Count == 0)
                return default;

            return list[list.Count - 1];
        }
        public static List<Transform> GetChildren(this Transform tran)
        {
            List<Transform> result = new List<Transform>();
            for (int i = 0; i <  tran.childCount; i++)
            {
                result.Add(tran.GetChild(i));
            }
            return result;
        }
        public static void ResetVelocity(this Rigidbody2D _rigi)
        {
            _rigi.velocity = Vector2.zero;
        }
        public static void SetPositionX(this Transform tran, float x)
        {
            tran.position = new Vector3(x, tran.position.y, tran.position.z);
        }
        public static void SetPositionY(this Transform tran, float y)
        {
            tran.position = new Vector3(tran.position.x, y, tran.position.z);
        }
        public static void SetPositionZ(this Transform tran, float z)
        {
            tran.position = new Vector3(tran.position.x, tran.position.y, z);
        }
        public static void ClearGravity(this Rigidbody2D _rigi)
        {
            _rigi.gravityScale = 0;
        }
        public static Color GetColorByString(this string color_s)
        {
            Color result;
            ColorUtility.TryParseHtmlString(color_s, out result);
            return result;
        }
        public static void SetGravity(this Rigidbody2D _rigi, float v)
        {
            _rigi.gravityScale = v;
        }
        public static bool IsAnim(this Animator animator, string name)
        {
            return animator.GetCurrentAnimatorStateInfo(0).IsName(name);
        }
    }
}

