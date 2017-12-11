namespace App
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtStart = new System.Windows.Forms.TextBox();
            this.txtStop = new System.Windows.Forms.TextBox();
            this.listBoxResult = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.listBoxStart = new System.Windows.Forms.ListBox();
            this.form1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.listBoxStop = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.form1BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // txtStart
            // 
            this.txtStart.Location = new System.Drawing.Point(62, 52);
            this.txtStart.Name = "txtStart";
            this.txtStart.Size = new System.Drawing.Size(157, 20);
            this.txtStart.TabIndex = 0;
            this.txtStart.TextChanged += new System.EventHandler(this.txtStart_TextChanged);
            // 
            // txtStop
            // 
            this.txtStop.Location = new System.Drawing.Point(267, 52);
            this.txtStop.Name = "txtStop";
            this.txtStop.Size = new System.Drawing.Size(157, 20);
            this.txtStop.TabIndex = 1;
            this.txtStop.TextChanged += new System.EventHandler(this.txtStop_TextChanged);
            // 
            // listBoxResult
            // 
            this.listBoxResult.FormattingEnabled = true;
            this.listBoxResult.Location = new System.Drawing.Point(62, 199);
            this.listBoxResult.Name = "listBoxResult";
            this.listBoxResult.Size = new System.Drawing.Size(537, 199);
            this.listBoxResult.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(62, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Abfahrtsort";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(267, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Ankunftsort";
            // 
            // btnSearch
            // 
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnSearch.Location = new System.Drawing.Point(547, 50);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(132, 23);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "Verbindung suchen";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // listBoxStart
            // 
            this.listBoxStart.FormattingEnabled = true;
            this.listBoxStart.Location = new System.Drawing.Point(62, 78);
            this.listBoxStart.Name = "listBoxStart";
            this.listBoxStart.Size = new System.Drawing.Size(157, 95);
            this.listBoxStart.TabIndex = 6;
            this.listBoxStart.Visible = false;
            this.listBoxStart.SelectedIndexChanged += new System.EventHandler(this.listBoxStart_SelectedIndexChanged);
            // 
            // form1BindingSource
            // 
            this.form1BindingSource.DataSource = typeof(App.Form1);
            // 
            // listBoxStop
            // 
            this.listBoxStop.FormattingEnabled = true;
            this.listBoxStop.Location = new System.Drawing.Point(267, 78);
            this.listBoxStop.Name = "listBoxStop";
            this.listBoxStop.Size = new System.Drawing.Size(157, 95);
            this.listBoxStop.TabIndex = 7;
            this.listBoxStop.Visible = false;
            this.listBoxStop.SelectedIndexChanged += new System.EventHandler(this.listBoxStop_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 436);
            this.Controls.Add(this.listBoxStop);
            this.Controls.Add(this.listBoxStart);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBoxResult);
            this.Controls.Add(this.txtStop);
            this.Controls.Add(this.txtStart);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.form1BindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtStart;
        private System.Windows.Forms.TextBox txtStop;
        private System.Windows.Forms.ListBox listBoxResult;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ListBox listBoxStart;
        private System.Windows.Forms.BindingSource form1BindingSource;
        private System.Windows.Forms.ListBox listBoxStop;
    }
}

