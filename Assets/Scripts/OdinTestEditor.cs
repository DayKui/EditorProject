using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Sirenix.OdinInspector.Editor;
using System.Linq;

[CustomEditor(typeof(OdinTest))]
public class OdinTestEditor : OdinEditor
{
    private OdinTest _odinTest { get { return target as OdinTest; } }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (_odinTest.stringList.Count>1)
        {
            int selectIndex = 0;
            if (_odinTest.stringList.Contains(_odinTest.selectString))
            {
                for (int i = 0; i < _odinTest.stringList.Count; i++)
                {
                    if (_odinTest.selectString == _odinTest.stringList[i])
                    {
                        selectIndex = i;
                        break;
                    }
                }
            }
            //selectIndex = EditorGUILayout.Popup("SelectString", selectIndex, _odinTest.stringList.ToArray());
            //_odinTest.selectString = _odinTest.stringList[selectIndex];
            if (GUILayout.Button(_odinTest.selectString,"MiniPopup"))
            {
                GenericSelector<string> selector = new GenericSelector<string>("SelectString", false,
                    _odinTest.stringList);
                selector.SetSelection(_odinTest.stringList[selectIndex]);
                selector.SelectionTree.DefaultMenuStyle.Height =20;
                selector.SelectionConfirmed += stringList =>
                {
                    _odinTest.selectString = stringList.FirstOrDefault();
                };
                selector.SelectionTree.Config.DrawSearchToolbar = true;

                var window = selector.ShowInPopup();
                window.OnClose += selector.SelectionTree.Selection.ConfirmSelection;
            }
        }
    }

}
