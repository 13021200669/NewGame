using UnityEngine;
using UnityEditor;
using CustomEditorGUI;

[CustomEditor(typeof(CharacterControl))]
[CanEditMultipleObjects]
public class CharacterControlEditor : Editor
{
    //--------------------------子物体--------------------------
    //子物体
    SerializedProperty _Body;
    SerializedProperty _CamPlayer;
    SerializedProperty _RigPlayer;

    //--------------------------运动模块--------------------------
    //移动速度
    SerializedProperty _MoveSpeed;
    const float _MinLimit_MoveSpeed = 0f;
    const float _MaxLimit_MoveSpeed = 50f;

    //跳跃力度
    SerializedProperty _JumpForce;
    const float _MinLimit_JumpForce = 100f;
    const float _MaxLimit_JumpForce = 500f;

    //冲刺倍率
    SerializedProperty _Accelerate_Multiple;
    const float _MinLimit_Accelerate_Multiple = 1f;
    const float _MaxLimit_Accelerate_Multiple = 5f;

    //冲刺时间
    SerializedProperty _Accelerate_Time;
    const float _MinLimit_Accelerate_Time = 0.1f;
    const float _MaxLimit_Accelerate_Time = 5f;

    //正常/冲刺视野
    SerializedProperty _Normal_Field_of_View;
    SerializedProperty _Accelerate_Field_of_View;
    const float _MinLimit_Field_of_View = 40f;
    const float _MaxLimit_Field_of_View = 100f;

    //视野模糊脚本
    SerializedProperty _FocusScript;
    //视野模糊程度
    SerializedProperty _Normal_FocusSize;
    SerializedProperty _Accelerate_FocusSize;
    const float _MinLimit_FocusSize = 0.15f;
    const float _MaxLimit_FocusSize = 10f;

    //--------------------------相机模块--------------------------
    //摄像机旋转层级 X/Y
    SerializedProperty _RotateX;
    SerializedProperty _RotateY;

    //灵敏度 X/Y
    SerializedProperty _Sensitive_X;
    SerializedProperty _Sensitive_Y;
    const float _MinLimit_Sensitive = 100f;
    const float _MaxLimit_Sensitive = 500f;

    //视角限制 Y
    const float _MinLimit_Angle_Y = -90f;
    const float _MaxLimit_Angle_Y = 90f;

    //初始视高
    SerializedProperty _CameraHeight;
    const float _MinLimit_CameraHeight = -2f;
    const float _MaxLimit_CameraHeight = 2f;

    //初始视距
    SerializedProperty _CameraDistance;
    const float _MinLimit_CameraDistance = -5f;
    const float _MaxLimit_CameraDistance = 0f;

    //视距速度
    SerializedProperty _Speed_ViewDistanceShift;
    const float _MinLimit_Speed_ViewDistanceShift = 100f;
    const float _MaxLimit_Speed_ViewDistanceShift = 500f;

    //视距限制
    const float _MinLimit_ViewDistance = -5f;
    const float _MaxLimit_ViewDistance = 0f;

    void OnEnable()
    {
        //获取Property对象
        _Body = serializedObject.FindProperty("Body");
        _CamPlayer = serializedObject.FindProperty("CamPlayer");
        _RigPlayer = serializedObject.FindProperty("RigPlayer");

        _MoveSpeed = serializedObject.FindProperty("MoveSpeed");
        _JumpForce = serializedObject.FindProperty("JumpForce");

        _Accelerate_Multiple = serializedObject.FindProperty("Accelerate_Multiple");
        _Accelerate_Time = serializedObject.FindProperty("Accelerate_Time");

        _Normal_Field_of_View = serializedObject.FindProperty("Normal_Field_of_View");
        _Accelerate_Field_of_View = serializedObject.FindProperty("Accelerate_Field_of_View");

        _FocusScript = serializedObject.FindProperty("FocusScript");
        _Normal_FocusSize = serializedObject.FindProperty("Normal_FocusSize");
        _Accelerate_FocusSize = serializedObject.FindProperty("Accelerate_FocusSize");

        _RotateX = serializedObject.FindProperty("RotateX");
        _RotateY = serializedObject.FindProperty("RotateY");
        _Sensitive_X = serializedObject.FindProperty("Sensitive_X");
        _Sensitive_Y = serializedObject.FindProperty("Sensitive_Y");

        _CameraHeight = serializedObject.FindProperty("CameraHeight");
        _CameraDistance = serializedObject.FindProperty("CameraDistance");

        _Speed_ViewDistanceShift = serializedObject.FindProperty("Speed_ViewDistanceShift");
    }

