namespace PayStackDotNetSDK.Models
{
    public class GeneralListRequestModel
    {
        /// <summary>
        /// perPage - Specify how many records you want to retrieve per page
        /// </summary>
        public int perPage { get; set; }
        /// <summary>
        /// page - Specify exactly what page you want to retrieve
        /// </summary>
        public int page { get; set; }
    }
}
