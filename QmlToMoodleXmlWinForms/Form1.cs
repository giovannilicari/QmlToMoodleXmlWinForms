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

namespace QmlToMoodleXmlWinForms
{
	public partial class Form1 : Form
	{
		private string selectedFolder;

		public string SelectedFolder { get; private set; }

		public Form1()
		{
			InitializeComponent();
		}

		private void btnSelectedFolder_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog folderDialog = new FolderBrowserDialog();
			if (folderDialog.ShowDialog() == DialogResult.OK)
			{
				selectedFolder = folderDialog.SelectedPath; // Update the field
				lstFiles.Items.Clear();
				if (!string.IsNullOrEmpty(selectedFolder))
				{
					var qmlFiles = Directory.GetFiles(selectedFolder, "*.qml");
					foreach (var file in qmlFiles)
						lstFiles.Items.Add(Path.GetFileName(file));
					Log($"Selezionati {qmlFiles.Length} file.");
				}
				else
				{
					Log("Nessuna cartella selezionata o percorso non valido.");
				}
			}
		}

		private void Log(string v)
		{
			if (txtLog is TextBox logBox)
			{
				logBox.AppendText(v + Environment.NewLine);
			}
			else
			{
				MessageBox.Show(v); // Fallback logging
			}
		}

		private void btnConvert_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(selectedFolder))
			{
				MessageBox.Show("Seleziona una cartella per convertire i file.");
				return;
			}

			if (lstFiles.Items.Count == 0)
			{
				MessageBox.Show("Nessun file da convertire. Seleziona prima la cartella.");
				return;
			}

			foreach (string file in lstFiles.Items)
			{
				string inputPath = Path.Combine(selectedFolder, file);
				string outputPath = inputPath + ".xml";

				try
				{
					QmlConverter.Convert(inputPath, outputPath);
					Log($"Convertito: {file}");
				}
				catch (Exception ex)
				{
					Log($"Errore in {file}: {ex.Message}");
				}
			}

			MessageBox.Show("Conversione completata!");
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{

		}

		private void lstFiles_SelectedIndexChanged(object sender, EventArgs e)
		{

		}
	}


}
