using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Animation Controllers", fileName = "Animation Controller")]
public class AnimationController : ScriptableObject
{
    public List<RuntimeAnimatorController> animControllers = new List<RuntimeAnimatorController>(4);
}