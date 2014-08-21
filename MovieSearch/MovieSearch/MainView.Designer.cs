namespace MovieSearch
{
    partial class MainView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.gridView = new System.Windows.Forms.DataGridView();
            this.button3 = new System.Windows.Forms.Button();
            this.textSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textGenre = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(141, 66);
            this.button1.TabIndex = 0;
            this.button1.Text = "Create Index";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.OnCreateIndex);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(160, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(141, 66);
            this.button2.TabIndex = 1;
            this.button2.Text = "Import Movies";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.OnImportMovies);
            // 
            // dataGridView1
            // 
            this.gridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridView.Location = new System.Drawing.Point(13, 157);
            this.gridView.Name = "gridView";
            this.gridView.RowTemplate.Height = 28;
            this.gridView.Size = new System.Drawing.Size(880, 481);
            this.gridView.TabIndex = 2;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 85);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(141, 66);
            this.button3.TabIndex = 3;
            this.button3.Text = "Search";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.OnSearch);
            // 
            // textSearch
            // 
            this.textSearch.Location = new System.Drawing.Point(160, 85);
            this.textSearch.Name = "textSearch";
            this.textSearch.Size = new System.Drawing.Size(549, 26);
            this.textSearch.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(159, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Genre";
            // 
            // textGenre
            // 
            this.textGenre.Location = new System.Drawing.Point(232, 118);
            this.textGenre.Name = "textGenre";
            this.textGenre.Size = new System.Drawing.Size(477, 26);
            this.textGenre.TabIndex = 6;
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 650);
            this.Controls.Add(this.textGenre);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textSearch);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.gridView);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "MainView";
            this.Text = "Movie Search";
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView gridView;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textGenre;
    }
}

