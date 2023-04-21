using MazeGenerator.DayZ;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace MazeGenerator
{
    public partial class Form1 : Form
    {
        private DayZRelaxedMazeHelpers _maze;
        private string _objectName;
        private int _selectedObject = -1;

        public Form1() => InitializeComponent();

        private void generateMaze_Click(object sender, EventArgs e)
        {
            _maze = new DayZRelaxedMazeHelpers(
                decimal.ToInt32(widthValue.Value),
                decimal.ToInt32(heightValue.Value),
                decimal.ToInt32(startingX.Value),
                decimal.ToInt32(startingY.Value),
                wallValue.Value,
                passageValue.Value,
                decimal.ToInt32(xChange.Value),
                decimal.ToInt32(yChange.Value),
                new List<string>(),
                wallObject.Text
            );
            _maze.Solve();

            mazeTextbox.Text = _maze.ToString();

            this.checkPreGeneration();
        }

        private void exportMaze_Click(object sender, EventArgs e)
        {
            List<string> objectNames = new List<string>();

            foreach (string objectName in objectsToSelectFrom.Items)
            {
                objectNames.Add(objectName);
            }
            _maze.objectNames = objectNames;

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

        private void objectsToSelectFrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedObject = objectsToSelectFrom.SelectedIndex;
        }

        private void addToObjectList_Click(object sender, EventArgs e)
        {
            if (_objectName == null) return;
            objectsToSelectFrom.Items.Add(_objectName);
            textToAddToObjectList.Text = "";
            _objectName = null;

            this.checkPreGeneration();
        }

        private void textToAddToObjectList_TextChanged(object sender, EventArgs e)
        {
            _objectName = textToAddToObjectList.Text;
        }

        private void removeFromObjectList_Click(object sender, EventArgs e)
        {
            if (_selectedObject == -1) return;
            objectsToSelectFrom.Items.RemoveAt(_selectedObject);

            this.checkPreGeneration();
        }

        private void checkPreGeneration()
        {
            if (objectsToSelectFrom.Items.Count == 0) exportMaze.Enabled = false;
            else exportMaze.Enabled = true;
        }
    }
}
