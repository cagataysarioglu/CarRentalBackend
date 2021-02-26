using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string Added = "Added successfully.";
        public static string NotAdded = "Addition failed.";
        public static string Listed = "Items that you requested were listed.";
        public static string Deleted = "Items that you selected were deleted.";
        public static string NotDeleted = "Deletion failed.";
        public static string Updated = "Items that you selected were updated.";
        public static string NotUpdated = "Items could not be updated.";
        public static string NameInvalid = "Item name is invalid.";
        public static string DailyPriceInvalid = "Item daily price is invalid.";
        public static string MaintenanceTime = "Service is unavailable.";
        public static string CarCountOfBrandError = "Car count exceeded brand limit";
        public static string CarNameAlreadyExists = "Car name already exists.";
        public static string BrandCountBoundExceeded = "Brand count bound exceeded.";
        public static string ImageLimitExceeded = "Reached to image limit";
    }
}
