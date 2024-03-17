using UnityEngine;
using UnityEditor;
public class AAP : MonoBehaviour
{
    [MenuItem("Pan/Sample_CreateAAP")]
    private static void Sample_CreateAAP()
    {
        Debug.Log(createAAP("SampleAAP", 1));
    }
    private static string createAAP(string paramName, float val)
    {
        var clipPath = $@"Assets/{paramName}.anim";
        AnimationClip animationClip = new AnimationClip();
        EditorCurveBinding curveBinding = EditorCurveBinding.FloatCurve("Animator", typeof(Animator), $"FloatParameter.{paramName}");
        AnimationCurve curve = new AnimationCurve(new Keyframe(0, val));
        AnimationUtility.SetEditorCurve(animationClip, curveBinding, curve);
        AssetDatabase.CreateAsset(animationClip, clipPath);
        return clipPath;
    }
}