using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace HiperMegaRed.DAL.MultiLenguaje
{
    public static class WinformUtils
    {
        public static void TraducirControl (Control control)
        {
            if (control.IsDisposed)
            {
                return;
            }

            var key = string.Empty;
            var traduccion = string.Empty;
            string text;

            if (control.Tag != null && !string.IsNullOrWhiteSpace(control.Tag.ToString()))
            {
                key = control.Tag.ToString();
                traduccion = MultiLang.Translate(key);
                if (control is TextBox)
                {
                    text = ((TextBox)control).Text;
                }
                else
                {
                    text = control.Text;
                }
                if (control is ListBox)
                {
                    return;
                }

                if (traduccion == null && !string.IsNullOrEmpty(text))
                {
                    MultiLang.AddTranslate(key, text);
                    traduccion = MultiLang.Translate(key);
                }

                if (control is TextBox)
                {
                    ((TextBox)control).Text = traduccion;
                }
                else
                {
                    control.Text = traduccion;
                }
            }

            if (control is MenuStrip menu)
            {
                foreach (ToolStripMenuItem toolStrip in menu.Items)
                {
                    TraducirMenuStrip(toolStrip);
                }
            }
            else
            {
                foreach (Control c in control.Controls)
                {
                    TraducirControl(c);
                }
            }
        }

        public static void TraducirMenuStrip(ToolStripItem menu)
        {
            if (menu.Tag != null && !string.IsNullOrWhiteSpace(menu.Tag.ToString()))
            {
                var key = menu.Tag.ToString();
                var traduccion = MultiLang.Translate(key);
                var text = menu.Text;

                if (traduccion == null && !string.IsNullOrEmpty(text))
                {
                    MultiLang.AddTranslate(key, text);
                    traduccion = MultiLang.Translate(key);
                }


                menu.Text = traduccion;
            }

            if (menu is ToolStripDropDownItem drop)
                foreach (ToolStripMenuItem submenu in drop.DropDownItems)
                {
                    TraducirMenuStrip(submenu);
                }
        }
        public static void HacerVisibles(Control control)
        {
            control.Visible = true;
            foreach (Control c in control.Controls)
            {
                HacerVisibles(c);
            }
        }
        public static void ShowErrorList(String title, List<String> errors)
        {
            String errorDescription = "";
            errors.ForEach((e) =>
            {
                errorDescription = $"{errorDescription}- {e}\n";
            });

            MessageBox.Show(errorDescription, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
