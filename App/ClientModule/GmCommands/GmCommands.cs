﻿using System;
using System.Collections.Generic;
using StorySystem;
using GameFrameworkMessage;

namespace GameFramework.GmCommands
{
    internal class SetDebugCommand : SimpleStoryCommandBase<SetDebugCommand, StoryValueParam<int>>
    {
        protected override bool ExecCommand(StoryInstance instance, StoryValueParam<int> _params, long delta)
        {
            int val = _params.Param1Value;
            GlobalVariables.Instance.IsDebug = val != 0;
            Msg_CR_SwitchDebug msg = new Msg_CR_SwitchDebug();
            msg.is_debug = val != 0;
            Network.NetworkSystem.Instance.SendMessage(RoomMessageDefine.Msg_CR_SwitchDebug, msg);
            return false;
        }
    }
  internal class AllocMemoryCommand : SimpleStoryCommandBase<AllocMemoryCommand, StoryValueParam<string,int>>
  {
    protected override bool ExecCommand(StoryInstance instance, StoryValueParam<string,int> _params, long delta)
    {
      string key = _params.Param1Value;
      int size = _params.Param2Value;
      byte[] m = new byte[size];
      if (instance.GlobalVariables.ContainsKey(key)) {
        instance.GlobalVariables[key] = m;
      } else {
        instance.GlobalVariables.Add(key, m);
      }
      return false;
    }
  }
  internal class FreeMemoryCommand : SimpleStoryCommandBase<FreeMemoryCommand, StoryValueParam<string>>
  {
    protected override bool ExecCommand(StoryInstance instance, StoryValueParam<string> _params, long delta)
    {
      string key = _params.Param1Value;
      if (instance.GlobalVariables.ContainsKey(key)) {
        instance.GlobalVariables.Remove(key);
        GC.Collect();
      } else {
        GC.Collect();
      }
      return false;
    }
  }
  internal class ConsumeCpuCommand : SimpleStoryCommandBase<ConsumeCpuCommand, StoryValueParam<int>>
  {
    protected override bool ExecCommand(StoryInstance instance, StoryValueParam<int> _params, long delta)
    {
      int time = _params.Param1Value;
      long startTime = TimeUtility.GetElapsedTimeUs();
      while (startTime + time > TimeUtility.GetElapsedTimeUs()) {
      }
      return false;
    }
  }
  //---------------------------------------------------------------------------------------------------------------------------------
}
