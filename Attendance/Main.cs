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
    public partial class Main : Form
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


        FileStream fs;
        BinaryReader brProfile, brPrint;

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            m_LedOn = false;

            m_RegMin1 = new Byte[400];
            m_RegMin2 = new Byte[400];

            comboBoxSecuLevel_R.SelectedIndex = 4;

            EnableButtons(false);

            m_FPM = new SGFingerPrintManager();
            EnumerateBtn_Click(sender, e);

            StatusBar.Text = "Click Init Button";
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

        private Int32 OpenDevice(SGFPMDeviceName device_name, Int32 device_id)
        {
            Int32 iError = m_FPM.Init(device_name);
            iError = m_FPM.OpenDevice(device_id);

            checkBox1.Enabled = false;
            if (iError == (Int32)SGFPMError.ERROR_NONE)
            {
                //GetBtn_Click(sender, e);
                GetBtn_Click(null, null);
                StatusBar.Text = "Initialization Success";
                EnableButtons(true);

                // FDU03, FDU04 or higher
                if (device_name >= SGFPMDeviceName.DEV_FDU03)
                    checkBox1.Enabled = true;
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
        /// GetImage(), GetImageQuality(), CreateTemplate
        private void btnCapture1_Click(object sender, EventArgs e)
        {
            Int32 iError;
            Byte[] fp_image;
            Int32 img_qlty;

            fp_image = new Byte[m_ImageWidth * m_ImageHeight];
            img_qlty = 0;

            iError = m_FPM.GetImage(fp_image);

            m_FPM.GetImageQuality(m_ImageWidth, m_ImageHeight, fp_image, ref img_qlty);
            progressBar_R1.Value = img_qlty;

            if (iError == (Int32)SGFPMError.ERROR_NONE)
            {
                DrawImage(fp_image, pictureBoxR1);
                iError = m_FPM.CreateTemplate(fp_image, m_RegMin1);

                if (iError == (Int32)SGFPMError.ERROR_NONE)
                {
                    StatusBar.Text = "First image is captured";
                }
                else
                {
                    DisplayError("CreateTemplate()", iError);
                }
            }
            else
                DisplayError("GetImage()", iError);
        }

        //////////////////////
        ///Captures second fingerprint image
        ///Get fingerprint image quality
        private void btnCapture2_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            Int32 iError;
            Byte[] fp_image;
            Int32 img_qlty;

            fp_image = new Byte[m_ImageWidth * m_ImageHeight];
            img_qlty = 0;

            iError = m_FPM.GetImage(fp_image);
            m_FPM.GetImageQuality(m_ImageWidth, m_ImageHeight, fp_image, ref img_qlty);
            progressBar_R2.Value = img_qlty;

            if (iError == (Int32)SGFPMError.ERROR_NONE)
            {
                DrawImage(fp_image, pictureBoxR2);
                iError = m_FPM.CreateTemplate(fp_image, m_RegMin2);

                if (iError == (Int32)SGFPMError.ERROR_NONE)
                    StatusBar.Text = "Second image is captured";
                else
                    DisplayError("CreateTemplate()", iError);
            }
            else
                DisplayError("GetImage()", iError);

            Cursor.Current = Cursors.Default;
        }

        /////////////////////
        ///Submit captured fingerprint image, Extracted minutiae and other user details to database
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                Random rnd = new Random();
                int id = rnd.Next(1, 1000);
                string sql = string.Empty;
                string con = string.Empty;
                byte[] img = null;
                string imgLoc = tbImagePath.Text;
                FileStream fs = new FileStream(imgLoc, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                img = br.ReadBytes((int)fs.Length);
                string Select;

                Image myImage = pictureBoxR1.Image;
                byte[] data;
                using (MemoryStream ms = new MemoryStream())
                {
                    myImage.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                    data = ms.ToArray();
                }
                //connection to database
                con = "server=localhost;port=3306;username=root;database=students;password=";

                sql = @"INSERT  INTO users (MatNumber, Fullnames, AcademicSession, PhoneNumber, Photo, Fingerprint, f_id, f_id2, Department, Course, SchoolFees, unit, CourseCode ) VALUES (@Mat_Number, @Fnames, @Academic_Session, @Phone_Number, @Img, @F_image, @F_id, @F_id2, @D_partment, @C_urse, @School_Fees, @U_it, @Course_Code)";
                using (MySqlConnection sqlcon = new MySqlConnection(con))
                {
                    sqlcon.Open();
                    using (MySqlCommand com = new MySqlCommand(sql, sqlcon))
                    {
                        if (tbMatNumber.Text != "" || tbFullname.Text != "" || tbMobileNumber.Text != "" || tbAcademicSession.Text != "" || cbChooseDpt.Text != "" || cbSelectCourse.Text != "" || tbSchoolFees.Text != "" || tbCourseUnit.Text != "" || cbSelectCourseCode.Text != "")
                        {
                            ////get values from users
                            com.Parameters.AddWithValue("@Mat_Number", tbMatNumber.Text);
                            com.Parameters.AddWithValue("@Fnames", tbFullname.Text);
                            com.Parameters.AddWithValue("@Academic_Session", tbAcademicSession.Text);
                            com.Parameters.AddWithValue("@Phone_Number", tbMobileNumber.Text);
                            com.Parameters.AddWithValue("@Img", img);
                            com.Parameters.AddWithValue("@F_image", data);
                            com.Parameters.AddWithValue("@F_id", m_RegMin1);
                            com.Parameters.AddWithValue("@F_id2", m_RegMin2);
                            com.Parameters.AddWithValue("@D_partment", cbChooseDpt.Text);
                            com.Parameters.AddWithValue("@C_urse", cbSelectCourse.Text);
                            com.Parameters.AddWithValue("@School_Fees", tbSchoolFees.Text);
                            com.Parameters.AddWithValue("@U_it", tbCourseUnit.Text);
                            com.Parameters.AddWithValue("@Course_Code", cbSelectCourseCode.Text);

                            Select = "SELECT * FROM users WHERE MatNumber='" + tbMatNumber.Text + "'";
                            using (MySqlCommand cm = new MySqlCommand(Select, sqlcon))
                            {
                                using (MySqlDataReader auth = cm.ExecuteReader())
                                {
                                    if (auth.HasRows)
                                    {
                                        MessageBox.Show("Your details already exists in our database, Thank you", "Details Exist", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        sqlcon.Close();
                                    }
                                    else
                                    {
                                        cm.Connection.Close();
                                        sqlcon.Open();
                                        com.ExecuteNonQuery();
                                        //if successful
                                        MessageBox.Show("Registration complete", "Registration Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    }

                                }
                            }

                            //Empty Textboxes and Pictureboxes
                            tbMatNumber.Text = "";
                            tbFullname.Text = "";
                            tbMobileNumber.Text = "+234";
                            tbAcademicSession.Text = "";
                            cbChooseDpt.Text = "--Choose Department--";
                            cbSelectCourseCode.Text = "--Select Code--";
                            cbSelectCourse.Text = "--Select Course--";
                            tbCourseUnit.Text = "3";
                            tbSchoolFees.Text = "35100";
                            pbStudentPhoto.Image = Image.FromFile(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + @"\CSharp Projects\Paul Project\Resources\285-2855629_profile-clipart-hd-png-download.png");
                            pictureBoxR1.Image = Image.FromFile(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + @"\CSharp Projects\Paul Project\Resources\thumb.png");
                            pictureBoxR2.Image = Image.FromFile(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + @"\CSharp Projects\Paul Project\Resources\thumb Right.png");
                            progressBar_R1.Value = 0;
                            progressBar_R2.Value = 0;
                        }
                        else
                        {
                            StatusBar.Text = "Please Fill all required fields";
                        }
                        sqlcon.Close();
                    }
                }
            }
            catch
            {
                //Hanndle the Error
                MessageBox.Show("Please select a profile picture to upload, size should be less than 500kb");
                pbStudentPhoto.Image = Image.FromFile(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + @"\CSharp Projects\Paul Project\Resources\285-2855629_profile-clipart-hd-png-download.png");
            }
        }


        private Int32 GetImageFromFile(Byte[] data)
        {
            OpenFileDialog open_dlg;
            open_dlg = new OpenFileDialog();

            open_dlg.Title = "Image raw file dialog";
            open_dlg.Filter = "Image raw files (*.raw)|*.raw";

            if (open_dlg.ShowDialog() == DialogResult.OK)
            {
                FileStream inStream = File.OpenRead(open_dlg.FileName);

                BinaryReader br = new BinaryReader(inStream);

                Byte[] local_data = new Byte[data.Length];
                local_data = br.ReadBytes(data.Length);
                Array.Copy(local_data, data, data.Length);

                br.Close();
                return (Int32)SGFPMError.ERROR_NONE;
            }
            return (Int32)SGFPMError.ERROR_FUNCTION_FAILED;
        }

        ///////////////////////
        private void CheckBoxAutoOn_CheckedChanged(object sender, System.EventArgs e)
        {
            if (checkBox1.Checked)
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
        /// GetDeviceInfo()
        private void GetBtn_Click(object sender, System.EventArgs e)
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
                textSerialNum.Text = encoding.GetString(pInfo.DeviceSN);

                textImageHeight.Text = Convert.ToString(pInfo.ImageHeight);
                textImageWidth.Text = Convert.ToString(pInfo.ImageWidth);
                textBrightness.Text = Convert.ToString(pInfo.Brightness);
                textContrast.Text = Convert.ToString(pInfo.Contrast);
                textGain.Text = Convert.ToString(pInfo.Gain);

                //BrightnessUpDown.Value = pInfo.Brightness;
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            // open file dialog   
            OpenFileDialog open = new OpenFileDialog();
            // image filters  
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                // display image in picture box  
                pbStudentPhoto.Image = new Bitmap(open.FileName);
                tbImagePath.Text = open.FileName;
            }
        }
        ///////////////////////
        private void EnableButtons(bool enable)
        {
            btnCapture1.Enabled = enable;
            btnCapture2.Enabled = enable;
            btnBrowse.Enabled = enable;
            btnSubmit.Enabled = enable;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Navigate navigate = new Navigate();
            navigate.Show();
            this.Close();
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
    }
}
