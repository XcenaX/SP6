namespace ThreadPoolsTest
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.workThreads = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.waitThreads = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.createdThreads = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label4 = new System.Windows.Forms.Label();
            this.createButton = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // workThreads
            // 
            this.workThreads.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.workThreads.Location = new System.Drawing.Point(26, 39);
            this.workThreads.Name = "workThreads";
            this.workThreads.Size = new System.Drawing.Size(205, 204);
            this.workThreads.TabIndex = 0;
            this.workThreads.UseCompatibleStateImageBehavior = false;
            this.workThreads.DoubleClick += new System.EventHandler(this.RemoveThread);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Работающие потоки";
            this.columnHeader1.Width = -2;
            // 
            // waitThreads
            // 
            this.waitThreads.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.waitThreads.Location = new System.Drawing.Point(248, 39);
            this.waitThreads.Name = "waitThreads";
            this.waitThreads.Size = new System.Drawing.Size(205, 204);
            this.waitThreads.TabIndex = 2;
            this.waitThreads.UseCompatibleStateImageBehavior = false;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Ожидающие потоки";
            this.columnHeader2.Width = -2;
            // 
            // createdThreads
            // 
            this.createdThreads.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3});
            this.createdThreads.Location = new System.Drawing.Point(469, 39);
            this.createdThreads.Name = "createdThreads";
            this.createdThreads.Size = new System.Drawing.Size(205, 204);
            this.createdThreads.TabIndex = 4;
            this.createdThreads.UseCompatibleStateImageBehavior = false;
            this.createdThreads.DoubleClick += new System.EventHandler(this.AddToQueue);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Созданные потоки";
            this.columnHeader3.Width = -2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.3F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(23, 262);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(170, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Кол-во мест в семафоре";
            // 
            // createButton
            // 
            this.createButton.Location = new System.Drawing.Point(599, 299);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(75, 23);
            this.createButton.TabIndex = 7;
            this.createButton.Text = "Создать";
            this.createButton.UseVisualStyleBackColor = true;
            this.createButton.Click += new System.EventHandler(this.createButton_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(26, 282);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown1.TabIndex = 8;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.ChangeSemaphoreSize);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 334);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.createButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.createdThreads);
            this.Controls.Add(this.waitThreads);
            this.Controls.Add(this.workThreads);
            this.MaximumSize = new System.Drawing.Size(710, 372);
            this.MinimumSize = new System.Drawing.Size(710, 372);
            this.Name = "Form1";
            this.Text = "Тест потоков";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView workThreads;
        private System.Windows.Forms.ListView waitThreads;
        private System.Windows.Forms.ListView createdThreads;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
    }
}

