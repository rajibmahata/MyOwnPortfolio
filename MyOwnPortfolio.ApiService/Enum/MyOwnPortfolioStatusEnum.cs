using System.ComponentModel;

namespace MyOwnPortfolio.ApiService.Enum
{
    /// <summary>
    /// Enum representing the status of MyOwnPortfolio API.
    /// </summary>
    public enum MyOwnPortfolioStatusEnum
    {
        /// <summary>
        /// Indicates a successful operation.
        /// </summary>
        [Description("Success")]
        Success = 1,

        /// <summary>
        /// Indicates a failed API call.
        /// </summary>
        [Description("Api Fail")]
        Failed = 2,

        /// <summary>
        /// Indicates an error occurred.
        /// </summary>
        [Description("Error")]
        Error = 3,

        /// <summary>
        /// Indicates data was not found.
        /// </summary>
        [Description("Data Not Found")]
        NotFound = 4,

        /// <summary>
        /// Indicates unauthorized access.
        /// </summary>
        [Description("Unauthorized")]
        Unauthorized = 5,

        /// <summary>
        /// Indicates forbidden access.
        /// </summary>
        [Description("Forbidden")]
        Forbidden = 6,

        /// <summary>
        /// Indicates a bad request.
        /// </summary>
        [Description("BadRequest")]
        BadRequest = 7,

        /// <summary>
        /// Indicates a conflict occurred.
        /// </summary>
        [Description("Conflict")]
        Conflict = 8,

        /// <summary>
        /// Indicates an internal server error.
        /// </summary>
        [Description("InternalServerError")]
        InternalServerError = 9,

        /// <summary>
        /// Indicates the service is unavailable.
        /// </summary>
        [Description("ServiceUnavailable")]
        ServiceUnavailable = 10,

        /// <summary>
        /// Indicates a gateway timeout.
        /// </summary>
        [Description("GatewayTimeout")]
        GatewayTimeout = 11,

        /// <summary>
        /// Indicates a bad gateway.
        /// </summary>
        [Description("BadGateway")]
        BadGateway = 12,

        /// <summary>
        /// Indicates a request timeout.
        /// </summary>
        [Description("RequestTimeout")]
        RequestTimeout = 13,

        /// <summary>
        /// Indicates a precondition failed.
        /// </summary>
        [Description("PreconditionFailed")]
        PreconditionFailed = 14,

        /// <summary>
        /// Indicates the request is not acceptable.
        /// </summary>
        [Description("NotAcceptable")]
        NotAcceptable = 15,

        /// <summary>
        /// Indicates an unsupported media type.
        /// </summary>
        [Description("UnsupportedMediaType")]
        UnsupportedMediaType = 16,

        /// <summary>
        /// Indicates the request entity is too large.
        /// </summary>
        [Description("RequestEntityTooLarge")]
        RequestEntityTooLarge = 17,

        /// <summary>
        /// Indicates the request URI is too long.
        /// </summary>
        [Description("RequestUriTooLong")]
        RequestUriTooLong = 18,

        /// <summary>
        /// Indicates an unsupported media type.
        /// </summary>
        [Description("UnsupportedMediaTypeType")]
        UnsupportedMediaTypeType = 19,

        /// <summary>
        /// Indicates the requested range is not satisfiable.
        /// </summary>
        [Description("RequestedRangeNotSatisfiable")]
        RequestedRangeNotSatisfiable = 20,

        /// <summary>
        /// Indicates an expectation failed.
        /// </summary>
        [Description("ExpectationFailed")]
        ExpectationFailed = 21,

        /// <summary>
        /// Indicates the server is a teapot.
        /// </summary>
        [Description("ImATeapot")]
        ImATeapot = 22,

        /// <summary>
        /// Indicates a misdirected request.
        /// </summary>
        [Description("MisdirectedRequest")]
        MisdirectedRequest = 23,

        /// <summary>
        /// Indicates an unprocessable entity.
        /// </summary>
        [Description("UnprocessableEntity")]
        UnprocessableEntity = 24,

        /// <summary>
        /// Indicates the resource is locked.
        /// </summary>
        [Description("Locked")]
        Locked = 25,

        /// <summary>
        /// Indicates a failed dependency.
        /// </summary>
        [Description("FailedDependency")]
        FailedDependency = 26,

        /// <summary>
        /// Indicates an upgrade is required.
        /// </summary>
        [Description("UpgradeRequired")]
        UpgradeRequired = 27,

        /// <summary>
        /// Indicates a precondition is required.
        /// </summary>
        [Description("PreconditionRequired")]
        PreconditionRequired = 28,

        /// <summary>
        /// Indicates too many requests.
        /// </summary>
        [Description("TooManyRequests")]
        TooManyRequests = 29,

        /// <summary>
        /// Indicates the request header fields are too large.
        /// </summary>
        [Description("RequestHeaderFieldsTooLarge")]
        RequestHeaderFieldsTooLarge = 30,

        /// <summary>
        /// Indicates the connection was closed without response.
        /// </summary>
        [Description("ConnectionClosedWithoutResponse")]
        ConnectionClosedWithoutResponse = 31,

        /// <summary>
        /// Indicates the resource is unavailable for legal reasons.
        /// </summary>
        [Description("UnavailableForLegalReasons")]
        UnavailableForLegalReasons = 32,

        /// <summary>
        /// Indicates the client closed the request.
        /// </summary>
        [Description("ClientClosedRequest")]
        ClientClosedRequest = 33,

