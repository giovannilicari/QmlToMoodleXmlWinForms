namespace QmlToMoodleXmlWinForms
{
	partial class Form1
	{
		/// <summary>
		/// Variabile di progettazione necessaria.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Pulire le risorse in uso.
		/// </summary>
		/// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Codice generato da Progettazione Windows Form

		/// <summary>
		/// Metodo necessario per il supporto della finestra di progettazione. Non modificare
		/// il contenuto del metodo con l'editor di codice.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnSelectedFolder = new System.Windows.Forms.Button();
			this.lstFiles = new System.Windows.Forms.ListBox();
			this.btnConvert = new System.Windows.Forms.Button();
			this.txtLog = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// btnSelectedFolder
			// 
			this.btnSelectedFolder.Location = new System.Drawing.Point(145, 321);
			this.btnSelectedFolder.Name = "btnSelectedFolder";
			this.btnSelectedFolder.Size = new System.Drawing.Size(186, 82);
			this.btnSelectedFolder.TabIndex = 0;
			this.btnSelectedFolder.Text = "Selezione Cartella";
			this.btnSelectedFolder.UseVisualStyleBackColor = true;
			this.btnSelectedFolder.Click += new System.EventHandler(this.btnSelectedFolder_Click);
			// 
			// lstFiles
			// 
			this.lstFiles.FormattingEnabled = true;
			this.lstFiles.ItemHeight = 16;
			this.lstFiles.Location = new System.Drawing.Point(58, 63);
			this.lstFiles.Name = "lstFiles";
			this.lstFiles.Size = new System.Drawing.Size(391, 212);
			this.lstFiles.TabIndex = 1;
			this.lstFiles.SelectedIndexChanged += new System.EventHandler(this.lstFiles_SelectedIndexChanged);
			// 
			// btnConvert
			// 
			this.btnConvert.Location = new System.Drawing.Point(680, 321);
			this.btnConvert.Name = "btnConvert";
			this.btnConvert.Size = new System.Drawing.Size(198, 96);
			this.btnConvert.TabIndex = 2;
			this.btnConvert.Text = "Converti";
			this.btnConvert.UseVisualStyleBackColor = true;
			this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
			// 
			// txtLog
			// 
			this.txtLog.Location = new System.Drawing.Point(496, 63);
			this.txtLog.Multiline = true;
			this.txtLog.Name = "txtLog";
			this.txtLog.ReadOnly = true;
			this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtLog.Size = new System.Drawing.Size(589, 212);
			this.txtLog.TabIndex = 3;
			this.txtLog.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1125, 445);
			this.Controls.Add(this.txtLog);
			this.Controls.Add(this.btnConvert);
			this.Controls.Add(this.lstFiles);
			this.Controls.Add(this.btnSelectedFolder);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnSelectedFolder;
		private System.Windows.Forms.ListBox lstFiles;
		private System.Windows.Forms.Button btnConvert;
		private System.Windows.Forms.TextBox txtLog;
	}
}

