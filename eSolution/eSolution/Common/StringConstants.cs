using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSolution
{
    public class ConstStrings
    {
        //Success
        public const string Success = "Success";
        public const string RequestCompleted = "Request Completed";

        //Fail
        public const string Failed = "Failed";
        public const string TryAgain = "Please, try again";

        //Warning
        public const string Warning = "Warning";
        public const string MakeChangeRequiredField = "Please, make change for requied field";
        public const string Notfound = "No data found based on your request!";
        public const string NoDataChanged = "No data has been changed";

        public const string RequiredRefNo = "Reference number is required";
        public const string ExistBillNo = "BillNo is already exist.";
        public const string NoRemainedQty = "Remained Qty is 0.";

        //Confirmation
        public const string Confirm = "Confirmation";
        public const string ConfirmClear = "Are you sure to clear?";
        public const string ConfirmClose = "Are you sure to close?";
        //   public const string ConfirmCancel = "Are you sure to cancel?";
        public const string ConfirmDelete = "Are you sure to delete?";
        public const string ConfirmSkipEmail = "Are you sure to submit without email?";

        /******************************************************************************/
        public const string ContactSystemAdmin = "Please, Contact system administrator";
        public const string QtyMoreThanZero = "Qty must be more than 0";
        public const string NoChangeMade = "No Change Made";
        public const string DataChanged = "Data has been changed";
        public const string LocationNotValid = "Location is not valid";
        public const string ItemIDNotValid = "Item is not valid";
        public const string ItemStatusIDNotValid = "Item Status is not valid";
        public const string ContainerTypeNotValid = "Container Type is not valid";
        public const string TaskIDNotValid = "TaskID is not valid";
        public const string FoundSamePW = "Password must be different from old one";
        public const string ContainerIDExist = "ContainerID is already exist";
        public const string FailToConvertAsTable = "Fail to convert. Please, system administrator.";
        public const string ExistItemQty = "This item is already in the list as same Qty";
        public const string ExistItem = " Is already exist";
        public const string ExistData = " This data is already exist";
        public const string ExistItemCode = "Item Code Is already exist";
        public const string ExistManufactureItemCode = "Manufacture Item Code Is already exist";
        public const string NoFunctionAvalaible = "This function is not available at this moment.";
        public const string CancelWarning = "Are you sure to cancel?";

        //Information
        public const string Information = "Information";
        public const string NotStartedTaskReceiving = "You have not started a receiving task for this Reference No.";
        public const string UpdateQty = "Do you want to update the Qty as ";

        //Cancel
        public const string Canceled = "Request is canceled";

        //Qty Compare
        public const string MoreThanRemaining = "The Qty is more than Remaining Qty";
        public const string MoreThanScheduled = "The Qty is more than Scheduled Qty";
        public const string MoreThanSuggested = "The Qty is more than Suggested Qty";

        public string GetQtyWarning(string strQtyField, string strMoreLess)
        {
            return String.Format("The Qty is {0} than {1} Qty", strMoreLess, strQtyField);
        }

        //Validation
        public const string Checktherequireddata = "Check the required data";
        public const string UserValidationFailed = "Failed user verification. Check ID & Password";
        public const string UserValidationSuccess = "Verified";

        //Close

        public const string ConfirmEdit = "Are you sure to edit?";
        public const string ConfirmEnable = "Are you sure to enable?";
        public const string ConfirmDisable = "Are you sure to disable?";
        public const string ConfirmRemain = "There are unsaved data. Are you sure to close?";

        //To place quotation marks in a string in your code 
        public const string Quote = "\"";

    }
    //struct struPODataEntry
    //{
    //    public string _PONumber;
    //    public DateTime _OrderDate;
    //    public string _Status;
    //}
}
