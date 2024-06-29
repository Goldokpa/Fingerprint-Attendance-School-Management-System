using MySql.Data.MySqlClient;
using SecuGen.FDxSDKPro.Windows;
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

namespace Attendance
{
    public partial class MarkAttendance : Form
    {
        private SGFingerPrintManager m_FPM;
        private bool m_LedOn = false;
        private Int32 m_ImageWidth;
        private Int32 m_ImageHeight;
        private Byte[] m_RegMin1;
        private Byte[] m_RegMin2;
        private Byte[] m_VrfMin;
        private SGFPMDeviceList[] m_DevList; // Used for EnumerateDevice
        private bool m_DeviceOpened;
        private SGFPMSecurityLevel m_SecurityLevel;

        byte[] data;
        Byte[] fp_imageX;
        Int32 iErrorX;
        Int32 img_qltyX = 0;

        public MarkAttendance()
        {
            InitializeComponent();
        }

        private void Attend_Load(object sender, EventArgs e)
        {
            m_VrfMin = new Byte[400];
            comboBoxSecuLevel_V.SelectedIndex = 3;
            EnableButtons(false);

            m_FPM = new SGFingerPrintManager();
            EnumerateBtn_Click(sender, e);
        }

        ///////////////////////
        // Initialize SGFingerprint manage with device name
        // Init(), OpenDeice()
        private void OpenDeviceBtn_Click(object sender, EventArgs e)
        {
            if (m_FPM.NumberOfDevice == 0)
                return;

            SGFPMDeviceName device_name;
            Int32 device_id;

            Int32 numberOfDevices = cbDeviceName.Items.Count;
            Int32 deviceSelected = cbDeviceName.SelectedIndex;
            Boolean autoSelection = (deviceSelected == (numberOfDevices - 1));  // Last index

            if (autoSelection)
            {
                // Order of search: Hamster IV(HFDU04) -> Plus(HFDU03) -> III (HFDU02)
                device_name = SGFPMDeviceName.DEV_AUTO;

                device_id = (Int32)(SGFPMPortAddr.USB_AUTO_DETECT);
            }
            else
            {
                device_name = m_DevList[deviceSelected].DevName;
                device_id = m_DevList[deviceSelected].DevID;
            }

            Int32 iError = OpenDevice(device_name, device_id);

        }

        private Int32 OpenDevice(SGFPMDeviceName device_name, Int32 device_id)
        {
            Int32 iError = m_FPM.Init(device_name);
            iError = m_FPM.OpenDevice(device_id);

            CheckBoxAutoOn.Enabled = false;
            if (iError == (Int32)SGFPMError.ERROR_NONE)
            {
                //GetBtn_Click(sender, e);
                GetBtn_Click(null, null);
                StatusBar.Text = "Initialization Success";
                EnableButtons(true);

                // FDU03, FDU04 or higher
                if (device_name >= SGFPMDeviceName.DEV_FDU03)
                    CheckBoxAutoOn.Enabled = true;
            }
            else
                DisplayError("OpenDevice()", iError);
            return iError;
        }

        private void CloseDevice()
        {
            m_FPM.CloseDevice();
        }

        ///////////////////////
        /// EnumerateDevice(), GetEnumDeviceInfo()
        /// EnumerateDevice() can be called before Initializing SGFingerPrintManager
        private void EnumerateBtn_Click(object sender, System.EventArgs e)
        {
            Int32 iError;
            string enum_device;

            cbDeviceName.Items.Clear();

            // Enumerate Device
            iError = m_FPM.EnumerateDevice();

            // Get enumeration info into SGFPMDeviceList
            m_DevList = new SGFPMDeviceList[m_FPM.NumberOfDevice];

            for (int i = 0; i < m_FPM.NumberOfDevice; i++)
            {
                m_DevList[i] = new SGFPMDeviceList();
                m_FPM.GetEnumDeviceInfo(i, m_DevList[i]);
                enum_device = m_DevList[i].DevName.ToString() + " : " + m_DevList[i].DevID;
                cbDeviceName.Items.Add(enum_device);
            }

            if (cbDeviceName.Items.Count > 0)
            {
                // Add Auto Selection
                enum_device = "Auto Selection";
                cbDeviceName.Items.Add(enum_device);

                cbDeviceName.SelectedIndex = 0;  //First selected one
            }

        }

