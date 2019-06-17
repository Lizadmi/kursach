namespace vet_clinicka
{
    partial class ReceptionsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReceptionsForm));
            this.label_id = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label_pets = new System.Windows.Forms.Label();
            this.comboBox_pets = new System.Windows.Forms.ComboBox();
            this.label_owner = new System.Windows.Forms.Label();
            this.comboBox_owner = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_doctor = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox_service = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // label_id
            // 
            this.label_id.AutoSize = true;
            this.label_id.Font = new System.Drawing.Font("Segoe UI Symbol", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_id.Location = new System.Drawing.Point(283, 13);
            this.label_id.Name = "label_id";
            this.label_id.Size = new System.Drawing.Size(26, 20);
            this.label_id.TabIndex = 0;
            this.label_id.Text = "№";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(111, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 21);
            this.label1.TabIndex = 15;
            this.label1.Text = "Запись на прием";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.MediumAquamarine;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox1.Font = new System.Drawing.Font("Segoe UI Symbol", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(317, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(50, 27);
            this.textBox1.TabIndex = 16;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_pets
            // 
            this.label_pets.AutoSize = true;
            this.label_pets.Font = new System.Drawing.Font("Segoe UI Symbol", 11.25F);
            this.label_pets.Location = new System.Drawing.Point(12, 113);
            this.label_pets.Name = "label_pets";
            this.label_pets.Size = new System.Drawing.Size(144, 20);
            this.label_pets.TabIndex = 22;
            this.label_pets.Text = "Выберать питомца:";
            // 
            // comboBox_pets
            // 
            this.comboBox_pets.BackColor = System.Drawing.Color.MintCream;
            this.comboBox_pets.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_pets.FormattingEnabled = true;
            this.comboBox_pets.Location = new System.Drawing.Point(217, 112);
            this.comboBox_pets.Name = "comboBox_pets";
            this.comboBox_pets.Size = new System.Drawing.Size(150, 21);
            this.comboBox_pets.TabIndex = 21;
            this.comboBox_pets.SelectedIndexChanged += new System.EventHandler(this.comboBox_pets_SelectedIndexChanged);
            // 
            // label_owner
            // 
            this.label_owner.AutoSize = true;
            this.label_owner.Font = new System.Drawing.Font("Segoe UI Symbol", 11.25F);
            this.label_owner.Location = new System.Drawing.Point(12, 78);
            this.label_owner.Name = "label_owner";
            this.label_owner.Size = new System.Drawing.Size(133, 20);
            this.label_owner.TabIndex = 20;
            this.label_owner.Text = "Выбрать хозяина:";
            // 
            // comboBox_owner
            // 
            this.comboBox_owner.BackColor = System.Drawing.Color.MintCream;
            this.comboBox_owner.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_owner.FormattingEnabled = true;
            this.comboBox_owner.Location = new System.Drawing.Point(216, 77);
            this.comboBox_owner.Name = "comboBox_owner";
            this.comboBox_owner.Size = new System.Drawing.Size(150, 21);
            this.comboBox_owner.TabIndex = 19;
            this.comboBox_owner.SelectedIndexChanged += new System.EventHandler(this.comboBox_owner_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Symbol", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 226);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 20);
            this.label2.TabIndex = 24;
            this.label2.Text = "Выбрать дату приема:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Symbol", 11.25F);
            this.label3.Location = new System.Drawing.Point(12, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 20);
            this.label3.TabIndex = 28;
            this.label3.Text = "Выбрать врача:";
            // 
            // comboBox_doctor
            // 
            this.comboBox_doctor.BackColor = System.Drawing.Color.MintCream;
            this.comboBox_doctor.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_doctor.FormattingEnabled = true;
            this.comboBox_doctor.Location = new System.Drawing.Point(216, 148);
            this.comboBox_doctor.Name = "comboBox_doctor";
            this.comboBox_doctor.Size = new System.Drawing.Size(150, 21);
            this.comboBox_doctor.TabIndex = 27;
            this.comboBox_doctor.SelectedIndexChanged += new System.EventHandler(this.comboBox_doctor_SelectedIndexChanged);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.MintCream;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Font = new System.Drawing.Font("Segoe UI Symbol", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(108, 304);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(141, 28);
            this.button2.TabIndex = 29;
            this.button2.Text = "Добавить запись";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Symbol", 11.25F);
            this.label4.Location = new System.Drawing.Point(12, 184);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 20);
            this.label4.TabIndex = 34;
            this.label4.Text = "Выбрать услугу:";
            // 
            // comboBox_service
            // 
            this.comboBox_service.BackColor = System.Drawing.Color.MintCream;
            this.comboBox_service.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_service.FormattingEnabled = true;
            this.comboBox_service.Location = new System.Drawing.Point(216, 183);
            this.comboBox_service.Name = "comboBox_service";
            this.comboBox_service.Size = new System.Drawing.Size(150, 21);
            this.comboBox_service.TabIndex = 33;
            this.comboBox_service.SelectedIndexChanged += new System.EventHandler(this.comboBox_service_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.MintCream;
            this.button1.BackgroundImage = global::vet_clinicka.Properties.Resources.стрелка6;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Segoe UI Symbol", 9F);
            this.button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button1.Location = new System.Drawing.Point(12, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(36, 24);
            this.button1.TabIndex = 35;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarMonthBackground = System.Drawing.Color.MintCream;
            this.dateTimePicker1.CalendarTitleBackColor = System.Drawing.Color.MediumAquamarine;
            this.dateTimePicker1.CalendarTrailingForeColor = System.Drawing.Color.LightSeaGreen;
            this.dateTimePicker1.CustomFormat = "dd.MM.yyyy hh:mm";
            this.dateTimePicker1.Font = new System.Drawing.Font("Segoe UI Symbol", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(216, 226);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(150, 22);
            this.dateTimePicker1.TabIndex = 36;
            // 
            // ReceptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumAquamarine;
            this.ClientSize = new System.Drawing.Size(378, 344);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBox_service);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox_doctor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label_pets);
            this.Controls.Add(this.comboBox_pets);
            this.Controls.Add(this.label_owner);
            this.Controls.Add(this.comboBox_owner);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label_id);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ReceptionsForm";
            this.Text = "АИС Ветеринарная клиника/Запись на прием";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ReceptionsForm_FormClosing);
            this.Load += new System.EventHandler(this.ReceptionsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_id;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label_pets;
        private System.Windows.Forms.ComboBox comboBox_pets;
        private System.Windows.Forms.Label label_owner;
        private System.Windows.Forms.ComboBox comboBox_owner;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox_doctor;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox_service;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}