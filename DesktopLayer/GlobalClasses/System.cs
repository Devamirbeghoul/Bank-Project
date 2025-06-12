using BusinessLayer;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace DesktopLayer.GlobalClasses
{
    public class clsSystem
    {
        private static string Key128 = "1234567890123456";
        private static string ToBgr(Color c) => $"{c.B:X2}{c.G:X2}{c.R:X2}";

        [DllImport("DwmApi")]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, int[] attrValue, int attrSize);

        const int DWWMA_CAPTION_COLOR = 35;
        const int DWWMA_BORDER_COLOR = 34;
        const int DWMWA_TEXT_COLOR = 36;
        public static void CustomWindow(Color captionColor, Color fontColor, Color borderColor, IntPtr handle)
        {
            IntPtr hWnd = handle;
            //Change caption color
            int[] caption = new int[] { int.Parse(ToBgr(captionColor), System.Globalization.NumberStyles.HexNumber) };
            DwmSetWindowAttribute(hWnd, DWWMA_CAPTION_COLOR, caption, 4);
            //Change font color
            int[] font = new int[] { int.Parse(ToBgr(fontColor), System.Globalization.NumberStyles.HexNumber) };
            DwmSetWindowAttribute(hWnd, DWMWA_TEXT_COLOR, font, 4);
            //Change border color
            int[] border = new int[] { int.Parse(ToBgr(borderColor), System.Globalization.NumberStyles.HexNumber) };
            DwmSetWindowAttribute(hWnd, DWWMA_BORDER_COLOR, border, 4);

        }

        private static string GenerateGuid() => Guid.NewGuid().ToString();

        public static void LogError(Exception ex)
        {
            try
            {
                if (!EventLog.SourceExists("BankApp"))
                    EventLog.CreateEventSource("BankApp", "Application");

                EventLog.WriteEntry("MyApp", $"Error: {ex.Message}\nStackTrace: {ex.StackTrace}", EventLogEntryType.Error);
            }
            catch (Exception)
            {
            }
        }

        private static string RenameFileByGuid(string FileName)
        {
            FileInfo Info = new FileInfo(FileName);

            return GenerateGuid() + Info.Extension;
        }

        private static bool CreateFolderIfNotExists(string path)
        {
            if (!Directory.Exists(path))
            {
                try
                {
                    Directory.CreateDirectory(path);
                    return true;
                }
                catch (Exception ex)
                {
                    LogError(ex);
                    return false;
                }
            }

            return true;
        }

        public static bool CopyImgToFolder(ref string Source)
        {
            string Folder = "C:\\PhoneApp-People-Imgs\\";
            
            if (!CreateFolderIfNotExists(Folder))
                return false;

            string NewPath = Path.Combine(Folder, RenameFileByGuid(Source));

            try
            {
                File.Copy(Source, NewPath , true);

                Source = NewPath;

                return true;
            }
            catch (IOException ex)
            {
                LogError(ex);
                return false;
            }

        }

        public static string SymmetricDecrypt(string cipherText)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(Key128);
                aesAlg.IV = new byte[aesAlg.BlockSize / 8];

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (var msDecrypt = new System.IO.MemoryStream(Convert.FromBase64String(cipherText)))
                using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                using (var srDecrypt = new System.IO.StreamReader(csDecrypt))
                {

                    return srDecrypt.ReadToEnd();
                }
            }
        }

        public static string SymmetricEncrypt(string plainText)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(Key128);

                aesAlg.IV = new byte[aesAlg.BlockSize / 8];

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (var msEncrypt = new System.IO.MemoryStream())
                {
                    using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    using (var swEncrypt = new System.IO.StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(plainText);
                    }

                    return Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
        }

        public static bool SaveLoginInforamtion(string Username , string Password , int Type)
        {
            string path = "HKEY_CURRENT_USER\\Software\\BankApp";

            try
            {
                Registry.SetValue(path, "Username", Username, RegistryValueKind.String);
                Registry.SetValue(path, "Password", Password, RegistryValueKind.String);
                Registry.SetValue(path, "Type", Type.ToString(), RegistryValueKind.String);


            }
            catch (Exception ex)
            {
                LogError(ex);
                return false;

            }

            return true;
        }

        public static bool BackupLoginInformation(ref string Username, ref string Password , ref string Type)
        {
            string path = "HKEY_CURRENT_USER\\Software\\BankApp";

            try
            {
                Username = Registry.GetValue(path, "Username", null) as string;
                Password = Registry.GetValue(path, "Password", null) as string;
                Type = Registry.GetValue(path, "Type", null) as string;

                if (Username == null || Password == null || Type == null)
                    return false;
                else
                {
                    Password = SymmetricDecrypt(Password);
                    return true;
                }

            }
            catch (Exception ex)
            {
                LogError(ex);
                return false;

            }
        }

        public static bool RemoveStoredInformation()
        {
            string keyPath = @"Software\BankApp";

            string UsernameName = "Username";
            string PasswordName = "Password";
            string TypeName = "Type";

            try
            {
                using (RegistryKey baseKey = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64))
                {
                    using (RegistryKey key = baseKey.OpenSubKey(keyPath, true))
                    {
                        if (key != null)
                        {
                            
                            key.DeleteValue(UsernameName);
                            key.DeleteValue(PasswordName);
                            key.DeleteValue(TypeName);

                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                LogError(ex);
                return false;
            }
            catch (Exception ex)
            {
                LogError(ex);
                return false;
            }
        }

        public static void SetHeadersAndWidthsOfDataGridView(DataGridView View , List<string> Headers , List<int> Widths)
        {
            if (View.RowCount > 0)
            {
                for (int i = 0; i < Widths.Count; i++)
                {
                    View.Columns[i].Width = Widths[i];
                    View.Columns[i].HeaderText = Headers[i];
                }
            }

            
        }

        public static void PerformBtnNext(ref int Current , int Total , Action RefreshProcedure)
        {
            if (Current < Total)
            {
                Current++;
                RefreshProcedure();
            }
        }

        public static void PerformBtnBack(ref int Current , Action RefreshProcedure)
        {
            if (Current > 1)
            {
                Current--;
                RefreshProcedure();
            }
        }

        public static void FillComboBox(ComboBox cb , DataTable Rows , string DefaultDisplay)
        {
            cb.Items.Clear();

            foreach (DataRow Row in Rows.Rows)
                cb.Items.Add(Row["Nm"].ToString());

            cb.Text = DefaultDisplay;
        }

       
    }
}
