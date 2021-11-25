using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util
{
    public static T GetOrAddComponent<T>(GameObject go) where T : UnityEngine.Component
    {
        T component = go.GetComponent<T>(); //ItemIcon�� UI_EventHandler�� ������
        if (component == null)
            component = go.AddComponent<T>();
        return component;
    }
    public static GameObject FindChild(GameObject go, string name = null, bool reculsive = false)
    {
        //��� gameobject�� transform�� ������Ʈ�� ���� ������ �Ʒ��� ���ʸ����� ���� �Լ� Ȱ��
        Transform transform = FindChild<Transform>(go, name, reculsive);
        if (transform == null)
            return null;
        return transform.gameObject;
    }

    public static T FindChild<T>(GameObject go, string name = null, bool reculsive = false) where T : UnityEngine.Object
    {
        //�ֻ��� ������Ʈ�� go. name�� �̸��� ���� ��ü�� ã�µ� null�� �ϸ� �̸��� �Ⱥ��� Ÿ�Ը� ������ ã�� �ɷ� �Ѵ�. 
        //reculsiver�� true�̸� �ڽ��� �ڽĵ鿡���� ã���� false�̸� �ڽĿ����� ã��
        if (go == null)
            return null;
        if (reculsive == false)
        {
            for (int i = 0; i < go.transform.childCount; i++)//�����ڽ� ������ŭ for
            {
                Transform transform = go.transform.GetChild(i);
                if (string.IsNullOrEmpty(name) || transform.name == name)
                {
                    T component = transform.GetComponent<T>();
                    return component;
                }
            }
        }
        else
        {
            foreach (T component in go.GetComponentsInChildren<T>()) //�ش� type�� ������Ʈ�� ��� �ҷ���
            {
                if (string.IsNullOrEmpty(name) || component.name == name) //�ҷ��� component�� �̸��� ã��;��ϴ� �̸��� ������ �ٷ� ��ȯ
                    return component;
            }
        }

        return null;
    }

    // GameObject go�� child �� T�� ��ȯ�ϴ� list �Լ�
    public static List<T> FindChildTypeof<T>(GameObject go) where T : UnityEngine.Object
    {
        List<T> ChildList = new List<T>();
        Debug.Log($"Child Count {go.transform.childCount}");
        for(int i = 0; i < go.transform.childCount; i++){

            Transform transform = go.transform.GetChild(i);
            T component = transform.GetComponent<T>();
            if (component != null)
                ChildList.Add(component);
        }

        // go�� child �� T component�� ���� ��� 
        if (ChildList.Count == 0)
            return null;

        return ChildList;
    }
}
