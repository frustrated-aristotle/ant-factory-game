using UnityEngine;
using UnityEditorInternal;

[ExecuteInEditMode]
public class ChangeComponentOrder : MonoBehaviour
{
    void Awake()
    {
        Debug.Log("a");
        // get the components attached to this object
        Component[] components = GetComponents<Component>();

        // reverse the order of the components
        System.Array.Reverse(components);

        // move the components up or down to change their order
        foreach (var component in components)
        {
            ComponentUtility.MoveComponentUp(component);
        }
    }
}