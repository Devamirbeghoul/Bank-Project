using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopLayer.GlobalClasses
{
    public class clsMessages
    {
        static void GenerateMessage(string Description , string Title , MessageBoxIcon Icon)
            => MessageBox.Show(Description, Title, MessageBoxButtons.OK, Icon);

        public static void GeneralSuccessMessage(string Description , string Title = "Success")
            => GenerateMessage(Description, Title , MessageBoxIcon.Information);

        public static void GeneralErrorMessage(string Description , string Title = "Failed")
            => GenerateMessage(Description, Title, MessageBoxIcon.Error);

        public static void FailedSaveData()
            => GeneralErrorMessage("Error: Date Doesn't Save");

        public static void SuccessSaveData()
            => GeneralSuccessMessage("Data Saved Successfuly!");

        public static void AlreadyTakenMessage(string item1, string item2)
            => GeneralErrorMessage($"This {item1} is already taken by another {item2}!", $"Invalid {item1}");

        public static void NullOrEmptyFieldsMessage(bool AreItemsInvalids)
            => GeneralErrorMessage("Some Fields are empty" + ((AreItemsInvalids) ? " or invalid!" : ""), "Invalid Inputs");

        public static void NullObject(string item1, string item2 = "")
            => GeneralErrorMessage($"There's no {item1} {item2}" , $"Invalid {item1}");

        public static bool ConfirmDelete(string type, int? ID)
            => MessageBox.Show($"Are you sure you want to delete {type} with ID : " + ID, "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK;

        public static bool Confirm(string type)
            => MessageBox.Show($"Are you sure you want to {type}", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK;
    }
}
