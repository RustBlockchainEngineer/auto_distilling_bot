using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading;
using System.Drawing;

namespace DistillingBot
{
    public class GamePlayModule
    {
        MainThread mainThread;
        
        static CommandState curCommandState;
        static bool firstCommand = false;

        public GamePlayModule(MainThread mt)
        {
            mainThread = mt;
        }
        [Flags]
        public enum MouseEventFlags
        {
            LeftDown = 0x00000002,
            LeftUp = 0x00000004,
            MiddleDown = 0x00000020,
            MiddleUp = 0x00000040,
            Move = 0x00000001,
            Absolute = 0x00008000,
            RightDown = 0x00000008,
            RightUp = 0x00000010
        }
        public enum CommandState
        {
            START,
            RUNNING,
            END,
            UNIT
        }
        [DllImport("user32.dll", EntryPoint = "SetCursorPos")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetCursorPos(int x, int y);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetCursorPos(out MousePoint lpMousePoint);

        [DllImport("user32.dll")]
        private static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

        public static void SetCursorPosition(int x, int y)
        {
            SetCursorPos(x, y);
        }

        public static void SetCursorPosition(MousePoint point)
        {
            SetCursorPos(point.X, point.Y);
        }

        public static MousePoint GetCursorPosition()
        {
            MousePoint currentMousePoint;
            var gotPoint = GetCursorPos(out currentMousePoint);
            if (!gotPoint) { currentMousePoint = new MousePoint(0, 0); }
            return currentMousePoint;
        }

        
        [StructLayout(LayoutKind.Sequential)]
        public struct MousePoint
        {
            public int X;
            public int Y;

            public MousePoint(int x, int y)
            {
                X = x;
                Y = y;
            }
        }

        bool state = true;
        private MousePoint prePos = new MousePoint(0,0);
        public void playCommands()
        {
            MousePoint curPos = GetCursorPosition();
            bool same = curPos.X == prePos.X && curPos.Y == prePos.Y;

            if(same)
            {
                if (state)
                {
                    SetCursorPosition(700, 600);
                    mouse_event((int)MouseEventFlags.LeftDown, 0, 0, 0, 0);
                    mouse_event((int)MouseEventFlags.LeftUp, 0, 0, 0, 0);

                }

                else
                {
                    SetCursorPosition(1200, 670);
                    mouse_event((int)MouseEventFlags.LeftDown, 0, 0, 0, 0);
                    mouse_event((int)MouseEventFlags.LeftUp, 0, 0, 0, 0);
                }
            }
            
            state = !state;
            prePos = GetCursorPosition();

        }
        
           

    }
}
