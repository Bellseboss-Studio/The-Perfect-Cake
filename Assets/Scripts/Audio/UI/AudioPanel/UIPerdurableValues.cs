using System;
using System.Collections;
using System.Collections.Generic;
using SystemOfExtras;
using UnityEngine;

namespace GameAudio
{
    public class UIPerdurableValues : Singleton<UIPerdurableValues>
    {

        private static float m_MasterFaderValue;
        

        public static float MasterFaderValue
        {
            get { return m_MasterFaderValue; }
            set { m_MasterFaderValue = value; }
        }

        private static float m_MxFaderValue = 1;

        public static float MxFaderValue
        {
            get { return m_MxFaderValue; }
            set { m_MxFaderValue = value; }
        }

        private static float m_SfxFaderValue = 1;

        public static float SfxFaderValue
        {
            get { return m_SfxFaderValue; }
            set { m_SfxFaderValue = value; }
        }

        private static float m_DxFaderValue = 1;

        public static float DxFaderValue
        {
            get { return m_DxFaderValue; }
            set { m_DxFaderValue = value; }
        }
    }

}