        /// <summary>
        /// Indicates an internal server error with a message.
        /// </summary>
        [Description("InternalServerErrorWithMessage")]
        InternalServerErrorWithMessage = 34,

        /// <summary>
        /// Indicates the service is unavailable with a message.
        /// </summary>
        [Description("ServiceUnavailableWithMessage")]
        ServiceUnavailableWithMessage = 35,

        /// <summary>
        /// Indicates a gateway timeout with a message.
        /// </summary>
        [Description("GatewayTimeoutWithMessage")]
        GatewayTimeoutWithMessage = 36,

        /// <summary>
        /// Indicates a bad gateway with a message.
        /// </summary>
        [Description("BadGatewayWithMessage")]
        BadGatewayWithMessage = 37,

        /// <summary>
        /// Indicates a request timeout with a message.
        /// </summary>
        [Description("RequestTimeoutWithMessage")]
        RequestTimeoutWithMessage = 38,

        /// <summary>
        /// Indicates a precondition failed with a message.
        /// </summary>
        [Description("PreconditionFailedWithMessage")]
        PreconditionFailedWithMessage = 39,

        /// <summary>
        /// Indicates the request is not acceptable with a message.
        /// </summary>
        [Description("NotAcceptableWithMessage")]
        NotAcceptableWithMessage = 40,

        /// <summary>
        /// Indicates an unsupported media type with a message.
        /// </summary>
        [Description("UnsupportedMediaTypeWithMessage")]
        UnsupportedMediaTypeWithMessage = 41,

        /// <summary>
        /// Indicates the request entity is too large with a message.
        /// </summary>
        [Description("RequestEntityTooLargeWithMessage")]
        RequestEntityTooLargeWithMessage = 42,

        /// <summary>
        /// Indicates the request URI is too long with a message.
        /// </summary>
        [Description("RequestUriTooLongWithMessage")]
        RequestUriTooLongWithMessage = 43,

        /// <summary>
        /// Indicates an unsupported media type with a message.
        /// </summary>
        [Description("UnsupportedMediaTypeTypeWithMessage")]
        UnsupportedMediaTypeTypeWithMessage = 44,

        /// <summary>
        /// Indicates the requested range is not satisfiable with a message.
        /// </summary>
        [Description("RequestedRangeNotSatisfiableWithMessage")]
        RequestedRangeNotSatisfiableWithMessage = 45,

        /// <summary>
        /// Indicates an expectation failed with a message.
        /// </summary>
        [Description("ExpectationFailedWithMessage")]
        ExpectationFailedWithMessage = 46,

        /// <summary>
        /// Indicates the server is a teapot with a message.
        /// </summary>
        [Description("ImATeapotWithMessage")]
        ImATeapotWithMessage = 47,

        /// <summary>
        /// Indicates a misdirected request with a message.
        /// </summary>
        [Description("MisdirectedRequestWithMessage")]
        MisdirectedRequestWithMessage = 48,

        /// <summary>
        /// Indicates an unprocessable entity with a message.
        /// </summary>
        [Description("UnprocessableEntityWithMessage")]
        UnprocessableEntityWithMessage = 49,

        /// <summary>
        /// Indicates the resource is locked with a message.
        /// </summary>
        [Description("LockedWithMessage")]
        LockedWithMessage = 50,

        /// <summary>
        /// Indicates a failed dependency with a message.
        /// </summary>
        [Description("FailedDependencyWithMessage")]
        FailedDependencyWithMessage = 51,

        /// <summary>
        /// Indicates an upgrade is required with a message.
        /// </summary>
        [Description("UpgradeRequiredWithMessage")]
        UpgradeRequiredWithMessage = 52,

        /// <summary>
        /// Indicates a precondition is required with a message.
        /// </summary>
        [Description("PreconditionRequiredWithMessage")]
        PreconditionRequiredWithMessage = 53,

        /// <summary>
        /// Indicates too many requests with a message.
        /// </summary>
        [Description("TooManyRequestsWithMessage")]
        TooManyRequestsWithMessage = 54,

        /// <summary>
        /// Indicates the request header fields are too large with a message.
        /// </summary>
        [Description("RequestHeaderFieldsTooLargeWithMessage")]
        RequestHeaderFieldsTooLargeWithMessage = 55,

        /// <summary>
        /// Indicates the connection was closed without response with a message.
        /// </summary>
        [Description("ConnectionClosedWithoutResponseWithMessage")]
        ConnectionClosedWithoutResponseWithMessage = 56,

        /// <summary>
        /// Indicates the resource is unavailable for legal reasons with a message.
        /// </summary>
        [Description("UnavailableForLegalReasonsWithMessage")]
        UnavailableForLegalReasonsWithMessage = 57,
    }


    /// <summary>
    /// Extension methods for MyOwnPortfolioStatusEnum.
    /// </summary>
    public static class MyOwnPortfolioStatusEnumDescription
    {
        /// <summary>
        /// Gets the description attribute of the MyOwnPortfolioStatusEnum value.
        /// </summary>
        /// <param name="status">The status enum value.</param>
        /// <returns>The description of the status enum value.</returns>
        public static string GetDescription(this MyOwnPortfolioStatusEnum status)
        {
            var type = typeof(MyOwnPortfolioStatusEnum);
            var memInfo = type.GetMember(status.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
            return ((DescriptionAttribute)attributes[0]).Description;
        }
    }
}
