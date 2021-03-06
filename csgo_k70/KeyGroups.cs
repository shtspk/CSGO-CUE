﻿using System.Collections.Generic;
using CUE.NET.Devices.Keyboard.Keys;
using CUE.NET.Devices.Keyboard;
using CUE.NET.Devices.Keyboard.Enums;
using System;

namespace CSGO_K70
{
    static class KeyGroups
    {
        public static RectangleKeyGroup numpad; //a selection of the numpad keys.
        public static List<ListKeyGroup> numpadDigital; //a list of combinations of numpad keys meant to look like a digital number display.
        public static ListKeyGroup WASD;
        public static ListKeyGroup healthFunction;
        public static ListKeyGroup armorFunction;

        /// <summary>
        /// Intial setup of keygroups using the keyboard provided.
        /// </summary>
        /// <param name="keyboard"></param>
        /// <param name="useNumpad"></param>
        public static void setupKeyGroups(CorsairKeyboard keyboard, bool useNumpad)
        {
            try
            {
                WASD = new ListKeyGroup(keyboard, keyboard['W'],
                    keyboard['A'],
                    keyboard['S'],
                    keyboard['D']);
                
                healthFunction = new ListKeyGroup(keyboard, CorsairKeyboardKeyId.F1,
                    CorsairKeyboardKeyId.F2,
                    CorsairKeyboardKeyId.F3,
                    CorsairKeyboardKeyId.F4,
                    CorsairKeyboardKeyId.F5,
                    CorsairKeyboardKeyId.F6);
                armorFunction = new ListKeyGroup(keyboard, CorsairKeyboardKeyId.F7,
                    CorsairKeyboardKeyId.F8,
                    CorsairKeyboardKeyId.F9,
                    CorsairKeyboardKeyId.F10,
                    CorsairKeyboardKeyId.F11,
                    CorsairKeyboardKeyId.F12);

                //don't initilize the numpad groups if the keyboard doesn't have a numpad(K65).
                if (useNumpad)
                {
					numpad = new RectangleKeyGroup(keyboard, CorsairKeyboardKeyId.NumLock, CorsairKeyboardKeyId.KeypadEnter, 1.0f, true);
					
                    numpadDigital = new List<ListKeyGroup>();
                    for (int i = 0; i < 10; ++i)
                    {
                        numpadDigital.Add(null);
                    }

                    numpadDigital[1] = new ListKeyGroup(keyboard,
                        CorsairKeyboardKeyId.NumLock,
                        CorsairKeyboardKeyId.KeypadSlash,
                        CorsairKeyboardKeyId.Keypad8,
                        CorsairKeyboardKeyId.Keypad5,
                        CorsairKeyboardKeyId.Keypad2,
                        CorsairKeyboardKeyId.Keypad0,
                        CorsairKeyboardKeyId.KeypadPeriodAndDelete);

                    var numpad2Keys = new CorsairKeyboardKeyId[] { CorsairKeyboardKeyId.NumLock,
                    CorsairKeyboardKeyId.KeypadSlash,
                    CorsairKeyboardKeyId.KeypadAsterisk,
                    CorsairKeyboardKeyId.Keypad9,
                    CorsairKeyboardKeyId.Keypad6,
                    CorsairKeyboardKeyId.Keypad5,
                    CorsairKeyboardKeyId.Keypad4,
                    CorsairKeyboardKeyId.Keypad1,
                    CorsairKeyboardKeyId.Keypad0,
                    CorsairKeyboardKeyId.KeypadPeriodAndDelete};
                    numpadDigital[2] = new ListKeyGroup(keyboard, numpad2Keys);

                    numpadDigital[3] = new ListKeyGroup(keyboard, numpad2Keys);
                    numpadDigital[3].AddKey(CorsairKeyboardKeyId.Keypad3);
                    numpadDigital[3].RemoveKey(CorsairKeyboardKeyId.Keypad1);

                    var numpad4Keys = new CorsairKeyboardKeyId[] { CorsairKeyboardKeyId.NumLock,
                    CorsairKeyboardKeyId.Keypad7,
                    CorsairKeyboardKeyId.Keypad4,
                    CorsairKeyboardKeyId.Keypad5,
                    CorsairKeyboardKeyId.Keypad6,
                    CorsairKeyboardKeyId.Keypad9,
                    CorsairKeyboardKeyId.KeypadAsterisk,
                    CorsairKeyboardKeyId.Keypad3,
                    CorsairKeyboardKeyId.KeypadPeriodAndDelete};
                    numpadDigital[4] = new ListKeyGroup(keyboard, numpad4Keys);

                    numpadDigital[5] = new ListKeyGroup(keyboard, numpad2Keys);
                    numpadDigital[5].AddKey(CorsairKeyboardKeyId.Keypad7, CorsairKeyboardKeyId.Keypad3);
                    numpadDigital[5].RemoveKey(CorsairKeyboardKeyId.Keypad9, CorsairKeyboardKeyId.Keypad1);

                    numpadDigital[6] = new ListKeyGroup(keyboard, numpad2Keys);
                    numpadDigital[6].AddKey(CorsairKeyboardKeyId.Keypad3, CorsairKeyboardKeyId.Keypad7);
                    numpadDigital[6].RemoveKey(CorsairKeyboardKeyId.Keypad9);

                    var numpad7Keys = new CorsairKeyboardKeyId[] {
                    CorsairKeyboardKeyId.Keypad7,
                    CorsairKeyboardKeyId.NumLock,
                    CorsairKeyboardKeyId.KeypadSlash,
                    CorsairKeyboardKeyId.KeypadAsterisk,
                    CorsairKeyboardKeyId.Keypad9,
                    CorsairKeyboardKeyId.Keypad6,
                    CorsairKeyboardKeyId.Keypad3,
                    CorsairKeyboardKeyId.KeypadPeriodAndDelete };
                    numpadDigital[7] = new ListKeyGroup(keyboard, numpad7Keys);

                    numpadDigital[8] = new ListKeyGroup(keyboard, numpad2Keys);
                    numpadDigital[8].AddKey(CorsairKeyboardKeyId.Keypad7, CorsairKeyboardKeyId.Keypad3);

                    numpadDigital[9] = new ListKeyGroup(keyboard, numpad4Keys);
                    numpadDigital[9].AddKey(CorsairKeyboardKeyId.KeypadSlash);

                    numpadDigital[0] = new ListKeyGroup(keyboard, numpad7Keys);
                    numpadDigital[0].AddKey(CorsairKeyboardKeyId.Keypad0,
                        CorsairKeyboardKeyId.Keypad1,
                        CorsairKeyboardKeyId.Keypad4);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in creating key groups!");
                Console.WriteLine("Message: " + ex.Message);
            }
        }
    }
}