    public override void OnInspectorGUI()
    {
        GUILayout.Space(10);
        //--------------------------获取property--------------------------

        CharacterControl scriptObject = target as CharacterControl;

        //--------------------------绘制GUILayout--------------------------

        EditorGUILayout.LabelField("运动模块------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");

        GUILayout.Space(5);

        CustomEditorGUILayout.CustomField_Property(CustomEditorGUILayoutMode.Start, "骨骼蒙皮", _Body);

        CustomEditorGUILayout.CustomField_Property(CustomEditorGUILayoutMode.End, "刚  体", _RigPlayer);

        CustomEditorGUILayout.CustomField_Slider(CustomEditorGUILayoutMode.Start, "移动速度", _MoveSpeed, _MinLimit_MoveSpeed, _MaxLimit_MoveSpeed);

        CustomEditorGUILayout.CustomField_Slider(CustomEditorGUILayoutMode.End, "跳跃力度", _JumpForce, _MinLimit_JumpForce, _MaxLimit_JumpForce);

        CustomEditorGUILayout.CustomField_Slider(CustomEditorGUILayoutMode.Start, "冲刺倍率", _Accelerate_Multiple, _MinLimit_Accelerate_Multiple, _MaxLimit_Accelerate_Multiple);

        CustomEditorGUILayout.CustomField_Toggle(CustomEditorGUILayoutMode.Insert, "无限冲刺", target, ref scriptObject.isAccelerateTimeUnLimited);

        CustomEditorGUILayout.CustomField_Slider(CustomEditorGUILayoutMode.End, "冲刺时间", _Accelerate_Time, _MinLimit_Accelerate_Time, _MaxLimit_Accelerate_Time);

        CustomEditorGUILayout.CustomField_Slider(CustomEditorGUILayoutMode.Start, "正常视野", _Normal_Field_of_View, _MinLimit_Field_of_View, _MaxLimit_Field_of_View);

        CustomEditorGUILayout.CustomField_Slider(CustomEditorGUILayoutMode.End, "冲刺视野", _Accelerate_Field_of_View, _MinLimit_Field_of_View, _MaxLimit_Field_of_View);

        CustomEditorGUILayout.CustomField_Slider(CustomEditorGUILayoutMode.Start, "正常模糊", _Normal_FocusSize, _MinLimit_FocusSize, _MaxLimit_FocusSize);

        CustomEditorGUILayout.CustomField_Slider(CustomEditorGUILayoutMode.End, "冲刺模糊", _Accelerate_FocusSize, _MinLimit_FocusSize, _MaxLimit_FocusSize);

        EditorGUILayout.LabelField("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");

        GUILayout.Space(20);

        EditorGUILayout.LabelField("相机模块------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");

        GUILayout.Space(5);

        CustomEditorGUILayout.CustomField_Property(CustomEditorGUILayoutMode.Start, "主摄像机", _CamPlayer);

        CustomEditorGUILayout.CustomField_Property(CustomEditorGUILayoutMode.End, "模糊控制", _FocusScript);

        CustomEditorGUILayout.CustomField_Property(CustomEditorGUILayoutMode.Start, "水平旋转", _RotateX);

        CustomEditorGUILayout.CustomField_Property(CustomEditorGUILayoutMode.End, "竖直旋转", _RotateY);

        CustomEditorGUILayout.CustomField_Slider(CustomEditorGUILayoutMode.Start, "水平灵敏", _Sensitive_X, _MinLimit_Sensitive, _MaxLimit_Sensitive);

        CustomEditorGUILayout.CustomField_Slider(CustomEditorGUILayoutMode.End, "竖直灵敏", _Sensitive_Y, _MinLimit_Sensitive, _MaxLimit_Sensitive);

        CustomEditorGUILayout.CustomField_MinMaxSlider(CustomEditorGUILayoutMode.Start, "视角范围", _MinLimit_Angle_Y, _MaxLimit_Angle_Y, target, ref scriptObject.MinAngle_Y, ref scriptObject.MaxAngle_Y);

        CustomEditorGUILayout.CustomField_MinMaxSlider(CustomEditorGUILayoutMode.End, "视距范围", _MinLimit_ViewDistance, _MaxLimit_ViewDistance, target, ref scriptObject.MinViewDistance, ref scriptObject.MaxViewDistance);

        CustomEditorGUILayout.CustomField_Slider(CustomEditorGUILayoutMode.Start, "初始视距", _CameraDistance, _MinLimit_CameraDistance, _MaxLimit_CameraDistance);

        CustomEditorGUILayout.CustomField_Slider(CustomEditorGUILayoutMode.End, "视距速度", _Speed_ViewDistanceShift, _MinLimit_Speed_ViewDistanceShift, _MaxLimit_Speed_ViewDistanceShift);

        CustomEditorGUILayout.CustomField_Slider(CustomEditorGUILayoutMode.Whole, "初始视高", _CameraHeight, _MinLimit_CameraHeight, _MaxLimit_CameraHeight);

        EditorGUILayout.LabelField("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");

        //--------------------------保存更改--------------------------

        //对serializedProperty应用更改
        //始终在OnInspectorGUI的末尾执行此操作
        serializedObject.ApplyModifiedProperties();

        //------------------------------------------------------------
        GUILayout.Space(10);
    }
}