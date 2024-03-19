using MediatR;

namespace TMAWarehouse.ApplicationServices.API.Domain.Request.UpdateRequest
{
    public class UpdateRequestRequest : IRequest<UpdateRequestResponse>
    {
        public int RequestId { get; set; }
        public string Status { get; set; }

        public int UserId { get; set; }
    }
}
