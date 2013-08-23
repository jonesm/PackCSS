using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PackCSS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pack(string[] files)
        {

            foreach (string file in files)
            {
                
                // Begin
                progressBar.Value = 0;

                // Read dropped file
                string css = System.IO.File.ReadAllText(file);

                // Get CSS file info
                FileInfo cssInfo = new FileInfo(file);
                // Get file's directory
                string directory = cssInfo.DirectoryName + "\\";
                
                // Get file's name and remove extension
                string name = cssInfo.Name;
                name = name.Substring(0, name.LastIndexOf("."));
                System.Console.WriteLine(name);

                // Set positions to beginning of file
                Int32 positionBegin = 0;
                Int32 positionEnd = 0;
                Int32 positionLast = 0;

                do
                {

                    // This is used to prevent process of unknown file types
                    bool unknown = false;

                    // Find url(
                    positionBegin = css.IndexOf("url(", positionBegin) + 4; // 4 to skip url(

                    // Find )
                    positionEnd = css.IndexOf(")", positionBegin);

                    // Check if we found something to process
                    if (positionBegin == -1 || positionEnd == -1
                        || positionLast > positionEnd) break;

                    positionLast = positionEnd;

                    // Create path to resource file
                    string url = css.Substring(positionBegin, positionEnd - positionBegin);
                    string path = (directory + url).Replace("/", "\\");
                    
                    // Check if the path is base64 data
                    if (path.Contains("data:")) continue;

                    //System.Console.WriteLine(url);
                    
                    // Read url file
                    byte[] contents = System.IO.File.ReadAllBytes(path);
                    
                    // Base64 the file data
                    //var bytes = Encoding.UTF8.GetBytes(contents);
                    var base64 = Convert.ToBase64String(contents);

                    // Get file information
                    FileInfo fileInfo = new FileInfo(path);

                    // Update bar
                    progressBar.Value = (int)((float)positionEnd / (float)fileInfo.Length) % 100;

                    // Get extension of file
                    string extension = fileInfo.Extension; // will include .
                    
                    // Prepend data:type/format;base64,
                    switch (fileInfo.Extension)
                    {
                        // CSS is only worried about images and fonts
                        // Images
                        case ".gif":
                            base64 = "data:image/gif;base64," + base64;
                            break;
                        case ".jpeg":
                        case ".jpg":
                            base64 = "data:image/jpeg;base64," + base64;
                            break;
                        case ".pjpeg":
                            base64 = "data:image/pjpeg;base64," + base64;
                            break;
                        case ".png":
                            base64 = "data:image/png;base64," + base64;
                            break;
                        case ".tiff":
                        case ".tif":
                            base64 = "data:image/tiff;base64," + base64;
                            break;
                        case ".svg": // Can be a font too
                            base64 = "data:image/svg+xml;base64," + base64;
                            break;
                        // Fonts
                        case ".ttf":
                            base64 = "data:application/x-font-ttf;base64," + base64;
                            break;
                        case ".otf":
                            base64 = "data:application/x-font-opentype;base64," + base64;
                            break;
                        case ".woff":
                            base64 = "data:application/font-woff;base64," + base64;
                            break;
                        case ".eot":
                            base64 = "data:application/vnd.ms-fontobject;base64," + base64;
                            break;
                        default:
                            unknown = true;
                            break;
                    };

                    // Replace url with base64 data
                    if (!unknown) css = css.Replace(url, base64);

                } while (true);

                // Write file output
                System.IO.File.WriteAllText(directory + name + "-packed.css", css);

                // Finished
                progressBar.Value = 100;

            }
        }

        private void pnlDragTo_DragEnter(object sender, DragEventArgs e)
        {
            //if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Move;
            //else
              //  e.Effect = DragDropEffects.None;
        }

        private void pnlDragTo_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                pack(files);
            }
        }

    }
}
