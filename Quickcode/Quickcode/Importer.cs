using ClassLibrary;
using InterfaceLibary;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace Quickcode
{
    public class Importer
    {
        [ImportMany(typeof(ILoopInterface))]
        public ArrayList loops = null;

        [ImportMany(typeof(IConditionInterface))]
        public ArrayList conds = null;

        [ImportMany(typeof(IOthersInterface))]
        public ArrayList others = null;

        public ArrayList myConstructs = null;

        private string myPath = "";

        public Importer()
        {
            loops = new ArrayList();
            conds = new ArrayList();
            others = new ArrayList();
            myConstructs = new ArrayList();
            try {

                var catalog = new DirectoryCatalog(".");
                var container = new CompositionContainer(catalog);                
                container.ComposeParts(this);
            }catch(Exception e)
            {
                System.Windows.MessageBox.Show("Import fehlgeschlagen. Die Listen werden nun Manuell befüllt");
                fillListWithoutImport();
            }
        }
        private void fillListWithoutImport()
        {
            loops.Add(new For());
            loops.Add(new While());
            loops.Add(new Foreach());

            conds.Add(new If());
            conds.Add(new Switch());

            others.Add(new Method());
        }

        public void setMyConstructDirectory()
        {
            using (var fold = new FolderBrowserDialog())
            {
                if (fold.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(fold.SelectedPath))
                {
                    FillMyConstructs(fold.SelectedPath);
                }
            }
        }
        private void FillMyConstructs(string path)
        {
            DirectoryInfo inf = new DirectoryInfo(@path);
            FileInfo[] files = inf.GetFiles("*.txt");
            string s = "Sie haben die Dateien ";
            foreach(FileInfo file in files)
            {
                s += file.Name + ",";
                myConstructs.Add(new CustomConstruct(file.Name,file.OpenText().ReadToEnd()));

            }
            s += "hinzugefügt";
            System.Windows.MessageBox.Show(s);
        }
        public void exportTxt(string name,string content)
        {
            using(var fold = new FolderBrowserDialog())
            {
                if(fold.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(fold.SelectedPath))
                {
                    string path = fold.SelectedPath + "/" + name + ".txt";
                    System.IO.File.WriteAllText(@path,content);
                    System.Windows.MessageBox.Show("Ihre Datei wurde unter \n " + path + "\n gespeichert!", "Erfolgreich!");
                }
            }
        }
    }
}
