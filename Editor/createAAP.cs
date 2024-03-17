using UnityEngine;
using UnityEditor;
public class AAP : MonoBehaviour
{
    [MenuItem("Pan/Sample_CreateAAP2")]
    private static void Sample_CreateAAP()
    {
        Debug.Log(createAAP("SampleAAP", 1f, "SampleAAP2", 2f, "SampleAAP3", 3f));
    }
    private static string createAAP(params object[] args)
    {
        var clipPath = $@"Assets/{args[0]}{args[1]}";
        AnimationClip animationClip = new AnimationClip();
        for (int i = 0; i < args.Length; i += 2)
        {
            string paramName = (string)args[i];
            float val = (float)args[i + 1];
            EditorCurveBinding curveBinding = EditorCurveBinding.FloatCurve("Animator", typeof(Animator), $"FloatParameter.{paramName}");
            AnimationCurve curve = new AnimationCurve(new Keyframe(0, val));
            AnimationUtility.SetEditorCurve(animationClip, curveBinding, curve);
            if (i == 2)
            {
                clipPath = $@"{clipPath}_";
            }
            clipPath = $@"{clipPath}{val}";
        }
        clipPath = $@"{clipPath}.anim";
        AssetDatabase.CreateAsset(animationClip, clipPath);
        return clipPath;
    }
}