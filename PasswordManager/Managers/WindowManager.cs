using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordManager.Managers
{
    public static class WindowManager
    {
        public static List<Form> OpenWindows = new List<Form>();
        public static List<Form> SingleWindows = new List<Form>();

        public static T Launch<T>(bool stealFocus = false)
            where T : Form
        {
            var frm = Activator.CreateInstance<T>();
            OpenWindows.Add(frm);
            frm.Show();
            if (stealFocus)
                frm.Activate();
            return frm;
        }

        public static T LaunchSingle<T>(bool stealFocus = false)
            where T : Form
        {
            if (SingleWindows.Any(frm => frm is T))
                return null;
            var f = Activator.CreateInstance<T>();
            SingleWindows.Add(f);
            f.Show();
            if (stealFocus)
                f.Activate();
            return f;
        }

    }
}
