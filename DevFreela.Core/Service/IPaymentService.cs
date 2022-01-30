using DevFreela.Core.DTOs;
using System.Threading.Tasks;

namespace DevFreela.Core.Service
{
    public interface IPaymentService
    {
        void ProcessPayment(PaymentInfoDTO paymentInfoDTO);
    }
}
