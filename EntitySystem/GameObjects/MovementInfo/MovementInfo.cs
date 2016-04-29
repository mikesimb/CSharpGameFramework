﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GameFramework
{
    public class MovementStateInfo
    {
        public bool IsMoving
        {
            get { return m_IsMoving; }
            set
            {
                if (m_IsMoving != value) {
                    m_IsMoveStatusChanged = true;
                }
                m_IsMoving = value;
            }
        }

        public bool IsSkillMoving
        {
            get { return m_IsSkillMoving; }
            set { m_IsSkillMoving = value; }
        }
        public int FormationIndex
        {
            get { return m_FormationIndex; }
            set { m_FormationIndex = value; }
        }
        public ScriptRuntime.Vector3 TargetPosition
        {
            get { return m_TargetPosition; }
            set
            {
                m_TargetPosition = value;
                m_IsMoveStatusChanged = true;
                m_TargetDir = m_TargetPosition - m_Position;
                m_TargetDir.Normalize();
            }
        }
        public float PositionX
        {
            get { return m_Position.X; }
            set { m_Position.X = value; }
        }
        public float PositionY
        {
            get { return m_Position.Y; }
            set { m_Position.Y = value; }
        }
        public float PositionZ
        {
            get { return m_Position.Z; }
            set { m_Position.Z = value; }
        }
        public ScriptRuntime.Vector3 TargetDir
        {
            get { return m_TargetDir; }
        }

        public float CalcDistancSquareToTarget()
        {
            return Geometry.DistanceSquare(m_Position, m_TargetPosition);
        }
        public void SetPosition(float x, float y, float z)
        {
            m_Position.X = x;
            m_Position.Y = y;
            m_Position.Z = z;
        }
        public void SetPosition(ScriptRuntime.Vector3 pos)
        {
            m_Position = pos;
        }
        public ScriptRuntime.Vector3 GetPosition3D()
        {
            return m_Position;
        }
        public void SetPosition2D(float x, float y)
        {
            m_Position.X = x;
            m_Position.Z = y;
        }
        public void SetPosition2D(ScriptRuntime.Vector2 pos)
        {
            m_Position.X = pos.X;
            m_Position.Z = pos.Y;
        }
        public ScriptRuntime.Vector2 GetPosition2D()
        {
            return new ScriptRuntime.Vector2(m_Position.X, m_Position.Z);
        }
        public void SetFaceDir(float rot)
        {
            if (Math.Abs(m_FaceDir - rot) > c_Precision) {
                m_FaceDir = rot;
                m_IsFaceDirChanged = true;
                m_FaceDir3D = new ScriptRuntime.Vector3((float)Math.Sin(rot), 0, (float)Math.Cos(rot));
            }
        }
        public float GetFaceDir()
        {
            return m_FaceDir;
        }
        public void SetMoveDir(float dir)
        {
            if (Math.Abs(m_MoveDir - dir) > c_Precision) {
                m_MoveDir = dir;
                m_IsMoveStatusChanged = true;
                m_MoveDir3D = new ScriptRuntime.Vector3((float)Math.Sin(dir), 0, (float)Math.Cos(dir));
            }
        }

        public float GetMoveDir()
        {
            return m_MoveDir;
        }
        public ScriptRuntime.Vector2 GetMoveDir2D()
        {
            return new ScriptRuntime.Vector2(m_MoveDir3D.X, m_MoveDir3D.Z);
        }
        public ScriptRuntime.Vector3 GetMoveDir3D()
        {
            return m_MoveDir3D;
        }
        public ScriptRuntime.Vector2 GetFaceDir2D()
        {
            return new ScriptRuntime.Vector2(m_FaceDir3D.X, m_FaceDir3D.Z);
        }
        public ScriptRuntime.Vector3 GetFaceDir3D()
        {
            return m_FaceDir3D;
        }
        public MovementStateInfo()
        {
            m_Position = ScriptRuntime.Vector3.Zero;
        }
        public void Reset()
        {
            m_Position = ScriptRuntime.Vector3.Zero;
            m_TargetPosition = ScriptRuntime.Vector3.Zero;

            m_IsMoving = false;
            m_IsSkillMoving = false;
            m_FaceDir = 0;
            m_MoveDir = 0;
            m_TargetDir = ScriptRuntime.Vector3.Zero;
            m_FaceDir3D = ScriptRuntime.Vector3.Zero;
            m_MoveDir3D = ScriptRuntime.Vector3.Zero;
            m_IsFaceDirChanged = false;
            m_IsMoveStatusChanged = false;
        }

        public bool IsFaceDirChanged
        {
            get { return m_IsFaceDirChanged; }
            set { m_IsFaceDirChanged = value; }
        }

        public bool IsMoveStatusChanged
        {
            get { return m_IsMoveStatusChanged; }
            set
            {
                m_IsMoveStatusChanged = value;
            }
        }

        private bool m_IsMoving = false;
        private bool m_IsSkillMoving = false;
        private int m_FormationIndex = 0;
        private ScriptRuntime.Vector3 m_Position = ScriptRuntime.Vector3.Zero;
        private ScriptRuntime.Vector3 m_TargetPosition = ScriptRuntime.Vector3.Zero;
        private ScriptRuntime.Vector3 m_TargetDir = ScriptRuntime.Vector3.Zero;
        private float m_FaceDir = 0;
        private float m_MoveDir = 0;
        private ScriptRuntime.Vector3 m_FaceDir3D = ScriptRuntime.Vector3.Zero;
        private ScriptRuntime.Vector3 m_MoveDir3D = ScriptRuntime.Vector3.Zero;
        private bool m_IsFaceDirChanged = false;
        private bool m_IsMoveStatusChanged = false;
        private float c_Precision = 0.001f;
    }
}