        //////////////////////
        ///Scan fingerprint and output fingerprint image
        private void btnCapture_Click(object sender, EventArgs e)
        {
            fp_imageX = new Byte[m_ImageWidth * m_ImageHeight];
            iErrorX = m_FPM.GetImage(fp_imageX);
            if (tbMatricNumber.Text != "")
            {
                if (iErrorX == (Int32)SGFPMError.ERROR_NONE)
                {
                    try
                    {
                        string select;
                        MySqlConnection con = new MySqlConnection("server=localhost;port=3306;username=root;database=students;password=");

                        select = "SELECT * FROM users WHERE MatNumber='" + tbMatricNumber.Text + "'";
                        using (MySqlCommand myCommand = new MySqlCommand(select, con))
                        {
                            using (MySqlDataAdapter da = new MySqlDataAdapter(myCommand))
                            {
                                DataTable table = new DataTable();
                                da.Fill(table);


                                lblStudentName.Text = table.Rows[0][2].ToString();
                                byte[] profile = (byte[])table.Rows[0][5];
                                lblDepartment.Text = table.Rows[0][9].ToString();
                                lblCourseTitle.Text = table.Rows[0][10].ToString();
                                lblCourseUnit.Text = table.Rows[0][11].ToString();
                                lblCourseCode.Text = table.Rows[0][13].ToString();
                                lblAcademicSession.Text = table.Rows[0][3].ToString();
                                lblLevel.Text = table.Rows[0][14].ToString();

                                MemoryStream ms = new MemoryStream(profile);
                                pictureBox2.Image = Image.FromStream(ms);
                                da.Dispose();

                                DrawImage(fp_imageX, pictureBox1);
                                m_FPM.GetImageQuality(m_ImageWidth, m_ImageHeight, fp_imageX, ref img_qltyX);
                                progressBar_V1.Value = img_qltyX;

                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Matric Number not registered");
                        tbMatricNumber.Text = string.Empty;
                    }

                }
                else
                {
                    StatusBar.Text = "GetImage() Error : " + iErrorX;
                }
            }
            else
            {
                MessageBox.Show("Please enter your Matric Number first", "Matric Number field empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        ////////////////////////
        ///Match scanned fingerprint and stored fingerprint
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if(tbMatricNumber.Text != "" & pictureBox1.Image != null)
            {
                string querry = "SELECT f_id, f_id2 FROM users WHERE MatNumber='" + tbMatricNumber.Text + "'";
                using (MySqlConnection conn = new MySqlConnection("server=localhost;port=3306;username=root;database=students;password="))
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.CommandText = querry;
                        cmd.Connection = conn;
                        conn.Open();
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                m_RegMin1 = (byte[])reader[0];
                                m_RegMin2 = (byte[])reader[1];
                            }
                        }
                    }
                }

                Int32 iError = iErrorX;
                Byte[] fp_image = fp_imageX;

                //Extract Minutiae to be saved in the database
                iError = m_FPM.CreateTemplate(null, fp_image, m_VrfMin);
                bool matched1 = false;
                bool matched2 = false;
                SGFPMSecurityLevel secu_level = SGFPMSecurityLevel.NORMAL;
                
                iError = m_FPM.MatchTemplate(m_RegMin1, m_VrfMin, secu_level, ref matched1);
                iError = m_FPM.MatchTemplate(m_RegMin2, m_VrfMin, secu_level, ref matched2);
                if (matched1 & matched1 || matched2 & matched2)
                {
                    //MessageBox.Show("Attendance Submitted, Fingerprint Matched");

                    string queryInsert = @"INSERT INTO attendance (MatNumber, Names, CourseTitle, CourseCode, CourseUnit, Level, Department, AcademicSession, Attendance, Time) VALUES(@Mat_Number, @N_ames, @Course_Title, @Course_Code, @Course_Unit, @L_evel, @D_patment, @Academic_Session, @A_ttenace, @T_ime)";

                    using (MySqlConnection conn = new MySqlConnection("server=localhost;port=3306;username=root;database=students;password="))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            Int32 attenance = 1;
                            cmd.CommandText = queryInsert;
                            cmd.Connection = conn;
                            conn.Open();

                            cmd.Parameters.AddWithValue("@Mat_Number", tbMatricNumber.Text);
                            cmd.Parameters.AddWithValue("@N_ames", lblStudentName.Text);
                            cmd.Parameters.AddWithValue("@Course_Title", lblCourseTitle.Text);
                            cmd.Parameters.AddWithValue("@Course_Code", lblCourseCode.Text);
                            cmd.Parameters.AddWithValue("@Course_Unit", lblCourseUnit.Text);
                            cmd.Parameters.AddWithValue("@L_evel", lblLevel.Text);
                            cmd.Parameters.AddWithValue("@D_patment", lblDepartment.Text);
                            cmd.Parameters.AddWithValue("@Academic_Session", lblAcademicSession.Text);
                            cmd.Parameters.AddWithValue("@A_ttenace", attenance);
                            cmd.Parameters.AddWithValue("@T_ime", DateTime.Now);

                            string Select = "SELECT * FROM attendance WHERE MatNumber='" + tbMatricNumber.Text + "'";
                            using (MySqlCommand cm = new MySqlCommand(Select, conn))
                            {
                                using (MySqlDataReader auth = cm.ExecuteReader())
                                {
                                    if (auth.HasRows)
                                    {
                                        MessageBox.Show("Your attendance has already been marked, Thank you", "Attendance Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Error );
                                        conn.Close();
                                    }
                                    else
                                    {
                                        cm.Connection.Close();
                                        conn.Open();
                                        cmd.ExecuteNonQuery();
                                        //if successful
                                        MessageBox.Show("Attendance marked successfully", "Attendance Marked", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    }

                                }
                            }
                            /*using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                MessageBox.Show("Attendance Submitted, Fingerprint Matched");
                            }*/
                            conn.Close();
                        }
                    }
                    //Clearing fields
                    tbMatricNumber.Text = string.Empty;
                    lblStudentName.Text = "-  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -";
                    lblDepartment.Text = "-  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -";
                    lblCourseUnit.Text = "-  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -";
                    lblCourseCode.Text = "-  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -";
                    lblCourseTitle.Text = "-  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -";
                    lblAcademicSession.Text = "-  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -";
                    lblLevel.Text = "-  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -  -";
                    pictureBox1.Image = Image.FromFile(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + @"\CSharp Projects\Paul Project\Resources\thumb.png");
                    pictureBox2.Image = Image.FromFile(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + @"\CSharp Projects\Paul Project\Resources\285-2855629_profile-clipart-hd-png-download.png");
                    progressBar_V1.Value = 0;
                }
                else
                {
                    MessageBox.Show("fingerprint not Matched", "Not Matched", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    progressBar_V1.Value = 0;
                    pictureBox1.Image = Image.FromFile(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + @"\CSharp Projects\Paul Project\Resources\thumb.png");
                }
            }
            else
            {
                MessageBox.Show("Please enter your Matric Number then scan Thumb before submitting attendance", "Matric Number Process Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            /*if (tbMatricNumber.Text != "")
            {
            }
            else
            {
                MessageBox.Show("Kindly enter your Matric Number then scan Thumb before submitting attendance", "Matric Number Process Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
        }

        private void GetBtn_Click(object sender, EventArgs e)
        {
            SGFPMDeviceInfoParam pInfo = new SGFPMDeviceInfoParam();
            Int32 iError = m_FPM.GetDeviceInfo(pInfo);

            if (iError == (Int32)SGFPMError.ERROR_NONE)
            {
                m_ImageWidth = pInfo.ImageWidth;
                m_ImageHeight = pInfo.ImageHeight;

                textDeviceID.Text = Convert.ToString(pInfo.DeviceID);
                textImageDPI.Text = Convert.ToString(pInfo.ImageDPI);
                textFWVersion.Text = Convert.ToString(pInfo.FWVersion, 16);

                ASCIIEncoding encoding = new ASCIIEncoding();
                textBrightness.Text = Convert.ToString(pInfo.Brightness);
                textContrast.Text = Convert.ToString(pInfo.Contrast);
                textGain.Text = Convert.ToString(pInfo.Gain);

            }
        }

        ///////////////////////
        private void DrawImage(Byte[] imgData, PictureBox picBox)
        {
            int colorval;
            Bitmap bmp = new Bitmap(m_ImageWidth, m_ImageHeight);
            picBox.Image = (Image)bmp;

            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    colorval = (int)imgData[(j * m_ImageWidth) + i];
                    bmp.SetPixel(i, j, Color.FromArgb(colorval, colorval, colorval));
                }
            }
            picBox.Refresh();
        }

        ///////////////////////
        private void CheckBoxAutoOn_CheckedChanged(object sender, System.EventArgs e)
        {
            if (CheckBoxAutoOn.Checked)
                m_FPM.EnableAutoOnEvent(true, (int)this.Handle);
            else
                m_FPM.EnableAutoOnEvent(false, 0);
        }

        ///////////////////////
        protected override void WndProc(ref Message message)
        {
            if (message.Msg == (int)SGFPMMessages.DEV_AUTOONEVENT)
            {
                if (message.WParam.ToInt32() == (Int32)SGFPMAutoOnEvent.FINGER_ON)
                    StatusBar.Text = "Device Message: Finger On";
                else if (message.WParam.ToInt32() == (Int32)SGFPMAutoOnEvent.FINGER_OFF)
                    StatusBar.Text = "Device Message: Finger Off";
            }
            base.WndProc(ref message);
        }

        ///////////////////////
        private void EnableButtons(bool enable)
        {
            btnSubmit.Enabled = enable;
            btnCapture.Enabled = enable;
        }

        ///////////////////////
        void DisplayError(string funcName, int iError)
        {
            string text = "";

            switch (iError)
            {
                case 0:                             //SGFDX_ERROR_NONE				= 0,
                    text = "Error none";
                    break;

                case 1:                             //SGFDX_ERROR_CREATION_FAILED	= 1,
                    text = "Can not create object";
                    break;

                case 2:                             //   SGFDX_ERROR_FUNCTION_FAILED	= 2,
                    text = "Function Failed";
                    break;

                case 3:                             //   SGFDX_ERROR_INVALID_PARAM	= 3,
                    text = "Invalid Parameter";
                    break;

                case 4:                          //   SGFDX_ERROR_NOT_USED			= 4,
                    text = "Not used function";
                    break;

                case 5:                                //SGFDX_ERROR_DLLLOAD_FAILED	= 5,
                    text = "Can not create object";
                    break;

                case 6:                                //SGFDX_ERROR_DLLLOAD_FAILED_DRV	= 6,
                    text = "Can not load device driver";
                    break;
                case 7:                                //SGFDX_ERROR_DLLLOAD_FAILED_ALGO = 7,
                    text = "Can not load sgfpamx.dll";
                    break;

                case 51:                //SGFDX_ERROR_SYSLOAD_FAILED	   = 51,	// system file load fail
                    text = "Can not load driver kernel file";
                    break;

                case 52:                //SGFDX_ERROR_INITIALIZE_FAILED  = 52,   // chip initialize fail
                    text = "Failed to initialize the device";
                    break;

                case 53:                //SGFDX_ERROR_LINE_DROPPED		   = 53,   // image data drop
                    text = "Data transmission is not good";
                    break;

                case 54:                //SGFDX_ERROR_TIME_OUT			   = 54,   // getliveimage timeout error
                    text = "Time out";
                    break;

                case 55:                //SGFDX_ERROR_DEVICE_NOT_FOUND	= 55,   // device not found
                    text = "Device not found";
                    break;

                case 56:                //SGFDX_ERROR_DRVLOAD_FAILED	   = 56,   // dll file load fail
                    text = "Can not load driver file";
                    break;

                case 57:                //SGFDX_ERROR_WRONG_IMAGE		   = 57,   // wrong image
                    text = "Wrong Image";
                    break;

                case 58:                //SGFDX_ERROR_LACK_OF_BANDWIDTH  = 58,   // USB Bandwith Lack Error
                    text = "Lack of USB Bandwith";
                    break;

                case 59:                //SGFDX_ERROR_DEV_ALREADY_OPEN	= 59,   // Device Exclusive access Error
                    text = "Device is already opened";
                    break;

                case 60:                //SGFDX_ERROR_GETSN_FAILED		   = 60,   // Fail to get Device Serial Number
                    text = "Device serial number error";
                    break;

                case 61:                //SGFDX_ERROR_UNSUPPORTED_DEV		   = 61,   // Unsupported device
                    text = "Unsupported device";
                    break;

                // Extract & Verification error
                case 101:                //SGFDX_ERROR_FEAT_NUMBER		= 101, // utoo small number of minutiae
                    text = "The number of minutiae is too small";
                    break;

                case 102:                //SGFDX_ERROR_INVALID_TEMPLATE_TYPE		= 102, // wrong template type
                    text = "Template is invalid";
                    break;

                case 103:                //SGFDX_ERROR_INVALID_TEMPLATE1		= 103, // wrong template type
                    text = "1st template is invalid";
                    break;

                case 104:                //SGFDX_ERROR_INVALID_TEMPLATE2		= 104, // vwrong template type
                    text = "2nd template is invalid";
                    break;

                case 105:                //SGFDX_ERROR_EXTRACT_FAIL		= 105, // extraction fail
                    text = "Minutiae extraction failed";
                    break;

                case 106:                //SGFDX_ERROR_MATCH_FAIL		= 106, // matching  fail
                    text = "Matching failed";
                    break;

            }

            text = funcName + " Error # " + iError + " :" + text;
            StatusBar.Text = text;
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            AdminLogin al = new AdminLogin();
            al.Show();
            this.Hide();
        }
    }
}
