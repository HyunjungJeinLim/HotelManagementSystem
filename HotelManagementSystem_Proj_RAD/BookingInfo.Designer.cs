namespace HotelManagementSystem_Proj
{
    partial class BookingInfo
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
            txtRoomNumber = new TextBox();
            txtCustomerName = new TextBox();
            txtTotalPrice = new TextBox();
            dtpCheckInDate = new DateTimePicker();
            dtpCheckOutDate = new DateTimePicker();
            cboBookingStatus = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            btnSaveBooking = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // txtRoomNumber
            // 
            txtRoomNumber.Location = new Point(258, 47);
            txtRoomNumber.Name = "txtRoomNumber";
            txtRoomNumber.Size = new Size(301, 31);
            txtRoomNumber.TabIndex = 0;
            // 
            // txtCustomerName
            // 
            txtCustomerName.Location = new Point(258, 112);
            txtCustomerName.Name = "txtCustomerName";
            txtCustomerName.Size = new Size(301, 31);
            txtCustomerName.TabIndex = 1;
            // 
            // txtTotalPrice
            // 
            txtTotalPrice.Location = new Point(259, 306);
            txtTotalPrice.Name = "txtTotalPrice";
            txtTotalPrice.Size = new Size(300, 31);
            txtTotalPrice.TabIndex = 2;
            // 
            // dtpCheckInDate
            // 
            dtpCheckInDate.Location = new Point(259, 173);
            dtpCheckInDate.Name = "dtpCheckInDate";
            dtpCheckInDate.Size = new Size(300, 31);
            dtpCheckInDate.TabIndex = 3;
            // 
            // dtpCheckOutDate
            // 
            dtpCheckOutDate.Location = new Point(259, 245);
            dtpCheckOutDate.Name = "dtpCheckOutDate";
            dtpCheckOutDate.Size = new Size(300, 31);
            dtpCheckOutDate.TabIndex = 4;
            // 
            // cboBookingStatus
            // 
            cboBookingStatus.FormattingEnabled = true;
            cboBookingStatus.Location = new Point(259, 370);
            cboBookingStatus.Name = "cboBookingStatus";
            cboBookingStatus.Size = new Size(300, 33);
            cboBookingStatus.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(51, 47);
            label1.Name = "label1";
            label1.Size = new Size(134, 25);
            label1.TabIndex = 6;
            label1.Text = "Room Number:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(51, 112);
            label2.Name = "label2";
            label2.Size = new Size(145, 25);
            label2.TabIndex = 7;
            label2.Text = "Customer Name:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(51, 173);
            label3.Name = "label3";
            label3.Size = new Size(83, 25);
            label3.TabIndex = 8;
            label3.Text = "Check In:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(51, 245);
            label4.Name = "label4";
            label4.Size = new Size(98, 25);
            label4.TabIndex = 9;
            label4.Text = "Check Out:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(51, 306);
            label5.Name = "label5";
            label5.Size = new Size(95, 25);
            label5.TabIndex = 10;
            label5.Text = "Total Price:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(51, 370);
            label6.Name = "label6";
            label6.Size = new Size(64, 25);
            label6.TabIndex = 11;
            label6.Text = "Status:";
            // 
            // btnSaveBooking
            // 
            btnSaveBooking.Location = new Point(281, 452);
            btnSaveBooking.Name = "btnSaveBooking";
            btnSaveBooking.Size = new Size(112, 34);
            btnSaveBooking.TabIndex = 12;
            btnSaveBooking.Text = "Save";
            btnSaveBooking.UseVisualStyleBackColor = true;
            btnSaveBooking.Click += btnSaveBooking_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(447, 452);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(112, 34);
            btnCancel.TabIndex = 13;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // BookingInfo
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(672, 524);
            Controls.Add(btnCancel);
            Controls.Add(btnSaveBooking);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cboBookingStatus);
            Controls.Add(dtpCheckOutDate);
            Controls.Add(dtpCheckInDate);
            Controls.Add(txtTotalPrice);
            Controls.Add(txtCustomerName);
            Controls.Add(txtRoomNumber);
            Name = "BookingInfo";
            Text = "BookingInfo";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtRoomNumber;
        private TextBox txtCustomerName;
        private TextBox txtTotalPrice;
        private DateTimePicker dtpCheckInDate;
        private DateTimePicker dtpCheckOutDate;
        private ComboBox cboBookingStatus;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Button btnSaveBooking;
        private Button btnCancel;
    }
}