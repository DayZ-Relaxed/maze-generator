using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MazeGenerator
{
    public partial class Form1 : Form
    {

        private PrimMaze _maze;

        public Form1()
        {
            InitializeComponent();
         
        }

        private void generateMaze_Click(object sender, EventArgs e)
        {

            int width = Decimal.ToInt32(widthValue.Value);
            int height = Decimal.ToInt32(heightValue.Value);

            _maze = new PrimMaze(width, height, 
                Decimal.ToInt32(startingX.Value), 
                Decimal.ToInt32(startingY.Value), 
                Decimal.ToInt32(wallValue.Value), 
                Decimal.ToInt32(passageValue.Value)
            );
            _maze.Solve();

            mazeTextbox.Text = _maze.ToString();
            exportMaze.Enabled = true;
        }

        private void exportMaze_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                dialog.FilterIndex = 2;
                dialog.RestoreDirectory = true;
                dialog.FileName = $"{DateTimeOffset.UtcNow.ToUnixTimeSeconds()}.txt";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter file = new StreamWriter(dialog.FileName.ToString());
                    file.WriteLine(_maze.objectGeneration());
                    file.Close();
                }
            }
        }
    }
}
