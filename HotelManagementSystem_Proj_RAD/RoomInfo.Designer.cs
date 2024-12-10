namespace HotelManagementSystem_Proj
{
    partial class RoomInfo
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
            txtRoomType = new TextBox();
            txtPrice = new TextBox();
            txtAmenities = new TextBox();
            txtRoomNumber = new TextBox();
            cboCleaningStatus = new ComboBox();
            chkAvailability = new CheckBox();
            btnSaveRoom = new Button();
            btnCancel = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            SuspendLayout();
            // 
            // txtRoomType
            // 
            txtRoomType.Location = new Point(238, 45);
            txtRoomType.Name = "txtRoomType";
            txtRoomType.Size = new Size(182, 31);
            txtRoomType.TabIndex = 0;
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(238, 92);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(182, 31);
            txtPrice.TabIndex = 1;
            // 
            // txtAmenities
            // 
            txtAmenities.Location = new Point(238, 146);
            txtAmenities.Name = "txtAmenities";
            txtAmenities.Size = new Size(182, 31);
            txtAmenities.TabIndex = 2;
            // 
            // txtRoomNumber
            // 
            txtRoomNumber.Location = new Point(238, 197);
            txtRoomNumber.Name = "txtRoomNumber";
            txtRoomNumber.Size = new Size(182, 31);
            txtRoomNumber.TabIndex = 3;
            // 
            // cboCleaningStatus
            // 
            cboCleaningStatus.FormattingEnabled = true;
            cboCleaningStatus.Location = new Point(238, 252);
            cboCleaningStatus.Name = "cboCleaningStatus";
            cboCleaningStatus.Size = new Size(182, 33);
            cboCleaningStatus.TabIndex = 4;
            // 
            // chkAvailability
            // 
            chkAvailability.AutoSize = true;
            chkAvailability.Location = new Point(238, 319);
            chkAvailability.Name = "chkAvailability";
            chkAvailability.Size = new Size(123, 29);
            chkAvailability.TabIndex = 5;
            chkAvailability.Text = "Availability";
            chkAvailability.UseVisualStyleBackColor = true;
            // 
            // btnSaveRoom
            // 
            btnSaveRoom.Location = new Point(142, 384);
            btnSaveRoom.Name = "btnSaveRoom";
            btnSaveRoom.Size = new Size(112, 34);
            btnSaveRoom.TabIndex = 6;
            btnSaveRoom.Text = "Save";
            btnSaveRoom.UseVisualStyleBackColor = true;
            btnSaveRoom.Click += btnSaveRoom_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(326, 384);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(112, 34);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(69, 51);
            label1.Name = "label1";
            label1.Size = new Size(106, 25);
            label1.TabIndex = 8;
            label1.Text = "Room Type:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(69, 98);
            label2.Name = "label2";
            label2.Size = new Size(53, 25);
            label2.TabIndex = 9;
            label2.Text = "Price:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(69, 155);
            label3.Name = "label3";
            label3.Size = new Size(94, 25);
            label3.TabIndex = 10;
            label3.Text = "Amenities:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(69, 203);
            label4.Name = "label4";
            label4.Size = new Size(134, 25);
            label4.TabIndex = 11;
            label4.Text = "Room Number:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(69, 258);
            label5.Name = "label5";
            label5.Size = new Size(137, 25);
            label5.TabIndex = 12;
            label5.Text = "Cleaning Status:";
            // 
            // AddRoom
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(582, 450);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnCancel);
            Controls.Add(btnSaveRoom);
            Controls.Add(chkAvailability);
            Controls.Add(cboCleaningStatus);
            Controls.Add(txtRoomNumber);
            Controls.Add(txtAmenities);
            Controls.Add(txtPrice);
            Controls.Add(txtRoomType);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Name = "AddRoom";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Room Information";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtRoomType;
        private TextBox txtPrice;
        private TextBox txtAmenities;
        private TextBox txtRoomNumber;
        private ComboBox cboCleaningStatus;
        private CheckBox chkAvailability;
        private Button btnSaveRoom;
        private Button btnCancel;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
    }
}