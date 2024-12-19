using Microsoft.Identity.Client;

namespace PayrollService.SharedResource
{
    public class SharedResource
    {
        private SharedResource()
        {
            
        }

        public const string StatusDataFound = "STATUS_DATA_FOUND";
        public const string StatusSuccess = "STATUS_SUCCESS";
        public const string StatusDataFailed = "STATUS_DATA_FAILED";
    }
}
