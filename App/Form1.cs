using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PluginInterface;
using System.Windows.Forms;

namespace App
{
    public partial class Form1 : Form
    {
        Dictionary<string, IPlugin> plugins = new Dictionary<string, IPlugin>();
        string file_with_paths = "F:\\3 курс\\компонентное\\лр2\\dlls.txt";
        public Form1()
        {
            InitializeComponent();
            FindPlugins();
            CreatePluginsMenu();
        }
        private void OnPluginClick(object sender, EventArgs args)
        {
            var v = (ToolStripMenuItem)sender;
            var h = (System.Windows.Forms.ToolStripItemClickedEventArgs)args;
            IPlugin plugin = plugins[h.ClickedItem.Text];
            Bitmap bm = (Bitmap)pictureBox1.Image;
            plugin.Transform(bm);
            pictureBox1.Image = bm;
        }

        void CreatePluginsMenu()
        {
            foreach (KeyValuePair<string, IPlugin> entry in plugins)
            {
                toolStripMenuItem1.DropDownItems.Add(entry.Key);
            }
        }

        void FindPlugins()
        {
            using(StreamReader sr = new StreamReader(file_with_paths))
            {
                string path;
                try
                {
                    while ((path = sr.ReadLine()) != null)
                    {
                        Assembly assembly = Assembly.LoadFile(path);

                        foreach (Type type in assembly.GetTypes())
                        {
                            Type iface = type.GetInterface("PluginInterface.IPlugin");

                            if (iface != null)
                            {
                                IPlugin plugin = (IPlugin)Activator.CreateInstance(type);
                                plugins.Add(plugin.Name, plugin);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка загрузки плагина\n" + ex.Message);
                }
            }
        }
    }
}
