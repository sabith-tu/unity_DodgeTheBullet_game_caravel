using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using cakeslice;

namespace cakeslice
{
    public class OutlineAnimation : MonoBehaviour
    {
        private OutlineEffect _outline;

        // Use this for initialization
        void Awake()
        {
            _outline = GetComponent<OutlineEffect>();
        }

        [ContextMenu("Red")]
        public void SetOutlineColorRed()
        {
            _outline.lineColor0 = Color.red;
            _outline.UpdateMaterialsPublicProperties();
        }

        [ContextMenu("Green")]
        public void SetOutlineColorGreen()
        {
            _outline.lineColor0 = Color.green;
            _outline.UpdateMaterialsPublicProperties();
        }
    }
}