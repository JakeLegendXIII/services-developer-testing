using Grpc.Core;

using UtilitiesGrpService.Protos;

using Utils;

namespace UtilitiesGrpService.Services;

public class DateUtilsService : DateUtils.DateUtilsBase
{
    private readonly Utils.DateUtilities _utils;

    public DateUtilsService(DateUtilities utils)
    {
        _utils = utils;
    }

    public override Task<DateUtilsResponse> isWeekday(DateUtilsRequest request, ServerCallContext context)
    {
        var incommingDate = request.Date.ToDateTime();
        var result = _utils.IsWeekDay(incommingDate);

        return Task.FromResult(new DateUtilsResponse { Ok = result });
    }

    public override Task<DateUtilsResponse> isWeekend(DateUtilsRequest request, ServerCallContext context)
    {
        var incommingDate = request.Date.ToDateTime();
        var result = _utils.IsWeekend(incommingDate);

        return Task.FromResult(new DateUtilsResponse { Ok = result });
    }
}
