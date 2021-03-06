using HauntedPSX.RenderPipelines.PSX.Runtime;
using UnityEditor;
using UnityEditor.Rendering;

namespace HauntedPSX.RenderPipelines.PSX.Editor
{
    [CanEditMultipleObjects]
    [VolumeComponentEditor(typeof(LightingVolume))]
    public class LightingVolumeEditor : VolumeComponentEditor
    {
        private SerializedDataParameter m_LightingIsEnabled;
        private SerializedDataParameter m_BakedLightingMultipler;
        private SerializedDataParameter m_VertexColorLightingMultiplier;
        private SerializedDataParameter m_DynamicLightingMultiplier;
        private SerializedDataParameter m_DynamicLightsMaxCount;
        private SerializedDataParameter m_DynamicLightsMaxPerObjectCount;

        public override void OnEnable()
        {
            var o = new PropertyFetcher<LightingVolume>(serializedObject);
            m_LightingIsEnabled = Unpack(o.Find(x => x.lightingIsEnabled));
            m_BakedLightingMultipler = Unpack(o.Find(x => x.bakedLightingMultiplier));
            m_VertexColorLightingMultiplier = Unpack(o.Find(x => x.vertexColorLightingMultiplier));
            m_DynamicLightingMultiplier = Unpack(o.Find(x => x.dynamicLightingMultiplier));
            m_DynamicLightsMaxCount = Unpack(o.Find(x => x.dynamicLightsMaxCount));
            m_DynamicLightsMaxPerObjectCount = Unpack(o.Find(x => x.dynamicLightsMaxPerObjectCount));
        }

        public override void OnInspectorGUI()
        {
            PropertyField(m_LightingIsEnabled, EditorGUIUtility.TrTextContent("Lighting Is Enabled", "Controls whether lighting is enabled or disabled."));
            PropertyField(m_BakedLightingMultipler, EditorGUIUtility.TrTextContent("Baked Lighting Multiplier", "Controls the intensity of the baked lighting information when applied to the surface."));
            PropertyField(m_VertexColorLightingMultiplier, EditorGUIUtility.TrTextContent("Vertex Color Lighting Multiplier", "Controls the intensity of the vertex colors when applied to the surface."));
            PropertyField(m_DynamicLightingMultiplier, EditorGUIUtility.TrTextContent("Dynamic Lighting Multiplier", "Controls the intensity of dynamic lighting when applied to the surface. Set to 0.0 to globally disable dynamic light sources."));
            if (m_DynamicLightingMultiplier.value.floatValue > 0.0f)
            {
                PropertyField(m_DynamicLightsMaxCount, EditorGUIUtility.TrTextContent("Dynamic Lights Max", "Controls the maximum number of realtime light sources that can be active within the viewport. If the scene light count exceeds this, lights will be discarded."));
                PropertyField(m_DynamicLightsMaxPerObjectCount, EditorGUIUtility.TrTextContent("Dynamic Lights Max Per Object", "Controls the maximum number of realtime light sources that can affect a single object. Any lights that exceed this count will be discard. Reduce this value to improve performance. Increase this value to potentially improve quality."));
            }
        }
    }
}