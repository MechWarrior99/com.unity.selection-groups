
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Unity.SelectionGroups.Runtime;
using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;

namespace Unity.SelectionGroups.EditorTests 
{
    public class EditorTests
    {
        
        //Disabled until we implement a "SetQuery" method which handles the Undo.Register functionality.
        //[UnityTest]
        public IEnumerator TestGoQLUndo()
        {
            var grp = SelectionGroupManager.CreateSceneSelectionGroup("Test Group", "/", Color.blue, new List<Object>());
            SelectionGroupManager.ExecuteQuery(grp);
            var membersA = new HashSet<Object>(grp.Members);
            Assert.IsTrue(membersA.Count > 0);
            grp.Query = "/Nothing";
            SelectionGroupManager.ExecuteQuery(grp);
            Undo.PerformUndo();
            Assert.AreEqual("/", grp.Query);
            yield return null;
            yield return null;
            var membersB = new HashSet<Object>(grp.Members);
            Assert.IsTrue(membersB.Count > 0);
            Assert.IsTrue(membersA.SetEquals(membersB));
            Debug.Log(grp.Count);
        }


    }

} //end namespace