﻿
using System;
using System.Collections.Generic;
using LuaInterface;

namespace SLua
{
    public class LuaUnityEvent_bool : LuaObject
    {

        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static public int AddListener(IntPtr l)
        {
            try
            {
                UnityEngine.Events.UnityEvent<bool> self = checkSelf<UnityEngine.Events.UnityEvent<bool>>(l);
                UnityEngine.Events.UnityAction<bool> a1;
                checkType(l, 2, out a1);
                self.AddListener(a1);
				pushValue(l,true);
                return 1;
            }
            catch (Exception e)
            {
				return error(l,e);
            }
        }
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static public int RemoveListener(IntPtr l)
        {
            try
            {
                UnityEngine.Events.UnityEvent<bool> self = checkSelf<UnityEngine.Events.UnityEvent<bool>>(l);
                UnityEngine.Events.UnityAction<bool> a1;
                checkType(l, 2, out a1);
                self.RemoveListener(a1);
				pushValue(l,true);
                return 1;
            }
            catch (Exception e)
            {
                return error(l,e);
            }
        }
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static public int Invoke(IntPtr l)
        {
            try
            {
                UnityEngine.Events.UnityEvent<bool> self = checkSelf<UnityEngine.Events.UnityEvent<bool>>(l);
				bool a0;
				checkType(l,2,out a0);
				self.Invoke(a0);

				pushValue(l,true);
                return 1;
            }
            catch (Exception e)
            {
                return error(l,e);
            }
        }
        static public void reg(IntPtr l)
        {
            getTypeTable(l, typeof(LuaUnityEvent_bool).FullName);
            addMember(l, AddListener);
            addMember(l, RemoveListener);
            addMember(l, Invoke);
            createTypeMetatable(l, null, typeof(LuaUnityEvent_bool), typeof(UnityEngine.Events.UnityEventBase));
        }

        static bool checkType(IntPtr l,int p,out UnityEngine.Events.UnityAction<bool> ua) {
            LuaDLL.luaL_checktype(l, p, LuaTypes.LUA_TFUNCTION);
            LuaDelegate ld;
            checkType(l, p, out ld);
						l = LuaState.get(l).L;
            if (ld.d != null)
            {
                ua = (UnityEngine.Events.UnityAction<bool>)ld.d;
                return true;
            }
            ua = (bool v0) =>
            {
                int error = pushTry(l);
                pushValue(l,v0);
                ld.pcall(1, error);
                LuaDLL.lua_settop(l,error - 1);
            };
            ld.d = ua;
            return true;
        }
    }
}
